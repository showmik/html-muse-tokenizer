namespace HtmlMuse.Tokenizer.States;

public class CommentStartState : State<HtmlTokenizer>
{
    private static CommentStartState? _instance;
    public static CommentStartState Instance => _instance ??= new CommentStartState();

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
        else
        {
            owner.ReconsumeCharacter(CommentState.Instance);
        }
    }
}