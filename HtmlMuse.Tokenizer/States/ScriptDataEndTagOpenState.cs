namespace HtmlMuse.Tokenizer.States;

public class ScriptDataEndTagOpenState : State<HtmlTokenizer>
{
    private static ScriptDataEndTagOpenState? _instance;
    public static ScriptDataEndTagOpenState Instance => _instance ??= new ScriptDataEndTagOpenState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}