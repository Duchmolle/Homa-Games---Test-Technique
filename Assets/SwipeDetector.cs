using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 _touchEndPos;
    private Vector2 _touchStartPos;
    [SerializeField] private bool detectSwipeOnlyAfterRelease;

    [SerializeField] private float _swipeTolerance;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _touchStartPos = touch.position;
                _touchEndPos = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    _touchEndPos = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                _touchEndPos = touch.position;
                checkSwipe();
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > _swipeTolerance && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (_touchEndPos.y - _touchStartPos.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (_touchEndPos.y - _touchStartPos.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            _touchStartPos = _touchEndPos;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > _swipeTolerance && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (_touchEndPos.x - _touchStartPos.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (_touchEndPos.x - _touchStartPos.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            _touchStartPos = _touchEndPos;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(_touchEndPos.y - _touchStartPos.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(_touchEndPos.x - _touchStartPos.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
        Debug.Log("Swipe UP");
    }

    void OnSwipeDown()
    {
        Debug.Log("Swipe Down");
    }

    void OnSwipeLeft()
    {
        Debug.Log("Swipe Left");
    }

    void OnSwipeRight()
    {
        Debug.Log("Swipe Right");
    }
}
