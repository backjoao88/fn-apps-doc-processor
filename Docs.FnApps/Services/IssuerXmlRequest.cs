using System;

namespace Doc.FnApps.Services;

[Serializable]
public record IssuerXmlRequest
{
    public string Filename { get; set; } = "";
    public string Name { get; set; } = "";
    public string Company { get; set; } = "";
    public string StateRegistration { get; set; } = "";
    public string Crt { get; set; } = "";
}