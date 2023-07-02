using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class CommentEndState : State<HtmlTokenizer>
{
    private static CommentEndState? _instance;
    public static CommentEndState Instance => _instance ??= new CommentEndState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '>')
        {
            owner.EmitCurrentToken();
            owner.FSM.SwitchState(DataState.Instance);
        }
        else if (owner.CodePoint.Value == '!')
        {
            owner.FSM.SwitchState(CommentEndBangState.Instance);
        }
        else if (owner.CodePoint.Value == '-')
        {
            (owner.CurrentToken as CommentToken).Data += '-';
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