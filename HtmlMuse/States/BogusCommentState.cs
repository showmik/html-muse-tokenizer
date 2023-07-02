using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class BogusCommentState : State<HtmlTokenizer>
{
    private static BogusCommentState? _instance;
    public static BogusCommentState Instance => _instance ??= new BogusCommentState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '>')
        {
            owner.EmitCurrentToken();
            owner.FSM.SwitchState(DataState.Instance);
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitCurrentToken();
            owner.EmitToken(new EOFToken());
        }
        else if (owner.CodePoint.IsNullCharacter)
        {
            (owner.CurrentToken as CommentToken).Data += '\uFFFD';
        }
        else
        {
            (owner.CurrentToken as CommentToken).Data += owner.CodePoint.Value;
        }
    }
}