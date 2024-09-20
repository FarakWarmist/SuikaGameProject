using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] Animator fadeToBlack;
    [SerializeField] Animator gameOverText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Balls>() != null)
        {
            fadeToBlack.SetTrigger("GameOver");
            gameOverText.SetTrigger("GameOver");
        }
    }
}
