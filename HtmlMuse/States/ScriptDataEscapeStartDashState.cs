namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEscapeStartDashState : State<HtmlTokenizer>
{
    private static ScriptDataEscapeStartDashState? _instance;
    public static ScriptDataEscapeStartDashState Instance => _instance ??= new ScriptDataEscapeStartDashState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}