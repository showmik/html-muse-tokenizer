using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class MarkupDeclarationOpenState : State<HtmlTokenizer>
{
    private static MarkupDeclarationOpenState? _instance;
    public static MarkupDeclarationOpenState Instance => _instance ??= new MarkupDeclarationOpenState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CheckFor("--", true))
        {
            owner.ConsumeCharacters("--");
            owner.CreateToken(new CommentToken { Data = string.Empty });
            owner.FSM.SwitchState(CommentStartState.Instance);
        }
        else if (owner.CheckFor("DOCTYPE", false))
        {
            owner.ConsumeCharacters("DOCTYPE");
            owner.FSM.SwitchState(DOCTYPEState.Instance);
        }
        else if (owner.CheckFor("[CDATA[", true))
        {
            // ToDo: Switch to CDATASectionState if thereis a adjusted current node
            // and it is not an element in the HTML namespace.
            // I'm not sure but I think it has to witch the parsing tree.

            owner.ConsumeCharacters("[CDATA[");
            owner.FSM.SwitchState(BogusCommentState.Instance);
        }
        else
        {
            owner.CreateToken(new CommentToken { Data = string.Empty });
            owner.ReconsumeCharacter(BogusCommentState.Instance);
        }
    }
}