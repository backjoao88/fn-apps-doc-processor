using System.IO;
using System.Xml;

namespace Doc.FnApps.Services;

public class IssuerXmlReader
{
    public Issuer ReadEmit(Stream data)
    {
        XmlDocument document = new XmlDocument();
        using (Stream stream = data)
        {
            stream.Position = 0;
            document.Load(stream);
        }
        var name = document.SelectSingleNode("emit/xNome")!.InnerText;
        var company = document.SelectSingleNode("emit/xFant")!.InnerText;
        return new Issuer(name, company);
    }
}