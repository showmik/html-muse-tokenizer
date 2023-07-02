using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class DOCTYPENameState : State<HtmlTokenizer>
{
    private static DOCTYPENameState? _instance;
    public static DOCTYPENameState Instance => _instance ??= new DOCTYPENameState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.IsWhiteSpace)
        {
            owner.FSM.SwitchState(AfterDOCTYPENameState.Instance);
        }
        else if (owner.CodePoint.Value == '>')
        {
            owner.EmitCurrentToken();
            owner.FSM.SwitchState(DataState.Instance);
        }
        else if (owner.CodePoint.IsUpperAlpha)
        {
            (owner.CurrentToken as DOCTYPEToken).Name += owner.CodePoint.ToLower();
        }
        else if (owner.CodePoint.IsNullCharacter)
        {
            (owner.CurrentToken as DOCTYPEToken).Name += '\uFFFD';
        }
        else if (owner.IsAtEndOfFile)
        {
            (owner.CurrentToken as DOCTYPEToken).ForceQuirks = true;
            owner.EmitCurrentToken();
            owner.EmitToken(new EOFToken());
        }
        else
        {
            (owner.CurrentToken as DOCTYPEToken).Name += owner.CodePoint.Value;
        }
    }
}