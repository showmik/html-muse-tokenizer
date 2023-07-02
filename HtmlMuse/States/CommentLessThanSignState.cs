using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class CommentLessThanSignState : State<HtmlTokenizer>
{
    private static CommentLessThanSignState? _instance;
    public static CommentLessThanSignState Instance => _instance ??= new CommentLessThanSignState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '!')
        {
            (owner.CurrentToken as CommentToken).Data += owner.CodePoint.Value;
            owner.FSM.SwitchState(CommentLessThanSignBang.Instance);
        }
        else if (owner.CodePoint.Value == '<')
        {
            (owner.CurrentToken as CommentToken).Data += owner.CodePoint.Value;
        }
        else
        {
            owner.ReconsumeCharacter(CommentState.Instance);
        }
    }
}