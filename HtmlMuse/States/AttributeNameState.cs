using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class AttributeNameState : State<HtmlTokenizer>
{
    private static AttributeNameState? _instance;
    public static AttributeNameState Instance => _instance ??= new AttributeNameState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.IsWhiteSpace || owner.CodePoint.Value == '/' || owner.CodePoint.Value == '>' || owner.IsAtEndOfFile)
        {
            owner.ReconsumeCharacter(AfterAttributeNameState.Instance);
        }
        else if (owner.CodePoint.Value == '=')
        {
            owner.FSM.SwitchState(BeforeAttributeValueState.Instance);
        }
        else if (owner.CodePoint.IsUpperAlpha)
        {
            (owner.CurrentToken as ITagToken).Attributes.Last().Name += owner.CodePoint.Value;
        }
        else if (owner.CodePoint.IsNullCharacter)
        {
            (owner.CurrentToken as ITagToken).Attributes.Last().Name += '\uFFFD';
        }
        else if (owner.CodePoint.Value == '"' || owner.CodePoint.Value == '\'' || owner.CodePoint.Value == '<')
        {
            // Parse Error: unexpected-character-in-attribute-name
            (owner.CurrentToken as ITagToken).Attributes.Last().Name += owner.CodePoint.Value;
        }
        else
        {
            (owner.CurrentToken as ITagToken).Attributes.Last().Name += owner.CodePoint.Value;
        }
    }
}