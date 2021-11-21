using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] List<AudioClip> _guitarRiff = new List<AudioClip>();
    [SerializeField] private float _comboTime;

    static float _timer;
    private AudioSource _audioSource;
    static int _increment;
    static bool _isCombo;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _audioSource.clip = _guitarRiff[0];
        _increment = 0;
        _isCombo = false;
    }

    private void SwitchAudioClip()
    {
        if(_comboTime >= _timer && _isCombo)
        {
            _audioSource.clip = _guitarRiff[_increment];
        }
        else if(_comboTime <= _timer && _isCombo)
        {
            _increment = 0;
            _audioSource.clip = _guitarRiff[0];
            _isCombo = false;
            _timer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_comboTime >= _timer && _isCombo)
        {
            _increment++;
        }
        if (other.CompareTag("Player"))
        {
            _isCombo = true;

            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(_audioSource.clip); 
                
            }
        }
    }

    private void Update()
    {
        Debug.Log(_isCombo);
        Debug.Log(_increment);
        Debug.Log(_timer);
        if(_isCombo)
        {
            SwitchAudioClip();
            _timer += Time.deltaTime;
        }
    }
}
