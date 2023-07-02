namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEscapedDashDashState : State<HtmlTokenizer>
{
    private static ScriptDataEscapedDashDashState? _instance;
    public static ScriptDataEscapedDashDashState Instance => _instance ??= new ScriptDataEscapedDashDashState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}