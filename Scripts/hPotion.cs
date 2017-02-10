using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hPotion : MonoBehaviour {

    public int amount;
    PlayerHealth playerHealth;

    // Use this for initialization
    void Start() {
        playerHealth = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerHealth>();
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            if (playerHealth.currHealth + amount > playerHealth.maxHealth && playerHealth.currHealth != playerHealth.maxHealth || playerHealth.currHealth + amount == playerHealth.maxHealth)
            {
                playerHealth.currHealth = playerHealth.maxHealth;
                Destroy(this.gameObject);
            }
            if (playerHealth.currHealth + amount < playerHealth.maxHealth)
            {
                playerHealth.currHealth += amount;
                Destroy(this.gameObject);
            }
           // if (playerHealth.currHealth + amount == playerHealth.maxHealth)
            //{
            //}          
        }
    }

}
