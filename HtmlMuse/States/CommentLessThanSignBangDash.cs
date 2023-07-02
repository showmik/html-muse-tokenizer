namespace HtmlMuse.Tokenizer.States
{
    public class CommentLessThanSignBangDash : State<HtmlTokenizer>
    {
        private static CommentLessThanSignBangDash? _instance;
        public static CommentLessThanSignBangDash Instance => _instance ??= new CommentLessThanSignBangDash();

        public override void Execute(HtmlTokenizer owner)
        {
            if (owner.CodePoint.Value == '-')
            {
                owner.FSM.SwitchState(CommentLessThanSignBangDashDash.Instance);
            }
            else
            {
                owner.ReconsumeCharacter(CommentState.Instance);
            }
        }
    }
}