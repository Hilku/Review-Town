using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour {

    Collider2D coll;
    Transform PlayerDetector, PlayerDetector2, PlayerDetector3, steps;
    public bool PlayerIsOn = false;
    public LayerMask mask;

	// Use this for initialization
	void Start () {
        coll = this.gameObject.GetComponent<Collider2D>();
        PlayerDetector = GameObject.Find(this.name + "PlayerDetector").transform;
        PlayerDetector2 = GameObject.Find(this.name + "PlayerDetector2").transform;
        PlayerDetector3 = GameObject.Find(this.name + "PlayerDetector3").transform;
        steps = this.gameObject.transform;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "player") {
            //this.gameObject.GetComponent<Collider2D>().enabled = false;
            coll.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "player") {
            coll.enabled = true;
        }
    }

	// Update is called once per frame
	void Update () {
        PlayerIsOn = Physics2D.Linecast(steps.position, PlayerDetector.position, mask) || Physics2D.Linecast(steps.position, PlayerDetector2.position, mask) || Physics2D.Linecast(steps.position, PlayerDetector3.position, mask);

        if (PlayerIsOn && Input.GetKeyDown("down") || PlayerIsOn && Input.GetKeyDown ("s")) {
            coll.enabled = false;
        }
    }
}
