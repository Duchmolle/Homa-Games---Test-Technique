using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreMultiplierText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _finalScoreText;
    [SerializeField] private TMP_Text _finalMultiplierText;
    [SerializeField] private SoloFeatureBehaviour _soloFeature;
    [SerializeField] protected List<Color> _colorList = new List<Color>();
    static protected int _scoreMultiplier = 1;
    static protected int _score;
    static private int _finalScore = 0;
    static bool _calculTrigger;
    private bool _trigger;

    private void Awake()
    {
        _finalScore = 0;
        _score = 0;
        _scoreMultiplier = 1;
        _calculTrigger = true;
    }

    private void Update()
    {
        _scoreMultiplierText.text = "x" + _scoreMultiplier.ToString();
        _scoreText.text = _score.ToString();

        if (_soloFeature._soloEventFinished && _calculTrigger)
        {
            _scoreMultiplier += _soloFeature._numberOfTargetsHit;
            _finalMultiplierText.text = _scoreMultiplier.ToString();
            _finalScore += _score;
            _finalScore *= _scoreMultiplier;
            _finalScoreText.text = _finalScore.ToString();
            _calculTrigger = false;
            Debug.Log(_scoreMultiplier);
        }
    }
}
