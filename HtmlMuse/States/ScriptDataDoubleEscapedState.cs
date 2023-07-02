namespace HtmlMuse.Tokenizer.States;

public class ScriptDataDoubleEscapedState : State<HtmlTokenizer>
{
    private static ScriptDataDoubleEscapedState? _instance;
    public static ScriptDataDoubleEscapedState Instance => _instance ??= new ScriptDataDoubleEscapedState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}