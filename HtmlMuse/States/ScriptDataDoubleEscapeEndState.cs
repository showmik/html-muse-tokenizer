namespace HtmlMuse.Tokenizer.States;

public class ScriptDataDoubleEscapeEndState : State<HtmlTokenizer>
{
    private static ScriptDataDoubleEscapeEndState? _instance;
    public static ScriptDataDoubleEscapeEndState Instance => _instance ??= new ScriptDataDoubleEscapeEndState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}