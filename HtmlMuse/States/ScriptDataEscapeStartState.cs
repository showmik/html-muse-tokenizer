namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEscapeStartState : State<HtmlTokenizer>
{
    private static ScriptDataEscapeStartState? _instance;
    public static ScriptDataEscapeStartState Instance => _instance ??= new ScriptDataEscapeStartState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}