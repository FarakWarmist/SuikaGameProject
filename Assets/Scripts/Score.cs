using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score;

    [SerializeField] TMP_Text textScore;

    public void AddScore(int value)
    {
        score += value;
        textScore.text = score.ToString();
    }
}
