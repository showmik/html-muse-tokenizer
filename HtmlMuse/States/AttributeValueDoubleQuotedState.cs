using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States
{
    public class AttributeValueDoubleQuotedState : State<HtmlTokenizer>
    {
        private static AttributeValueDoubleQuotedState? _instance;
        public static AttributeValueDoubleQuotedState Instance => _instance ??= new AttributeValueDoubleQuotedState();

        public override void Execute(HtmlTokenizer owner)
        {
            if (owner.CodePoint.Value == '"')
            {
                owner.FSM.SwitchState(AfterAttributeValueQuotedState.Instance);
            }
            else if (owner.CodePoint.Value == '&')
            {
                owner.FSM.SwitchState(CharacterReferenceState.Instance);
            }
            else if (owner.CodePoint.IsNullCharacter)
            {
                // Parse Error: unexpected-null-character
                (owner.CurrentToken as ITagToken).Attributes.Last().Name += '\uFFFD';
            }
            else if (owner.IsAtEndOfFile)
            {
                // Parse Error: eof-in-tag
                owner.EmitToken(new EOFToken());
            }
            else
            {
                (owner.CurrentToken as ITagToken).Attributes.Last().Value += owner.CodePoint.Value;
            }
        }
    }
}