using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float speed;
    Rigidbody2D body;
    public GameObject player;
    public int bulletDmg;
    
	void Start () {        
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("player");
        if (player.GetComponent<PlayerController>().m_FacingRight == false)
            speed = -speed;
	}
	
	void Update () {
        body.velocity = new Vector2(speed, body.velocity.y);
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "enemyHp")
        {
            Debug.Log("eltaláltalak");
            other.GetComponent <EnemyHealth>().eHealth -=  bulletDmg;
                Destroy(gameObject);            
        }
        if (other.tag == "enemy")
        {
            Debug.Log("eltaliztalak");
            other.GetComponent<EnemyHealth2>().eHealth -= bulletDmg;
            Destroy(gameObject);
        }
        if (other.gameObject.layer == 0)
            Destroy(gameObject);
    }
}
