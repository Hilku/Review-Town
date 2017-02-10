using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float enemySpeed;
    Animator enemyAnimator;
   // public GameObject enemyGraphic;

    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 3f;
    float nextFlipChance = 0f;

    public float chargeTime;
    float startChargeTime;
    bool charging;
    Rigidbody2D enemyBody;

	// Use this for initialization
	void Start () {
        enemyAnimator = GetComponent<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextFlipChance)
        {
            if (Random.Range(3, 10)>=5) {
                flipFacing();
            }
            nextFlipChance = Time.time + flipTime;
        }
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == ("player")) {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                flipFacing();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x) {
                flipFacing();
            }
            canFlip = false;
            charging = true;
            startChargeTime = Time.time + chargeTime;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "player")
        {
            if (startChargeTime >= Time.time)
            {
                if (!facingRight)
                {
                    enemyBody.AddForce(new Vector2(-1, 0) * enemySpeed);
                }
                else
                {
                    enemyBody.AddForce(new Vector2(1, 0) * enemySpeed);
                }
                //enemyAnimator.SetBool("isCharging", charging);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "player") {
            canFlip = true;
            charging = false;
            enemyBody.velocity = new Vector2(0f, 0f);
           // enemyAnimator.SetBool("isCharging", charging);
        }
    }

    void flipFacing() {
        if (!canFlip)
        {
            return;
        }
        float facingX = this.transform.localScale.x;
        facingX *= -1f;
        this.transform.localScale = new Vector3(facingX, this.transform.localScale.y, this.transform.localScale.z);
        facingRight = !facingRight;

    }

}
