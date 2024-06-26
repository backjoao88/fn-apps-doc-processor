namespace Doc.FnApps.Entities;

public class Issuer
{
    public Issuer(string partitionKey, string rowKey, string name, string company, string stateRegistration, string crt)
    {
        PartitionKey = partitionKey;
        RowKey = rowKey;
        Name = name;
        Company = company;
        StateRegistration = stateRegistration;
        Crt = crt;
    }
    public string PartitionKey { get; private set; }
    public string RowKey { get; private set; }
    public string Name { get; private set; }
    public string Company { get; private set; }
    public string StateRegistration { get; private set; }
    public string Crt { get; private set; }
}