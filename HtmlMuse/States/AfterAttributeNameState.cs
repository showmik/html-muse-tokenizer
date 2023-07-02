using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States
{
    public class AfterAttributeNameState : State<HtmlTokenizer>
    {
        private static AfterAttributeNameState? _instance;
        public static AfterAttributeNameState Instance => _instance ??= new AfterAttributeNameState();

        public override void Execute(HtmlTokenizer owner)
        {
            if (owner.CodePoint.IsWhiteSpace)
            {
                // Do nothing (ignores the character)
            }
            else if (owner.CodePoint.Value == '/')
            {
                owner.FSM.SwitchState(SelfClosingStartTagState.Instance);
            }
            else if (owner.CodePoint.Value == '=')
            {
                owner.FSM.SwitchState(BeforeAttributeValueState.Instance);
            }
            else if (owner.CodePoint.Value == '>')
            {
                owner.EmitCurrentToken();
                owner.FSM.SwitchState(DataState.Instance);
            }
            else if (owner.IsAtEndOfFile)
            {
                // Parse Error: eof-in-tag
                owner.EmitToken(new EOFToken());
            }
            else
            {
                (owner.CurrentToken as ITagToken).Attributes.Add(new Attribute { Name = string.Empty, Value = string.Empty });
                owner.ReconsumeCharacter(AttributeNameState.Instance);
            }
        }
    }
}