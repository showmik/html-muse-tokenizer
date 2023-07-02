namespace HtmlMuse.Tokenizer.Tokens;

public class DOCTYPEToken : Token
{
    public string? Name { get; set; }
    public string? PublicIdentifier { get; set; }
    public string? SystemIdentifier { get; set; }
    public bool ForceQuirks { get; set; }

    public DOCTYPEToken()
    {
        ForceQuirks = false;
    }
}