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
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] int _numberOfTargetToSpawn;
    [SerializeField] GameObject _endGameCanvas;
    [SerializeField] GameObject _gameStartCanvas;
    [SerializeField] GameObject _scoreCounterPanel;
    [SerializeField] GameObject _soloPanel;


    private void Start()
    {
        _gameStartCanvas.SetActive(true);
        _vCam1.gameObject.SetActive(true);
        _vCam2.gameObject.SetActive(false);
        _endGameCanvas.SetActive(false);
        _soloPanel.SetActive(false);
    }

    private void Update()
    {
        if(!_playerMove._hasBegan)
        {
            _gameStartCanvas.SetActive(true);
        }
        else
        {
            _gameStartCanvas.SetActive(false);
        }
        if(_playerTriggerManager._haveReachTheEnd)
        {
            _vCam1.gameObject.SetActive(false);
            _vCam2.gameObject.SetActive(true);
            _soloFeature.SoloTime(_numberOfTargetToSpawn);

            if(!_soloFeature._firstTargetSwpaning)
            {
                _soloPanel.SetActive(true);
            }
        }

        if(_soloFeature._firstTargetSwpaning)
        {
            _soloPanel.SetActive(false);
        }

        if(_soloFeature._soloEventFinished)
        {
            _endGameCanvas.SetActive(true);
        }
    }

    IEnumerator SoloPanelDesactivationCoroutine()
    {
        yield return new WaitForSeconds(5);
        _soloPanel.SetActive(false);
    }
}
