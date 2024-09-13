using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketLimit : MonoBehaviour
{
    public float timeInside = 2;
    public float timeBeforeGO = 10;
    public bool timerActive = false;
    void Update()
    {
        if (timeBeforeGO > 0)
        {
            //Debug.Log($"Time inside : {timeInside} || Time before GameOver : {timeBeforeGO}");
        }
        else
        {
            //Debug.Log("!!! GAME OVER !!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<Balls>();

        if (collision != null)
        {
            timerActive = true;
            Debug.Log("Entrer");
            if (timeInside > 0)
            {
                timeInside -= Time.deltaTime;
            }
            else if (timeInside <= 0)
            {
                timeBeforeGO -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<Balls>();
            
        
        if (ball != null && !timerActive)
        {
            timeInside = 2;
            timeBeforeGO = 10;
        }


    }
}
