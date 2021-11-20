using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static public int _scoreMultiplier;

    [SerializeField] PlayerCollect _playerCollect;

    private void Update()
    {
        Debug.Log(_scoreMultiplier);
    }
}
