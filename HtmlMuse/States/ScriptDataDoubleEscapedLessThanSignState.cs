namespace HtmlMuse.Tokenizer.States;

public class ScriptDataDoubleEscapedLessThanSignState : State<HtmlTokenizer>
{
    private static ScriptDataDoubleEscapedLessThanSignState? _instance;
    public static ScriptDataDoubleEscapedLessThanSignState Instance => _instance ??= new ScriptDataDoubleEscapedLessThanSignState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}