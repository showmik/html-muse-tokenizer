namespace HtmlMuse.Tokenizer.Tokens;

public class CharacterToken : Token
{
    public char? Data { get; set; }

    public override string ToString()
    {
        return $"(Character) -> Data: {Data}";
    }
}