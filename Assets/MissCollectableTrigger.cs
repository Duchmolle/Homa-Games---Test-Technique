using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MissCollectableTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _levelMusic;
    [SerializeField] private float _timeBeforeDesactivateChorus;

    [SerializeField] private CinemachineVirtualCamera _virtualCam1;
    [SerializeField] Camera _uICamera;
    [SerializeField] Color _missColor;


    private CinemachineBasicMultiChannelPerlin _noise;
    private float _timer;
    private Color _baseColor;

    public bool _hasMissed;

    private void Start()
    {
        _levelMusic.GetComponent<AudioChorusFilter>().enabled = false;
        _noise = _virtualCam1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.m_AmplitudeGain = 0;
        _baseColor = _uICamera.backgroundColor;
        _hasMissed = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            _levelMusic.GetComponent<AudioChorusFilter>().enabled = true;
            _timer = 0;
            _noise.m_AmplitudeGain = 2;
            _uICamera.backgroundColor = _missColor;
            _hasMissed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collectable"))
            _hasMissed = false;
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeBeforeDesactivateChorus)
        {
            _levelMusic.GetComponent<AudioChorusFilter>().enabled = false;
            _noise.m_AmplitudeGain = 0;
        }

        if(!_hasMissed)
        {
            _uICamera.backgroundColor = _baseColor;
        }
    }


}
