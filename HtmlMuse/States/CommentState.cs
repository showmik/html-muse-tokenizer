using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class CommentState : State<HtmlTokenizer>
{
    private static CommentState? _instance;
    public static CommentState Instance => _instance ??= new CommentState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '<')
        {
            (owner.CurrentToken as CommentToken).Data += owner.CodePoint.Value;
            owner.FSM.SwitchState(CommentLessThanSignState.Instance);
        }
        else if (owner.CodePoint.Value == '-')
        {
            owner.FSM.SwitchState(CommentEndDashState.Instance);
        }
        else if (owner.CodePoint.IsNullCharacter)
        {
            (owner.CurrentToken as CommentToken).Data += '\uFFFD';
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitCurrentToken();
            owner.EmitToken(new EOFToken());
        }
        else
        {
            (owner.CurrentToken as CommentToken).Data += owner.CodePoint.Value;
        }
    }
}