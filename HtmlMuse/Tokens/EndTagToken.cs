namespace HtmlMuse.Tokenizer.Tokens;

public class EndTagToken : Token, ITagToken
{
    public string? TagName { get; set; }
    public bool IsSelfClosing { get; set; }
    public List<Attribute> Attributes { get; set; }

    public EndTagToken()
    {
        IsSelfClosing = false;
        Attributes = new List<Attribute>();
    }
}