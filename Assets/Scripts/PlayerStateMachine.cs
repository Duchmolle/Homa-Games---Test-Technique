using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Movement
{
    IDLE,
    RUN
}

public class PlayerStateMachine : MonoBehaviour
{
    private Movement _currentState;

    [SerializeField] private PlayerAnimatorController _playerAnimatorController;
    private PlayerMove _playerMove;

    private void Awake()
    {
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Update()
    {
        OnStateUpdate(_currentState);
    }

    #region State Machine

    private void OnStateEnter(Movement state)
    {
        switch (state)
        {
            case Movement.IDLE:
                DoIdleEnter();
                break;

            case Movement.RUN:
                DoRunEnter();
                break;
        }
    }

    private void OnStateExit(Movement state)
    {
        switch (state)
        {
            case Movement.IDLE:
                DoIdleExit();
                break;

            case Movement.RUN:
                DoRunExit();
                break;
        }
    }

    private void OnStateUpdate(Movement state)
    {
        switch (state)
        {
            case Movement.IDLE:
                DoIdleUpdate();
                break;

            case Movement.RUN:
                DoRunUpdate();
                break;
        }
    }

    private void TransitionToState(Movement fromState, Movement toState)
    {
        OnStateExit(fromState);
        _currentState = toState;
        OnStateEnter(toState);
    }


    #endregion

    #region Idle State

    private void DoIdleEnter()
    {
        _playerAnimatorController.EnterIdleAnimation();
    }

    private void DoIdleExit()
    {
        _playerAnimatorController.ExitIdleAnimation();
    }

    private void DoIdleUpdate()
    {
        if (_playerMove._hasBegan)
        {
            TransitionToState(_currentState, Movement.RUN);
        }
    }

    #endregion

    #region Run State

    private void DoRunEnter()
    {
        _playerAnimatorController.EnterRunAnimation();
    }

    private void DoRunExit()
    {
        _playerAnimatorController.ExitIdleAnimation();
    }

    private void DoRunUpdate()
    {
    }

    #endregion
}
