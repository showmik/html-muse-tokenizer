namespace HtmlMuse.Tokenizer.States;

public class CharacterReferenceState : State<HtmlTokenizer>
{
    private static CharacterReferenceState? _instance;
    public static CharacterReferenceState Instance => _instance ??= new CharacterReferenceState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}