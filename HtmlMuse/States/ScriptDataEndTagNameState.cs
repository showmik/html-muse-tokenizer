namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEndTagNameState : State<HtmlTokenizer>
{
    private static ScriptDataEndTagNameState? _instance;
    public static ScriptDataEndTagNameState Instance => _instance ??= new ScriptDataEndTagNameState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}