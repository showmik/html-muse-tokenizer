namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEscapedDashState : State<HtmlTokenizer>
{
    private static ScriptDataEscapedDashState? _instance;
    public static ScriptDataEscapedDashState Instance => _instance ??= new ScriptDataEscapedDashState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}