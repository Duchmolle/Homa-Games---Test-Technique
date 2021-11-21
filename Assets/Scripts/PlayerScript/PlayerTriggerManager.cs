using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTriggerManager : ScoreManager
{
    [SerializeField] Camera _uICamera;
    [SerializeField] Color _validationColor;
    [SerializeField] GameObject _particleEffect;
    [SerializeField] GameObject _bonusParticleEffect;
    [SerializeField] GameObject _malusParticleEffect;
    [SerializeField] PlaySound _playSound;
    [SerializeField] public GameObject _bonusSpotLights;
    [SerializeField] private GameObject _malusArrow;
    [SerializeField] private TMP_Text _bonusText;
    [SerializeField] private Transform _playerGFXTransform;

    public bool _haveReachTheEnd = false;
    public bool _haveBadPress = false;
    public bool _isDancing = false;

    private void Start()
    {
        _bonusSpotLights.SetActive(false);
        _malusArrow.SetActive(false);
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
                Instantiate(_malusParticleEffect, other.transform, false);
                _haveBadPress = true;
                _bonusText.gameObject.SetActive(true);
                _bonusText.text = "BAD PRESS !!";
                _bonusText.color = Color.red;
                if(_scoreMultiplier >= 2)
                {
                    _scoreMultiplier--;
                }
                _malusArrow.SetActive(true);
                other.GetComponent<AudioSource>().Play();
                StartCoroutine(MalusEffectDesactivationCoroutine());
                break;

            case "SickMove":
                Instantiate(_bonusParticleEffect, other.transform, false);
                _isDancing = true;
                _bonusText.gameObject.SetActive(true);
                _bonusText.text = "SICK DANCE MOVE !!";
                _bonusText.color = Color.green;
                _scoreMultiplier++;
                _bonusSpotLights.SetActive(true);
                other.GetComponent<AudioSource>().Play();
                StartCoroutine(BonusEffectDesactivationCoroutine());
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

    IEnumerator BonusEffectDesactivationCoroutine()
    {
        yield return new WaitForSeconds(4);
        _bonusSpotLights.SetActive(false);
        _bonusText.gameObject.SetActive(false);
        _isDancing = false;
        _playerGFXTransform.localPosition = Vector3.zero;
    }

    IEnumerator MalusEffectDesactivationCoroutine()
    {
        yield return new WaitForSeconds(4);
        _malusArrow.SetActive(false);
        _bonusText.gameObject.SetActive(false);
        _haveBadPress = false;
        _playerGFXTransform.localPosition = Vector3.zero;
    }
}
