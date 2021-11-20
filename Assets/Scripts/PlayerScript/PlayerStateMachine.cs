using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Movement
{
    IDLE,
    RUN,
    SING
}

public class PlayerStateMachine : MonoBehaviour
{
    private Movement _currentState;

    [SerializeField] private PlayerAnimatorController _playerAnimatorController;
    [SerializeField] private PlayerTriggerManager _playerTriggerManager;
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

            case Movement.SING:
                DoSingEnter();
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

            case Movement.SING:
                DoSingExit();
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

            case Movement.SING:
                DoSingUpdate();
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
        _playerAnimatorController.ExitRunAnimation();
    }

    private void DoRunUpdate()
    {
        if(_playerTriggerManager._haveReachTheEnd)
        {
            TransitionToState(_currentState, Movement.SING);
        }
    }

    #endregion

    #region Sing State

    private void DoSingEnter()
    {
        _playerAnimatorController.EnterSingAnimation();
    }

    private void DoSingExit()
    {
        _playerAnimatorController.ExitSingAnimation();
    }

    private void DoSingUpdate()
    {
    }

    #endregion
}
