using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    GameObject memory;
    ScoreMemo scoreMemo;
    public Text text;
    public Image image1, image2, image3;
    public ScoreManager scoreManager;
    public PlayerController playerController;
    public GameObject player;
    bool inTheFinish;
    public GameObject Camera;
    public int csillag;
    



    void Start() {           
        text.enabled = false;
        image1.enabled = false;
        image2.enabled = false;
        image3.enabled = false;
        Debug.Log("This is the beginning.");
        memory = GameObject.FindGameObjectWithTag("memory");
        scoreMemo = memory.GetComponent<ScoreMemo>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject hitObj = other.gameObject;

        if (hitObj.tag == "player")
        {
            Debug.Log("This is the end.");
            playerController.speed = 0f;
            playerController.enabled = false;
            player.GetComponent<Animator>().SetTrigger("GameOver");
            text.enabled = true;
            inTheFinish = true;
            if (scoreManager.coins < 3 && scoreMemo.points1 <= 1)
            {
                image1.enabled = true;
                csillag = 1;
                scoreMemo.points1 = csillag;
            }

            if (scoreManager.coins < 3 && scoreMemo.points1 > 1)
            {
                image1.enabled = true;
                csillag = 1;
            }

            if (scoreManager.coins >= 3 && scoreManager.coins <= 5 && scoreMemo.points1 <= 2)
            {
                image1.enabled = true;
                image2.enabled = true;
                csillag = 2;
                scoreMemo.points1 = csillag;
            }

            if (scoreManager.coins >= 3 && scoreManager.coins <= 5 && scoreMemo.points1 > 2)
            {
                image1.enabled = true;
                image2.enabled = true;
                csillag = 2;
            }
            if (scoreManager.coins > 5 )
            {
                image1.enabled = true;
                image2.enabled = true;
                image3.enabled = true;
                csillag = 3;
                scoreMemo.points1 = csillag;
            }
            Camera.GetComponent<CameraController>().player = this.gameObject;
            scoreMemo.levelDone = true;
        }
    }

    void Update() {
        if (Input.GetButtonDown("Jump") && inTheFinish)
        {
            SceneManager.LoadScene(0);
        }
    }

}