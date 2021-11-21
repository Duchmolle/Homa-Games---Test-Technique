using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MissCollectableTrigger : ScoreManager //Déclenche les effets si on rate les notes
{
    [SerializeField] private GameObject _levelMusic;
    [SerializeField] private float _timeBeforeDesactivateChorus;

    [SerializeField] private CinemachineVirtualCamera _virtualCam1;
    [SerializeField] Camera _uICamera;
    [SerializeField] Color _missColor;


    private CinemachineBasicMultiChannelPerlin _noise;
    private float _timer;
    private Color _baseColor;

    private void Start()
    {
        _levelMusic.GetComponent<AudioChorusFilter>().enabled = false;
        _noise = _virtualCam1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.m_AmplitudeGain = 0;
        _baseColor = _uICamera.backgroundColor;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "MusicNote":
                _levelMusic.GetComponent<AudioChorusFilter>().enabled = true;
                _timer = 0;
                _noise.m_AmplitudeGain = 2;
                _uICamera.backgroundColor = _missColor;
                break;

        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeBeforeDesactivateChorus)
        {
            _levelMusic.GetComponent<AudioChorusFilter>().enabled = false;
            _noise.m_AmplitudeGain = 0;
            _uICamera.backgroundColor = _baseColor;
        }
    }


}
