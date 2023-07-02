namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEscapedState : State<HtmlTokenizer>
{
    private static ScriptDataEscapedState? _instance;
    public static ScriptDataEscapedState Instance => _instance ??= new ScriptDataEscapedState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}