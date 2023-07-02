namespace HtmlMuse.Tokenizer.States;

public class ScriptDataDoubleEscapedDashDashState : State<HtmlTokenizer>
{
    private static ScriptDataDoubleEscapedDashDashState? _instance;
    public static ScriptDataDoubleEscapedDashDashState Instance => _instance ??= new ScriptDataDoubleEscapedDashDashState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}