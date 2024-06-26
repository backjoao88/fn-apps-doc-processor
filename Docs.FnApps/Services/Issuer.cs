namespace Doc.FnApps.Services;

public class Issuer
{
    public Issuer(string name, string company)
    {
        Name = name;
        Company = company;
    }
    public string Name { get; set; }
    public string Company { get; set; }
}