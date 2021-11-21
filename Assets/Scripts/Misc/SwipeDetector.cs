using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 _touchEndPos;
    private Vector2 _touchStartPos;
    [SerializeField] private bool _detectSwipeOnlyAfterRelease;

    [SerializeField] private float _swipeTolerance;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _touchStartPos = touch.position;
                _touchEndPos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (!_detectSwipeOnlyAfterRelease)
                {
                    _touchEndPos = touch.position;
                    checkSwipe();
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                _touchEndPos = touch.position;
                checkSwipe();
            }
        }
    }

    private void checkSwipe()
    {
        if (verticalMove() > _swipeTolerance && verticalMove() > horizontalValMove())
        {
            if (_touchEndPos.y - _touchStartPos.y > 0)
            {
                Debug.Log("Swipe UP");
            }
            else if (_touchEndPos.y - _touchStartPos.y < 0)
            {
                Debug.Log("Swipe Down");
            }
            _touchStartPos = _touchEndPos;
        }
        else if (horizontalValMove() > _swipeTolerance && horizontalValMove() > verticalMove())
        {
            if (_touchEndPos.x - _touchStartPos.x > 0)
            {
                Debug.Log("Swipe Right");
            }
            else if (_touchEndPos.x - _touchStartPos.x < 0)
            {
                Debug.Log("Swipe Left");
            }
            _touchStartPos = _touchEndPos;
        }
    }

    private float verticalMove()
    {
        return Mathf.Abs(_touchEndPos.y - _touchStartPos.y);
    }

    private float horizontalValMove()
    {
        return Mathf.Abs(_touchEndPos.x - _touchStartPos.x);
    }
}
