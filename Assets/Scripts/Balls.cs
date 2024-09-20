using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Balls : MonoBehaviour
{
    public int ballIndex;
    /*public Player player;
    public GameObject nextBall;
    [SerializeField] int scorePoint;*/
    bool isFusioning;

    [SerializeField] AudioSource collideSound;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isFusioning)
        {
            Destroy(gameObject);
            return;
        }
        var otherBall = collision.gameObject.GetComponent<Balls>();
        collideSound.Play();
        if (otherBall != null)
        {
            /*Debug.Log($"{gameObject.name} collide with {collision.gameObject.name}");
            if (!gameObject.activeSelf || !collision.gameObject.activeSelf)
                return;*/

            if (otherBall.ballIndex == ballIndex && ballIndex < 4)
            {   
                isFusioning = true;
                otherBall.isFusioning = true;

                int score = 0;

                switch (ballIndex)
                {
                    default:
                        break;
                    case 0: // Cole
                        score = 25;
                        break;
                    case 1: // Copper
                        score = 50;
                        break;
                    case 2: // Silver
                        score = 100;
                        break;
                    case 3: // Gold
                        score = 200;
                        break;
                    case 4: // Cobalt
                        score = 400;
                        break;
                }

                FindAnyObjectByType<Score>().AddScore(score);

                Vector3 contactPoint = (transform.position + otherBall.transform.position) / 2;

                FindAnyObjectByType<Player>().SpawnBall(ballIndex + 1, contactPoint);
                Destroy(gameObject);
                return;
                /* Méthode sans Index
                if (nextBall != null)
                {
                    collision.gameObject.SetActive(false);
                    Destroy(otherBall.gameObject);
                    Debug.Log("!!! FUSION !!!");
                    //GameObject nextBall = Instantiate(player.metalObj[1]);
                    //nextBall.transform.position = transform.position;
                    //Debug.Log($"Next ball is {FindAnyObjectByType<Balls>().name[ballIndex++]}");
                    Player player = FindFirstObjectByType<Player>();
                    player.score = player.score + scorePoint;
                    player.textScore.text = $"{player.score}";
                    Instantiate(nextBall, transform.position, Quaternion.identity);

                    gameObject.SetActive(false);
                    Destroy(gameObject);
                }*/
            }
        }

        /*if(collision.transform.gameObject.name == this.gameObject.name)
        {
            Debug.Log("Contact !");
        }*/
    }
}
