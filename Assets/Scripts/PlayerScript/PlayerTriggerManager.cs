using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerManager : ScoreManager
{
    [SerializeField] Camera _uICamera;
    [SerializeField] Color _validationColor;
    [SerializeField] GameObject _particleEffect;

    public bool _haveReachTheEnd;

    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "EndZone":
                Debug.Log("Dans le switch");
                _haveReachTheEnd = true;
                break;

            case "MusicNote":
                Instantiate(_particleEffect, other.transform, false);
                _uICamera.backgroundColor = _validationColor;
                _score += 20;
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
}
