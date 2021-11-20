using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static protected int _scoreMultiplier;
    static protected int _score;

    private void Update()
    {
        Debug.Log(_score);
    }
}
