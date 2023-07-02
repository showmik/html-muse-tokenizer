using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class BeforeAttributeNameState : State<HtmlTokenizer>
{
    private static BeforeAttributeNameState? _instance;
    public static BeforeAttributeNameState Instance => _instance ??= new BeforeAttributeNameState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.IsWhiteSpace)
        {
            // Do Nothing (Ignores the character)
        }
        else if (owner.CodePoint.Value == '/' || owner.CodePoint.Value == '>' || owner.IsAtEndOfFile)
        {
            owner.ReconsumeCharacter(AfterAttributeNameState.Instance);
        }
        else if (owner.CodePoint.Value == '=')
        {
            (owner.CurrentToken as ITagToken).Attributes.Add(new Attribute { Name = owner.CodePoint.Value.ToString(), Value = string.Empty });
            owner.FSM.SwitchState(AttributeNameState.Instance);
        }
        else
        {
            (owner.CurrentToken as ITagToken).Attributes.Add(new Attribute { Name = string.Empty, Value = string.Empty });
            owner.ReconsumeCharacter(AttributeNameState.Instance);
        }
    }
}