using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States
{
    public class AttributeValueUnquotedState : State<HtmlTokenizer>
    {
        private static AttributeValueUnquotedState? _instance;
        public static AttributeValueUnquotedState Instance => _instance ??= new AttributeValueUnquotedState();

        public override void Execute(HtmlTokenizer owner)
        {
            if (owner.CodePoint.IsWhiteSpace)
            {
                owner.FSM.SwitchState(BeforeAttributeNameState.Instance);
            }
            else if (owner.CodePoint.Value == '&')
            {
                owner.FSM.SwitchState(CharacterReferenceState.Instance);
            }
            else if (owner.CodePoint.Value == '>')
            {
                owner.EmitCurrentToken();
                owner.FSM.SwitchState(DataState.Instance);
            }
            else if (owner.CodePoint.IsNullCharacter)
            {
                // Parse Error: unexpected-null-character
                (owner.CurrentToken as ITagToken).Attributes.Last().Name += '\uFFFD';
            }
            else if (owner.CodePoint.Value is '"' or '\'' or '<' or '=' or '`')
            {
                // Parse Error:  unexpected-character-in-unquoted-attribute-value parse
                (owner.CurrentToken as ITagToken).Attributes.Last().Value += owner.CodePoint.Value;
            }
            else if (owner.IsAtEndOfFile)
            {
                // Parse Error: eof-in-tag parse error
                owner.EmitToken(new EOFToken());
            }
            else
            {
                (owner.CurrentToken as ITagToken).Attributes.Last().Value += owner.CodePoint.Value;
            }
        }
    }
}