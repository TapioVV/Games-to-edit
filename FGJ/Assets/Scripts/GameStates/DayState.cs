using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayState : State
{
    public delegate void onDayState(bool active);
    public static event onDayState activatePlayerDelegate;

    public DayState(Cycle cycle, StateMachine stateMachine) : base(cycle, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        cycle.backGroundSpriteRenderer.sprite = cycle.backGroundSpriteDay;

        activatePlayerDelegate?.Invoke(true);
    }

    public override void Exit()
    {
        base.Exit();

        activatePlayerDelegate?.Invoke(false);
    }

    public override void HandleInput()
    {
        base.HandleInput();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(cycle.buyState);
        }
    }
}
