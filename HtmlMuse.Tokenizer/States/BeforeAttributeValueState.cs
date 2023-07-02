namespace HtmlMuse.Tokenizer.States
{
    public class BeforeAttributeValueState : State<HtmlTokenizer>
    {
        private static BeforeAttributeValueState? _instance;
        public static BeforeAttributeValueState Instance => _instance ??= new BeforeAttributeValueState();

        public override void Execute(HtmlTokenizer owner)
        {
            if (owner.CodePoint.IsWhiteSpace)
            {
                // Do nothing (ignores the character)
            }
            else if (owner.CodePoint.Value == '"')
            {
                owner.FSM.SwitchState(AttributeValueDoubleQuotedState.Instance);
            }
            else if (owner.CodePoint.Value == '\'')
            {
                owner.FSM.SwitchState(AttributeValueSingleQuotedState.Instance);
            }
            else if (owner.CodePoint.Value == '>')
            {
                // Parse Error: missing-attribute-value
                owner.EmitCurrentToken();
                owner.FSM.SwitchState(DataState.Instance);
            }
            else
            {
                owner.ReconsumeCharacter(AttributeValueUnquotedState.Instance);
            }
        }
    }
}