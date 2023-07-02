using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class CommentStartDashState : State<HtmlTokenizer>
{
    private static CommentStartDashState? _instance;
    public static CommentStartDashState Instance => _instance ??= new CommentStartDashState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '-')
        {
            owner.FSM.SwitchState(CommentEndState.Instance);
        }
        else if (owner.CodePoint.Value == '>')
        {
            owner.EmitCurrentToken();
            owner.FSM.SwitchState(DataState.Instance);
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