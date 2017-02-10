using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    Text text, text2;
    public int coins;
    public int keys;

	// Use this for initialization
	void Awake () {
        text = GameObject.FindGameObjectWithTag("CoinText").GetComponent<Text>();
        text2 = GameObject.FindGameObjectWithTag("KeyText").GetComponent<Text>();

        coins = 0;
        keys = 0;
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Coins:" + coins;
        text2.text = "Keys:" + keys;
	}
}
