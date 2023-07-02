namespace HtmlMuse.Tokenizer.States;

public class ScriptDataDoubleEscapeStartState : State<HtmlTokenizer>
{
    private static ScriptDataDoubleEscapeStartState? _instance;
    public static ScriptDataDoubleEscapeStartState Instance => _instance ??= new ScriptDataDoubleEscapeStartState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}