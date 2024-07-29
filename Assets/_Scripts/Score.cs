using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _score;
    public static int gameScore;

    private void Start()
    {
        gameScore = 0;
    }

    private void Update()
    {
        _score.text = gameScore.ToString();
    }
}
