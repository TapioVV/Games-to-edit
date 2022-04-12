using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    public StateMachine cycleStateMachine;
    public DayState dayState;
    public BuyState buyState;
    public NightState nightState;

    private void Start()
    {
        cycleStateMachine = new StateMachine();

        dayState = new DayState(this, cycleStateMachine);
        buyState = new BuyState(this, cycleStateMachine);
        nightState = new NightState(this, cycleStateMachine);

        cycleStateMachine.Initialize(dayState);
    }

    private void Update()
    {
        cycleStateMachine.CurrentState.HandleInput();
        cycleStateMachine.CurrentState.LogicUpdate();
    }
}

