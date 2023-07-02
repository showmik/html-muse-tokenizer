namespace HtmlMuse.Tokenizer.Tokens;

public interface ITagToken
{
    public string? TagName { get; set; }
    public bool IsSelfClosing { get; set; }
    public List<Attribute> Attributes { get; set; }
}