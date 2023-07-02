namespace HtmlMuse.Tokenizer.Tokens;

public class CommentToken : Token
{
    public string? Data { get; set; }

    public override string ToString()
    {
        return $"(Comment) -> Data: {Data}";
    }
}