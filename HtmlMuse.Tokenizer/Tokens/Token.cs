namespace HtmlMuse.Tokenizer.Tokens;

public enum TokenType
{
    DOCTYPEToken,
    CommentToken,
    StartTagToken,
    EndTagToke,
    CharacterToke,
    EndOfFileToken
};

public abstract class Token
{
}