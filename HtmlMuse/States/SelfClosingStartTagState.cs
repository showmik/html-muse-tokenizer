using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class SelfClosingStartTagState : State<HtmlTokenizer>
{
    private static SelfClosingStartTagState? _instance;
    public static SelfClosingStartTagState Instance => _instance ??= new SelfClosingStartTagState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '>')
        {
            (owner.CurrentToken as ITagToken).IsSelfClosing = true;
            owner.EmitCurrentToken();
            owner.FSM.SwitchState(DataState.Instance);
        }
        else if (owner.IsAtEndOfFile)
        {
            // Parse Error: end-of-tag
            owner.EmitToken(new EOFToken());
        }
        else
        {
            // Parse Error: unexpected-solidus-in-tag
            owner.ReconsumeCharacter(BeforeAttributeNameState.Instance);
        }
    }
}