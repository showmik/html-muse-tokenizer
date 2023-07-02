namespace HtmlMuse.Tokenizer.Tokens;

public class EOFToken : Token
{
    public override string ToString()
    {
        return "(End Of File)";
    }
}