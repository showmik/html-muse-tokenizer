namespace HtmlMuse.Tokenizer.States;

public class ScriptDataLessThanSignState : State<HtmlTokenizer>
{
    private static ScriptDataLessThanSignState? _instance;
    public static ScriptDataLessThanSignState Instance => _instance ??= new ScriptDataLessThanSignState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}