namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEscapedLessThanSignState : State<HtmlTokenizer>
{
    private static ScriptDataEscapedLessThanSignState? _instance;
    public static ScriptDataEscapedLessThanSignState Instance => _instance ??= new ScriptDataEscapedLessThanSignState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}