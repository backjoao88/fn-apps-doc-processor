using System.IO;
using System.Xml;

namespace Doc.FnApps.Services;

public class IssuerXmlReader
{
    public IssuerXmlRequest Read(string filename, Stream data)
    {
        XmlDocument document = new XmlDocument();
        using (Stream stream = data)
        {
            stream.Position = 0;
            document.Load(stream);
        }

        var fileName = filename;
        var name = document.SelectSingleNode("emit/xNome")!.InnerText;
        var company = document.SelectSingleNode("emit/xFant")!.InnerText;
        var stateRegistration = document.SelectSingleNode("emit/IE")!.InnerText;
        var crt = document.SelectSingleNode("emit/CRT")!.InnerText;

        var read = new IssuerXmlRequest();
        read.Filename = fileName;
        read.Name = name;
        read.Company = company;
        read.StateRegistration = stateRegistration;
        read.Crt = crt;
        return read;
    }
}