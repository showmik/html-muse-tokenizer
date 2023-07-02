using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class EndTagOpenState : State<HtmlTokenizer>
{
    private static EndTagOpenState? _instance;
    public static EndTagOpenState Instance => _instance ??= new EndTagOpenState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.IsAlpha)
        {
            owner.CreateToken(new EndTagToken { TagName = string.Empty });
            owner.ReconsumeCharacter(TagNameState.Instance);
        }
        else if (owner.CodePoint.Value == '>')
        {
            owner.FSM.SwitchState(DataState.Instance);
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitToken(new CharacterToken { Data = '<' });
            owner.EmitToken(new CharacterToken { Data = '/' });
            owner.EmitToken(new EOFToken());
        }
        else
        {
            owner.CreateToken(new CommentToken { Data = string.Empty });
            owner.ReconsumeCharacter(BogusCommentState.Instance);
        }
    }
}