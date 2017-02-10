using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    
    public int eDmg;
    GameObject player;
    GameObject enemy;
    public bool inRange = false;
    float timer;
    public float timeBetweenAttacks = 1f;
    //EnemyHealth health;
    PlayerHealth playerHealth;
    Transform enemyTrans, tagRange, tagRange2, tagRange3;
    public LayerMask groundMask;
    Animator eAnim; //enemyanim


    // Use this for initialization
    void Awake() {
        
        player = GameObject.FindGameObjectWithTag("player");
        //health = GetComponent<EnemyHealth>();
        enemyTrans = this.transform;
        tagRange = GameObject.Find(this.name + "/tagRange").transform;
        tagRange2 = GameObject.Find(this.name + "/tagRange2").transform;
        //tagRange3 = GameObject.Find(this.name + "/tagRange3").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        eAnim = this.GetComponent<Animator>();

       // enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update() {
        timer += Time.deltaTime;

        inRange = Physics2D.Linecast(enemyTrans.position, tagRange.position, groundMask) || Physics2D.Linecast(enemyTrans.position, tagRange2.position, groundMask);

        if (inRange && timer >= timeBetweenAttacks)
        {
            Attack();
        }

       
    }
    

    public void Attack() {
        timer = 0f;
        eAnim.SetTrigger("attacking");       
        playerHealth.currHealth = playerHealth.currHealth - eDmg;
        playerHealth.damaged= true;               
    }
}

