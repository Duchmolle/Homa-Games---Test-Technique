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
    

    private Rigidbody _playerRb;
    public bool _hasBegan;
    private Vector3 _translatePlayerDirection;

    private Vector2 _touchEndPos;
    private Vector2 _touchStartPos;

    Vector3 _targetPosTransform;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        _hasBegan = false;
    }

    private void Update()
    {
        GetTouch();

        if(_hasBegan && !_playerTriggerManager._haveReachTheEnd)
        {
            transform.Translate(Vector3.forward * _runningSpeed * Time.deltaTime);
            Strafe();
        }
        //TranslatePlayer();

        //if(_hasBegan)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, _targetPosTransform, _speed * Time.deltaTime);
        //}
    }

    //private void FixedUpdate()
    //{

    //    if (_hasBegan)
    //    {
    //        Vector3 velocity = new Vector3(_translatePlayerDirection.x, 0, _speed);

    //        _playerRb.velocity = velocity;
    //    }
    //}

    private void GetTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _hasBegan = true;
                _touchStartPos = touch.position;
                _touchEndPos = touch.position;
            }

            ////Detects Swipe while finger is still moving
            //if (touch.phase == TouchPhase.Moved)
            //{
            //    _touchEndPos = touch.position;
            //    checkSwipe();
            //}
        }


    }

    private void checkSwipe()
    {
        if (_touchEndPos.x - _touchStartPos.x > 0) //Swipe right
        {
            //_translatePlayerDirection = _mainCam.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
        }
        else if(_touchEndPos.x - _touchStartPos.x < 0) //Swipe left
        {

        }

        _touchStartPos = _touchEndPos;
    }

    public void Strafe()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);

            if(_touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x + _touch.deltaPosition.x * _strafingSpeed * Time.deltaTime, -6, 6), 
                    transform.position.y, transform.position.z);
            }
        }
    }

    public void TranslatePlayer()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                _translatePlayerDirection = _mainCam.ScreenToWorldPoint(new Vector3(touch.position.x, 0, 10));
            }
        }
    }
}
