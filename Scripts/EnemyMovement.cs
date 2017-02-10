using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour {

    public float velocity = 1f;

    public Transform sightStart;
    public Transform sightEnd;

    public LayerMask detectWhat;

    public Transform weakness;

    public bool colliding;
    public bool attacking;
    EnemyAttack enemyAttack;

    Animator anim;
    float currentVelocity;
    float timer;




    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = true;
        currentVelocity = velocity;
        enemyAttack = GetComponent<EnemyAttack>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!enemyAttack.inRange)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);

            colliding = Physics2D.Linecast(sightStart.position, sightEnd.position, detectWhat);

            if (colliding)
            {
                transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
                velocity *= -1;
            }
        }
    }
}