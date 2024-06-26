using System.IO;
using Doc.FnApps.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Doc.FnApps;

public static class FcDocTrigger
{
    [FunctionName("FcDocTrigger")]
    public static void Run([BlobTrigger("tobeprocess/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob,
        string name, ILogger log)
    {
        var xmlReader = new IssuerXmlReader();
        var issuer = xmlReader.ReadEmit(myBlob);
        log.LogInformation($"Issuer name is {issuer.Name}; Issuer company is {issuer.Company}");
    }
}