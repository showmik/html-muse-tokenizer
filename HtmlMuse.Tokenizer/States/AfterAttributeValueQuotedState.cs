using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States
{
    public class AfterAttributeValueQuotedState : State<HtmlTokenizer>
    {
        private static AfterAttributeValueQuotedState? _instance;
        public static AfterAttributeValueQuotedState Instance => _instance ??= new AfterAttributeValueQuotedState();

        public override void Execute(HtmlTokenizer owner)
        {
            if (owner.CodePoint.IsWhiteSpace)
            {
                owner.FSM.SwitchState(BeforeAttributeNameState.Instance);
            }
            else if (owner.CodePoint.Value == '/')
            {
                owner.FSM.SwitchState(SelfClosingStartTagState.Instance);
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
                // Parse Error: missing-whitespace-between-attributes
                owner.ReconsumeCharacter(BeforeAttributeNameState.Instance);
            }
        }
    }
}