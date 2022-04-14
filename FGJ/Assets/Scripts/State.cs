public abstract class State
{
    protected StateMachine stateMachine;
    protected Cycle cycle;

    protected State(Cycle cycle, StateMachine stateMachine)
    {
        this.cycle = cycle;
        this.stateMachine = stateMachine;
    }

    protected State(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual void HandleInput()
    {

    }

    public virtual void Enter()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}

