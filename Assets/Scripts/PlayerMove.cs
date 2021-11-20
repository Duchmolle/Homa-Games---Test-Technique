using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Camera _mainCam;

    private Rigidbody _playerRb;
    private bool _hasBegan;
    private Vector3 _translatePlayerDirection;
    private Vector3 _swipeDirectionVector;
    private bool _wantToTranslate;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody>();
        _hasBegan = false;
        _wantToTranslate = false;
    }

    private void Update()
    {
        GetTouch();
        //SwipeCheck();
    }

    private void FixedUpdate()
    {
        TranslatePlayer();

        if (_hasBegan)
        {
            Vector3 velocity = new Vector3(_translatePlayerDirection.x, 0, _speed);            

            _playerRb.velocity = velocity;
        }
    }

    private void GetTouch()
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

    //private void SwipeCheck()
    //{
    //    Vector3 startTouchPosition = new Vector3(0,0,0);
    //    Vector3 endTouchPosition = new Vector3(0, 0, 0);

    //    if(Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            startTouchPosition = Input.GetTouch(0).position;
    //        }

    //        if (touch.phase == TouchPhase.Ended)
    //        {
    //            endTouchPosition = Input.GetTouch(0).position;
    //            _swipeDirectionVector = (endTouchPosition - startTouchPosition).normalized;

    //            Debug.Log(_swipeDirectionVector);

    //            if (_swipeDirectionVector.y <= 1)
    //            {
    //                _wantToTranslate = true;
    //                Debug.Log("Je Translate");
    //            }
    //        }
    //    }
    //}

    private void TranslatePlayer()
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
