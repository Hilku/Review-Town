using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    public int maxHealth = 10;
    public int currHealth;
    public Slider healthslider;
    PlayerController controller;
    Animator pAnim;
    public bool damaged = false;
    //bool Dead;
    
     

	// Use this for initialization
	void Start ()
    {
        currHealth = maxHealth;
        controller = GetComponent<PlayerController> ();
        pAnim = GetComponent<Animator>();      
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthslider.value = currHealth;
        if (currHealth < 1) {
            playerDead();
        }
        if (damaged)
        {
            isDamaged(); 
        }
        }

    void playerDead() {
        //Dead = true;
        controller.enabled = false;
        pAnim.SetBool ("dead", true);
    }

    void isDamaged() {
       damaged = false;
        this.GetComponent<Animator>().SetTrigger("damaged");
    }
}


