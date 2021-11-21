using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private int _isIdleId = Animator.StringToHash("isIdle");
    private int _isRunningId = Animator.StringToHash("isRunning");
    private int _isSingingId = Animator.StringToHash("isSinging");
    private int _haveBadPressId = Animator.StringToHash("haveBadPress");
    private int _haveDanceId = Animator.StringToHash("isDancing");

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

    #region Sing Animation

    public void EnterSingAnimation()
    {
        _playerAnimator.SetBool(_isSingingId, true);
    }

    public void ExitSingAnimation()
    {
        _playerAnimator.SetBool(_isSingingId, false);
    }

    #endregion

    #region BadPress Animation

    public void EnterBadPressAnimation()
    {
        _playerAnimator.SetTrigger(_haveBadPressId);
    }

    public void ExitBadPressAnimation()
    {
        _playerAnimator.ResetTrigger(_haveBadPressId);
    }

    #endregion

    #region Dance Animation

    public void EnterDanceAnimation()
    {
        _playerAnimator.SetTrigger(_haveDanceId);
    }

    public void ExitDanceAnimation()
    {
        _playerAnimator.ResetTrigger(_haveDanceId);
    }

    #endregion
}
