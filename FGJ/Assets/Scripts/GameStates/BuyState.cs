using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyState : State
{
    public BuyState(Cycle cycle, StateMachine stateMachine) : base(cycle, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

    }

    public override void Exit()
    {
        base.Exit();

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
            stateMachine.ChangeState(cycle.nightState);
        }
    }
}
