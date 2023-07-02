using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class BeforeDOCTYPENameState : State<HtmlTokenizer>
{
    private static BeforeDOCTYPENameState? _instance;
    public static BeforeDOCTYPENameState Instance => _instance ??= new BeforeDOCTYPENameState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.IsWhiteSpace)
        {
            // Do Nothing: ignores the current character
        }
        else if (owner.CodePoint.IsUpperAlpha)
        {
            owner.CreateToken(new DOCTYPEToken { Name = owner.CodePoint.ToLower().ToString() });
            owner.FSM.SwitchState(DOCTYPENameState.Instance);
        }
        else if (owner.CodePoint.IsNullCharacter)
        {
            owner.CreateToken(new DOCTYPEToken { Name = '\uFFFD'.ToString() });
            owner.FSM.SwitchState(DOCTYPENameState.Instance);
        }
        else if (owner.CodePoint.Value == '>')
        {
            owner.EmitToken(new DOCTYPEToken { ForceQuirks = true });
            owner.FSM.SwitchState(DataState.Instance);
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitToken(new DOCTYPEToken { ForceQuirks = true });
            owner.EmitToken(new EOFToken());
        }
        else
        {
            owner.CreateToken(new DOCTYPEToken { Name = owner.CodePoint.Value.ToString() });
            owner.FSM.SwitchState(DOCTYPENameState.Instance);
        }
    }
}