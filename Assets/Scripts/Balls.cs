using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public int ballIndex;
    //public Player player;
    public GameObject nextBall;
    [SerializeField] int scorePoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherBall = collision.gameObject.GetComponent<Balls>();

        if (otherBall != null)
        {
            //Debug.Log($"{gameObject.name} collide with {collision.gameObject.name}");
            if (!gameObject.activeSelf || !collision.gameObject.activeSelf)
                return;

            if (otherBall.ballIndex == ballIndex)
            {   
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
                }
            }
        }

        /*if(collision.transform.gameObject.name == this.gameObject.name)
        {
            Debug.Log("Contact !");
        }*/
    }
}
