using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MissCollectableTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _levelMusic;
    [SerializeField] private CinemachineVirtualCamera _virtualCam1;
    private CinemachineBasicMultiChannelPerlin _noise;

    [SerializeField] private float _timeBeforeDesactivateChorus;

    private float _timer;

    private void Start()
    {
        _levelMusic.GetComponent<AudioChorusFilter>().enabled = false;
        _noise = _virtualCam1.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _noise.m_AmplitudeGain = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            _levelMusic.GetComponent<AudioChorusFilter>().enabled = true;
            _timer = 0;
            _noise.m_AmplitudeGain = 2;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _timeBeforeDesactivateChorus)
        {
            _levelMusic.GetComponent<AudioChorusFilter>().enabled = false;
            _noise.m_AmplitudeGain = 0;
        }
    }


}
