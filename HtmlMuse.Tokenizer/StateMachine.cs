namespace HtmlMuse;

public class StateMachine<T>
{
    protected T _owner;
    protected State<T>? CurrentState { get; set; }
    protected State<T>? PreviousState { get; set; }

    public StateMachine(T owner)
    {
        _owner = owner;
    }

    public void SetCurrentState(State<T> state) => CurrentState = state;

    public void SetPreviousState(State<T> state) => PreviousState = state;

    public void Run()
    {
        CurrentState?.Execute(_owner);
    }

    public void SwitchState(State<T> newState)
    {
        PreviousState = CurrentState;
        CurrentState = newState;
    }

    public void RevertToPreviousState()
    {
        if (PreviousState != null) { SwitchState(PreviousState); }
    }
}