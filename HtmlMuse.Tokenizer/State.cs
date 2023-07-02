namespace HtmlMuse;

public abstract class State<T>
{
    public abstract void Execute(T owner);
}