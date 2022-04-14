using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cycle : MonoBehaviour
{
    public StateMachine cycleStateMachine;
    public DayState dayState;
    public BuyState buyState;
    public NightState nightState;
    public MainMenuState mainMenuState;
    [SerializeField] TMP_Text stateText;

    public SpriteRenderer backGroundSpriteRenderer;
    public Sprite backGroundSpriteDay;
    public Sprite backGroundSpriteNight;
    public GameObject mainMenuObject;

    public void StartGame()
    {
        cycleStateMachine.ChangeState(dayState);
    }

    private void Start()
    {
        cycleStateMachine = new StateMachine();

        dayState = new DayState(this, cycleStateMachine);
        buyState = new BuyState(this, cycleStateMachine);
        nightState = new NightState(this, cycleStateMachine);
        mainMenuState = new MainMenuState(this, cycleStateMachine);

        cycleStateMachine.Initialize(mainMenuState);
    }

    private void Update()
    {
        cycleStateMachine.CurrentState.HandleInput();
        cycleStateMachine.CurrentState.LogicUpdate();

        stateText.text = cycleStateMachine.CurrentState.ToString();
    }
}

