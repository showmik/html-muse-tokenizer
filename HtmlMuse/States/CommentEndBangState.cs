using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class CommentEndBangState : State<HtmlTokenizer>
{
    private static CommentEndBangState? _instance;
    public static CommentEndBangState Instance => _instance ??= new CommentEndBangState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '-')
        {
            (owner.CurrentToken as CommentToken).Data += "--!";
            owner.FSM.SwitchState(CommentEndDashState.Instance);
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
            (owner.CurrentToken as CommentToken).Data += "--!";
            owner.ReconsumeCharacter(CommentState.Instance);
        }
    }
}