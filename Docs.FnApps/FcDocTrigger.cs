using System.IO;
using Doc.FnApps.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Doc.FnApps;

[StorageAccount("AzureWebJobsStorage")]
public class FcDocTrigger
{
    [FunctionName("FcDocTrigger")]
    [return: Queue("queueprocess")]
    public string Run([BlobTrigger("tobeprocess/{name}", Connection = "AzureWebJobsStorage")] Stream item,
        string name, ILogger log)
    {
        var xmlReader = new IssuerXmlReader();
        var issuer = xmlReader.Read(name, item);
        log.LogInformation($"Issuer name is {issuer.Name}; Issuer company is {issuer.Company}");
        return JsonConvert.SerializeObject(issuer);
    }
}