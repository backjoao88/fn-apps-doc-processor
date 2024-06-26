using System.IO;
using Doc.FnApps.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Doc.FnApps;

[StorageAccount("AzureWebJobsStorage")]
public class FcDocTrigger
{
    [FunctionName("FcDocTrigger")]
    [return: Queue("queueprocess")]
    public string Run([BlobTrigger("tobeprocess/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob,
        string name, ILogger log)
    {
        var xmlReader = new IssuerXmlReader();
        var issuer = xmlReader.ReadEmit(myBlob);
        log.LogInformation($"Issuer name is {issuer.Name}; Issuer company is {issuer.Company}");
        return JsonConvert.SerializeObject(issuer);
    }
}