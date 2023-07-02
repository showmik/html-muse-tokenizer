namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEscapedEndTagOpenState : State<HtmlTokenizer>
{
    private static ScriptDataEscapedEndTagOpenState? _instance;
    public static ScriptDataEscapedEndTagOpenState Instance => _instance ??= new ScriptDataEscapedEndTagOpenState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}