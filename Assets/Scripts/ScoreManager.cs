using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreMultiplierText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] protected List<Color> _colorList = new List<Color>();
    static protected int _scoreMultiplier = 1;
    static protected int _score;

    private void Update()
    {
        _scoreMultiplierText.text = "x" + _scoreMultiplier.ToString();
        _scoreText.text = _score.ToString();
    }

    public void PauseMenu()
    {

    }
}
