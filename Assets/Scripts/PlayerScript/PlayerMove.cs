using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _runningSpeed;
    [SerializeField] private float _strafingSpeed;
    [SerializeField] private Camera _mainCam;
    [SerializeField] private PlayerTriggerManager _playerTriggerManager;

    private Touch _touch;
    public bool _hasBegan;

    private void Awake()
    {
        _hasBegan = false;
    }

    private void Update()
    {
        GetFirstTouch();

        if(_hasBegan && !_playerTriggerManager._haveReachTheEnd)
        {
            transform.Translate(Vector3.forward * _runningSpeed * Time.deltaTime);
            Strafe();
        }
    }
    private void Strafe()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x +
                    _touch.deltaPosition.x * _strafingSpeed * Time.deltaTime, -6, 6),
                    transform.position.y, transform.position.z);
            }
        }
    }

    private void GetFirstTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _hasBegan = true;
            }
        }


    }
}
