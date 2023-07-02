namespace HtmlMuse.Tokenizer.States;

public class ScriptDataState : State<HtmlTokenizer>
{
    private static ScriptDataState? _instance;
    public static ScriptDataState Instance => _instance ??= new ScriptDataState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}