using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightState : State
{
    public NightState(Cycle cycle, StateMachine stateMachine) : base(cycle, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        cycle.backGroundSpriteRenderer.sprite = cycle.backGroundSpriteNight;
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
            stateMachine.ChangeState(cycle.dayState);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            stateMachine.ChangeState(cycle.mainMenuState);
        }
    }
}
