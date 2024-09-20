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
    public bool click = true;

    [SerializeField] AudioSource dropAudio;
    [SerializeField] AudioSource fusionAudio;

    [SerializeField] Transform spawnOffset;

    private GameObject currentBall;

    void Start()
    {
        GrapBall();
        /*if(i == -1)
        {
            i = Random.Range(0, metalObj.Length);
            j = Random.Range(0, metalObj.Length);
        }*/

    }
    private void GrapBall()
    {
        int randomIndex = Random.Range(0, 3);
        var metalObjSpawn = metalObj[randomIndex];
        currentBall = Instantiate(metalObjSpawn, spawnOffset.position, Quaternion.identity,spawnOffset);
        currentBall.GetComponent<Collider2D>().isTrigger = true;
        click = true;
    }

    // Update is called once per frame
    void Update()
    {        
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 nextPos = transform.position;// faire une copie

        nextPos += new Vector3(x, 0, 0) * Time.deltaTime * speed;
        nextPos.x = Mathf.Clamp(nextPos.x, 0f, 8f);
        transform.position = nextPos;

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && click == true)
        {
            click = false;
            currentBall.transform.parent = null;
            currentBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            currentBall.GetComponent<Collider2D>().isTrigger = false;
            dropAudio.Play();

            handOpened.SetActive(true);
            handClosed.SetActive(false);
            Invoke("CloseHand", 0.2f);
            Invoke("GrapBall", 0.5f);
        }


    }
    void CloseHand()
    {
        handOpened.SetActive(false);
        handClosed.SetActive(true);
    }

    internal void SpawnBall(int index, Vector3 fusionPosition)
    {
        //Ne spawn rien si dépasse l'index
        if (index >= metalObj.Length)
        {
            return;
        }
        
        fusionAudio.Play();
        var fusionedBall = Instantiate(metalObj[index], fusionPosition, Quaternion.identity);
        fusionedBall.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        
    }

    internal void GameOver()
    {
        Destroy(gameObject.GetComponent<Player>());
        Debug.Log("!!! GAME OVER !!!");
    }
}
