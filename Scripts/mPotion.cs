using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mPotion : MonoBehaviour
{

    public int mAmount;
    PlayerController playerController;

    // Use this for initialization
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            if (playerController.Mana + mAmount > playerController.maxMana && playerController.Mana != playerController.maxMana)
            {
                playerController.Mana = playerController.maxMana;
                Destroy(this.gameObject);
            }
            if (playerController.Mana + mAmount < playerController.maxMana)
            {
                 playerController.Mana += mAmount;
                 Destroy(this.gameObject);
            }
            
        }
    }

}
