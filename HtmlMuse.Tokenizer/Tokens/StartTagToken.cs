namespace HtmlMuse.Tokenizer.Tokens
{
    public class StartTagToken : Token, ITagToken
    {
        public string? TagName { get; set; }
        public bool IsSelfClosing { get; set; }
        public List<Attribute> Attributes { get; set; }

        public StartTagToken()
        {
            IsSelfClosing = false;
            Attributes = new List<Attribute>();
        }
    }
}