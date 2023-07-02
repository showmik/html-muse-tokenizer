using HtmlMuse.Tokenizer.Tokens;

namespace HtmlMuse.Tokenizer.States;

public class DataState : State<HtmlTokenizer>
{
    private static DataState? _instance;
    public static DataState Instance => _instance ??= new DataState();

    public override void Execute(HtmlTokenizer owner)
    {
        if (owner.CodePoint.Value == '&')
        {
            owner.FSM.SwitchState(CharacterReferenceState.Instance);
        }
        else if (owner.CodePoint.Value == '<')
        {
            owner.FSM.SwitchState(TagOpenState.Instance);
        }
        else if (owner.CodePoint.IsNullCharacter)
        {
            owner.EmitToken(new CharacterToken { Data = owner.CodePoint.Value });
        }
        else if (owner.IsAtEndOfFile)
        {
            owner.EmitToken(new EOFToken());
        }
        else
        {
            owner.EmitToken(new CharacterToken { Data = owner.CodePoint.Value });
        }
    }
}