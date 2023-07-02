using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class DOCTYPEState : State<HtmlTokenizer>
{
    private static DOCTYPEState? _instance;
    public static DOCTYPEState Instance => _instance ??= new DOCTYPEState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.IsWhiteSpace)
        {
            owner.FSM.SwitchState(BeforeDOCTYPENameState.Instance);
        }
        else if (owner.CodePoint.Value == '>')
        {
            owner.ReconsumeCharacter(BeforeDOCTYPENameState.Instance);
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitToken(new DOCTYPEToken { ForceQuirks = true });
            owner.EmitToken(new EOFToken());
        }
        else
        {
            owner.ReconsumeCharacter(BeforeDOCTYPENameState.Instance);
        }
    }
}