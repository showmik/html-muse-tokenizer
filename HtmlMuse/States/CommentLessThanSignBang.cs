namespace HtmlMuse.Tokenizer.States;

public class CommentLessThanSignBang : State<HtmlTokenizer>
{
    private static CommentLessThanSignBang? _instance;
    public static CommentLessThanSignBang Instance => _instance ??= new CommentLessThanSignBang();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '-')
        {
            owner.FSM.SwitchState(CommentLessThanSignBangDash.Instance);
        }
        else
        {
            owner.ReconsumeCharacter(CommentState.Instance);
        }
    }
}