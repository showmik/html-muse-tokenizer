namespace HtmlMuse.Tokenizer.States;

public class AfterDOCTYPENameState : State<HtmlTokenizer>
{
    private static AfterDOCTYPENameState? _instance;
    public static AfterDOCTYPENameState Instance => _instance ??= new AfterDOCTYPENameState();

    public override void Execute(HtmlTokenizer owner)
    {
        throw new NotImplementedException();
    }
}