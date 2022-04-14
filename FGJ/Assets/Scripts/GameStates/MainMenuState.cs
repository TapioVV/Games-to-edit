using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : State
{
    public MainMenuState(Cycle cycle, StateMachine stateMachine) : base(cycle, stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        cycle.mainMenuObject.SetActive(true);
        cycle.backGroundSpriteRenderer.sprite = cycle.backGroundSpriteDay;
    }

    public override void Exit()
    {
        base.Exit();
        cycle.mainMenuObject.SetActive(false);
    }

    public override void HandleInput()
    {
        base.HandleInput();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
