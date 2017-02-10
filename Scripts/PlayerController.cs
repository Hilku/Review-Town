using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpVelocity;
    public LayerMask playerMask;
    public bool canMoveInAir = true;
    Transform myTrans, tagGround, tagGround2, tagGround3;
    Rigidbody2D myBody;
    public bool isGrounded = false;
    float hInput = 0;
    float vInput = 0;
    public bool OnLadder = false;
    public bool m_FacingRight;
    public int damage;
    GameObject weapon;
    Animator weaponanim;
    ScoreManager scoreManager;
    GameObject FirePoint;
    Animator spellAnim;
    public int maxMana;
    public int Mana;
    public Slider manaSlider;
    public Text NotEnough;
    float ManaTimer = 0f;
    public float TimeBetweenCast;
    float castTimer = 0f;
    public Transform firePoint;
    public GameObject fireball;
    Animator playerAnim;

    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myTrans = this.transform;
        tagGround = GameObject.Find(this.name + "/tag_ground").transform;
        tagGround2 = GameObject.Find(this.name + "/tag_ground2").transform;
        tagGround3 = GameObject.Find(this.name + "/tag_ground3").transform;
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        weaponanim = weapon.GetComponent<Animator>();
        scoreManager = GameObject.FindGameObjectWithTag("scManager").GetComponent<ScoreManager>();
        FirePoint = GameObject.FindGameObjectWithTag("FirePoint");
        spellAnim = FirePoint.GetComponent<Animator>();
        Mana = maxMana;
        NotEnough.enabled = false;
        playerAnim = this.GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        ManaTimer += Time.deltaTime;
        castTimer += Time.deltaTime;
        manaSlider.value = Mana;
        isGrounded = Physics2D.Linecast(myTrans.position, tagGround.position, playerMask) || Physics2D.Linecast(myTrans.position, tagGround2.position, playerMask) || Physics2D.Linecast(myTrans.position, tagGround3.position, playerMask);       
        if (Input.GetKeyDown("f"))
        {
            Debug.Log("fukoff");
            weaponanim.SetTrigger("Attack");          

        }

        Move(Input.GetAxisRaw("Horizontal"));

        Animating(h, v);

        if (Input.GetButtonDown("Jump"))
            Jump();
        Climb(Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown("q"))
        {
            if (Mana <= 0)
            {
                ManaTimer = 0;
                NotEnough.enabled = true;
            }

            if (Mana > 0 && castTimer > TimeBetweenCast)
            {
                castTimer = 0f;
                //spellAnim.SetTrigger("Cast");

                Mana -= 1;
                Instantiate(fireball, firePoint.position, firePoint.rotation);
            }
            
            }
         if (ManaTimer > 1)
            {
                NotEnough.enabled = false;
            }
        }

    void Move(float horizonalInput)
    {
        if (!canMoveInAir && !isGrounded)
            return;

        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizonalInput * speed;
        myBody.velocity = moveVel;

        if (moveVel.x < 0)  // tukrozi a playert iranytol fuggoen
        {
            m_FacingRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (moveVel.x > 0)
        {
            m_FacingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Animating(float h, float v) {
        bool walking = h != 0f || v != 0f;

        playerAnim.SetBool("IsMoving", walking);
    }

    public void Jump()
    {
        if (isGrounded && !OnLadder)
            myBody.velocity += jumpVelocity * Vector2.up;
    }

    void Climb(float verticalInput)
    {
        if (OnLadder)
        {
            Vector2 moveVel = myBody.velocity;
            moveVel.y = verticalInput * speed;
            myBody.velocity = moveVel;

        }
    }

    public void StartMoving(float horizonalInput)
    {
        hInput = horizonalInput;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "ladder")
        {
            OnLadder = true;
        }

        if (other.tag == "coin")
        {
            scoreManager.coins += 1;
            Destroy(other.gameObject);
        }

        if (other.tag == "key")
        {
            scoreManager.keys += 1;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
      if (other.tag == "ladder")
        OnLadder = false;
    }

}