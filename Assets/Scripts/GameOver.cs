using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<Balls>();
        if (ball != null)
        {
            FindAnyObjectByType<Player>().GameOver();
        }
    }
}
