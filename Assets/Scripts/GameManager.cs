using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerTriggerManager _playerTriggerManager;
    [SerializeField] CinemachineVirtualCamera _vCam1;
    [SerializeField] CinemachineVirtualCamera _vCam2;
    [SerializeField] SoloFeatureBehaviour _soloFeature;
    [SerializeField] int _numberOfTargetToSpawn;
    [SerializeField] GameObject _pauseMenu;


    private void Start()
    {
        _vCam1.gameObject.SetActive(true);
        _vCam2.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(_playerTriggerManager._haveReachTheEnd)
        {
            _vCam1.gameObject.SetActive(false);
            _vCam2.gameObject.SetActive(true);
            _soloFeature.SoloTime(_numberOfTargetToSpawn);
        }
    }

    public void PauseMenu()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ExitPauseMenu()
    {

    }
}
