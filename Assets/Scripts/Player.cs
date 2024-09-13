using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    public GameObject[] metalObj;
    [SerializeField] GameObject handClosed;
    [SerializeField] GameObject handOpened;
    [SerializeField] GameObject handMoved;
    [SerializeField] GameObject nextBall;
    [SerializeField] GameObject secondNextBall;
    [SerializeField] Sprite sprite;
    public int i = -1;
    public int j = -1;

    public TMP_Text textScore;
    public int score;
    
    void Start()
    {
        if(i == -1)
        {
            i = Random.Range(0, metalObj.Length);
            j = Random.Range(0, metalObj.Length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var metalObjSpawn = metalObj[i];
        sprite = metalObjSpawn.GetComponent<SpriteRenderer>().sprite;
        nextBall.GetComponent<SpriteRenderer>().sprite = sprite;
        nextBall.transform.localScale = metalObjSpawn.GetComponent <Transform>().localScale;

        secondNextBall.GetComponent<SpriteRenderer>().sprite = metalObj[j].GetComponent<SpriteRenderer>().sprite;
        secondNextBall.transform.localScale = metalObj[j].GetComponent <Transform>().localScale;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            
            Instantiate(metalObjSpawn, transform.position, Quaternion.identity);

            /*Balls newBallScript = newMetalObjSpawn.GetComponent<Balls>();
            newBallScript.player = this;
            newBallScript.ballIndex = 0;*/

            handOpened.SetActive(true);
            handClosed.SetActive(false);
            Invoke("CloseHand", 0.2f);

            i = j;
            j = Random.Range(0, metalObj.Length);
        }

        float x = Input.GetAxisRaw("Horizontal");
        ///////////////////////////
        Vector3 nextPos = transform.position;// faire une copie

        nextPos += new Vector3(x, 0, 0) * Time.deltaTime * speed;
        nextPos.x = Mathf.Clamp(nextPos.x, 0.7f, 7.6f);
        transform.position = nextPos;
        ///////////////////////////
        /*if (transform.position.x <= 0f)
        {
            transform.position += new Vector3(Mathf.Clamp(x, 0f, 7f), 0, 0) * Time.deltaTime * speed;
        }
        else if (transform.position.x >= 7f)
        {
            transform.position -= new Vector3(Mathf.Clamp(x, 1f, 0f), 0, 0) * Time.deltaTime * speed;
        }
        else
        {
            transform.position += new Vector3(x, 0, 0) * Time.deltaTime * speed;
        }*/

    }
    /*public void SpawmBalls()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            var metalObjSpawn = metalObj[Random.Range(0, metalObj.Length)];
            Instantiate(metalObjSpawn, transform.position, Quaternion.identity);

            //Balls newBallScript = newMetalObjSpawn.GetComponent<Balls>();
            //newBallScript.player = this;
            //newBallScript.ballIndex = 0;
            
            handOpened.SetActive(true);
            handClosed.SetActive(false);
            Invoke("CloseHand", 0.2f);
        }
    }*/
    void CloseHand()
    {
        handOpened.SetActive(false);
        handClosed.SetActive(true);
    }

}
