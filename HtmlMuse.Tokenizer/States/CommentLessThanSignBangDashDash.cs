namespace HtmlMuse.Tokenizer.States;

public class CommentLessThanSignBangDashDash : State<HtmlTokenizer>
{
    private static CommentLessThanSignBangDashDash? _instance;
    public static CommentLessThanSignBangDashDash Instance => _instance ??= new CommentLessThanSignBangDashDash();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '>' || owner.IsAtEndOfFile)
        {
            owner.ReconsumeCharacter(CommentEndState.Instance);
        }
        else
        {
            owner.ReconsumeCharacter(CommentEndState.Instance);
        }
    }
}