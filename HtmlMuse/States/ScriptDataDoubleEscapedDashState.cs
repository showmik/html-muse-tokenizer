namespace HtmlMuse.Tokenizer.States;

public class ScriptDataDoubleEscapedDashState : State<HtmlTokenizer>
{
    private static ScriptDataDoubleEscapedDashState? _instance;
    public static ScriptDataDoubleEscapedDashState Instance => _instance ??= new ScriptDataDoubleEscapedDashState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}