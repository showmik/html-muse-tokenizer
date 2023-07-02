using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class TagOpenState : State<HtmlTokenizer>
{
    private static TagOpenState? _instance;
    public static TagOpenState Instance => _instance ??= new TagOpenState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '!')
        {
            owner.FSM.SwitchState(MarkupDeclarationOpenState.Instance);
        }
        else if (owner.CodePoint.Value == '/')
        {
            owner.FSM.SwitchState(EndTagOpenState.Instance);
        }
        else if (owner.CodePoint.IsAlpha)
        {
            owner.CreateToken(new StartTagToken { TagName = string.Empty });
            owner.ReconsumeCharacter(TagNameState.Instance);
        }
        else if (owner.CodePoint.Value == '?')
        {
            owner.CreateToken(new CommentToken { Data = string.Empty });
            owner.ReconsumeCharacter(BogusCommentState.Instance);
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitToken(new CharacterToken { Data = '<' });
            owner.EmitToken(new EOFToken());
        }
        else
        {
            owner.EmitToken(new CharacterToken { Data = '<' });
            owner.ReconsumeCharacter(DataState.Instance);
        }
    }
}