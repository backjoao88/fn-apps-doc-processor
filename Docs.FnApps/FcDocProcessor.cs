using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Doc.FnApps.Entities;
using Doc.FnApps.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Doc.FnApps;

public class FcDocProcessor
{
    [FunctionName("FcDocProcessor")]
    [return: Table("docsinfo", Connection = "AzureWebJobsStorage")]
    public async Task<Issuer> Run([QueueTrigger("queueprocess", Connection = "AzureWebJobsStorage")] string item, ILogger log)
    {
        var issuer = JsonConvert.DeserializeObject<IssuerXmlRequest>(item);
        
        var blobClient = new BlobClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"), "tobeprocess",
            issuer.Filename);
        var dataStream = await blobClient.DownloadStreamingAsync();
        
        var blobContainerClient = new BlobContainerClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage"), "processdone");
        await blobContainerClient.UploadBlobAsync(issuer.Filename, dataStream.Value.Content);

        await blobClient.DeleteIfExistsAsync();
        
        return new Issuer("emit", Guid.NewGuid().ToString(), issuer.Name, issuer.Company, issuer.StateRegistration, issuer.Crt);
    }

}