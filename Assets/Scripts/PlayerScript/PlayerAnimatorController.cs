using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private int _isIdleId = Animator.StringToHash("isIdle");
    private int _isRunningId = Animator.StringToHash("isRunning");

    private Animator _playerAnimator;

    private void Awake()
    {
        _playerAnimator = GetComponent<Animator>();
    }

    #region Idle Animation

    public void EnterIdleAnimation()
    {
        _playerAnimator.SetBool(_isIdleId, true);
    }

    public void ExitIdleAnimation()
    {
        _playerAnimator.SetBool(_isIdleId, false);
    }

    #endregion

    #region Run Animation

    public void EnterRunAnimation()
    {
        _playerAnimator.SetBool(_isRunningId, true);
    }

    public void ExitRunAnimation()
    {
        _playerAnimator.SetBool(_isRunningId, false);
    }

    #endregion
}
