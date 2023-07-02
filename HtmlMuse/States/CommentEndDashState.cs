using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class CommentEndDashState : State<HtmlTokenizer>
{
    private static CommentEndDashState? _instance;
    public static CommentEndDashState Instance => _instance ??= new CommentEndDashState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '-')
        {
            owner.FSM.SwitchState(CommentEndState.Instance);
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitCurrentToken();
            owner.EmitToken(new EOFToken());
        }
        else
        {
            (owner.CurrentToken as CommentToken).Data += '-';
            owner.ReconsumeCharacter(CommentState.Instance);
        }
    }
}