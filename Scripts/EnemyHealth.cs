using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    public int eHealth;
    public int emaxHealth = 10;
    //SwordAttack attacked;
    int damaged = 1;
    Animator eAnim;
    PlayerController playerController;
    EnemyController enemyMovement;
    float timer;
    public float damagedTimer;
    public bool damageable;
    
    // Use this for initialization
    void Start() {
        this.eHealth = emaxHealth;        
        eAnim = GetComponentInParent<Animator>();
        //attacked = GameObject.FindGameObjectWithTag("Weapon").GetComponent<SwordAttack>();
        playerController = GameObject.FindGameObjectWithTag("player").GetComponent <PlayerController>();
        enemyMovement = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update() {

        damaged = playerController.damage;
        timer = timer + Time.deltaTime;
        damageable = timer >= damagedTimer;
        if (eHealth < 1)
        {
            isDead();
        }
    }

   void isDead() {
        //enemyMovement.enabled = false;
        eAnim.SetTrigger("dead");
        Destroy (transform.parent.gameObject, 1f);  //1f kesleltetes
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Weapon" && damageable)
        {
            TakeDamage();
        }
    }

    void TakeDamage ()
    {
        this.eHealth = (this.eHealth - damaged);
        JustDamaged();
    }

    void JustDamaged()
    {
        timer = 0f;
        GetComponentInParent<Animator>().SetTrigger("damaged");        
    }
}
