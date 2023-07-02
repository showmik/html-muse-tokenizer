namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEscapedEndTagNameState : State<HtmlTokenizer>
{
    private static ScriptDataEscapedEndTagNameState? _instance;
    public static ScriptDataEscapedEndTagNameState Instance => _instance ??= new ScriptDataEscapedEndTagNameState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}