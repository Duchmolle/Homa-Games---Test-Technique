using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerManager : ScoreManager
{
    [SerializeField] Camera _uICamera;
    [SerializeField] Color _validationColor;
    [SerializeField] GameObject _particleEffect;
    [SerializeField] PlaySound _playSound;
    [SerializeField] public GameObject _bonusSpotLights;

    public bool _haveReachTheEnd = false;
    public bool _haveBadPress = false;
    public bool _isDancing = false;

    private void Start()
    {
        _bonusSpotLights.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "EndZone":
                _haveReachTheEnd = true;
                _uICamera.gameObject.SetActive(false);
                break;

            case "MusicNote":
                Instantiate(_particleEffect, other.transform, false);
                _uICamera.backgroundColor = _validationColor;
                _score += 20;
                break;

            case "BadPress":
                _haveBadPress = true;
                if(_scoreMultiplier >= 2)
                {
                    _scoreMultiplier--;
                }
                other.GetComponent<AudioSource>().Play();
                break;

            case "SickMove":
                _isDancing = true;
                _scoreMultiplier++;
                _bonusSpotLights.SetActive(true);
                other.GetComponent<AudioSource>().Play();
                StartCoroutine(SpotLightDesactivationCoroutine());
                break;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "MusicNote":
                other.gameObject.SetActive(false);
                break;

        }
    }

    IEnumerator SpotLightDesactivationCoroutine()
    {
        yield return new WaitForSeconds(4);
        _bonusSpotLights.SetActive(false);
    }
}
