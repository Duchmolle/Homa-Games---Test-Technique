using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : ScoreManager
{
    [SerializeField] Camera _uICamera;
    [SerializeField] Color _validationColor;
    [SerializeField] GameObject _particleEffect;

    public bool _haveCollectItem = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Instantiate(_particleEffect, other.transform, false);
            _uICamera.backgroundColor = _validationColor;
            _scoreMultiplier++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Collectable"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
