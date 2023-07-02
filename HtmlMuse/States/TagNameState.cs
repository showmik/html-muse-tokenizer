using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class TagNameState : State<HtmlTokenizer>
{
    private static TagNameState? _instance;
    public static TagNameState Instance => _instance ??= new TagNameState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.IsWhiteSpace)
        {
            owner.FSM.SwitchState(BeforeAttributeNameState.Instance);
        }
        else if (owner.CodePoint.Value == '/')
        {
            owner.FSM.SwitchState(SelfClosingStartTagState.Instance);
        }
        else if (owner.CodePoint.Value == '>')
        {
            owner.EmitCurrentToken();
            owner.FSM.SwitchState(DataState.Instance);
        }
        else if (owner.CodePoint.IsAlpha)
        {
            (owner.CurrentToken as ITagToken).TagName += owner.CodePoint.ToLower();
        }
        else if (owner.CodePoint.IsNullCharacter)
        {
            (owner.CurrentToken as ITagToken).TagName += '\uFFFD';
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitToken(new EOFToken());
        }
        else
        {
            // Append the current input character to the current tag token's tag name.
            (owner.CurrentToken as ITagToken).TagName += owner.CodePoint.Value;
        }
    }
}