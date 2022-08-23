namespace Controller.Api;

public class InvalidPatchPropertiesException : Exception
{
    public InvalidPatchPropertiesException(IEnumerable<string> invalidProperties)
    {
        Properties = invalidProperties;
    }

    public IEnumerable<string> Properties { get; }

    public override string Message
    {
        get
        {
            var propertyCsv = Properties.Aggregate("", (current, prop) => current + $"'{prop}',");
            propertyCsv = propertyCsv.Substring(0, propertyCsv.Length - 1);

            return $"{propertyCsv} {(Properties.Count() == 1 ? "is" : "are")} not able to be updated.";
        }
    }
}