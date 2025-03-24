using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 3f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(10f,10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    private float fireRate = 0.15f;  //
    private float nextFire = 0f;    //

    AudioManager audioManager;

    Vector2 moveInput;
    Rigidbody2D myRigidbody2d;
    Animator myAnimator;
    CapsuleCollider2D myBodyCapsuleCollider2d;
    BoxCollider2D myFeetCollider2d;
    float gravityScaleAtStart;
    bool isAlive = true;
    
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCapsuleCollider2d = GetComponent<CapsuleCollider2D>();
        myFeetCollider2d = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody2d.gravityScale;        
    }

    
    void Update()
    {   
        if(!isAlive)
        {
            return;
            
        }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    void OnFire(InputValue value)
    {   

        audioManager.PlaySFX(audioManager.shoot);

        if(!isAlive)
        {
            return;           
        }
        if(Time.time > nextFire)
        {   
            nextFire = Time.time + fireRate;
            Instantiate(bullet, gun.position, transform.rotation);
        }
        // Instantiate(bullet, gun.position, transform.rotation);
    }
    void OnMove(InputValue value)
    {   
        if(!isAlive)
        {
            return;           
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {   
        audioManager.PlaySFX(audioManager.jump);

        if(!isAlive)
        {
            return;           
        }
        if(!myFeetCollider2d.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {   
            
            return;
        }
        if(value.isPressed)
        {   
            myAnimator.SetBool("isJumping",true);
            myRigidbody2d.velocity += new Vector2 (0f, jumpSpeed);
            
        }
    }

    void Run()
    {   
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody2d.velocity.y);
        myRigidbody2d.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2d.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning",playerHasHorizontalSpeed); //xem player có di chuyển ko, nếu có thì animation chạy
    }

    void FlipSprite()
    {   
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody2d.velocity.x) > Mathf.Epsilon; //xem player có di chuyển ko
        
        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody2d.velocity.x), 1f);
        }   
    }
    void ClimbLadder()
    {
        if(!myFeetCollider2d.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {   
            myRigidbody2d.gravityScale = gravityScaleAtStart;
            return;
        }
        
        Vector2 playerVelocity = new Vector2 (myRigidbody2d.velocity.x, moveInput.y * climbSpeed);
        myRigidbody2d.velocity = playerVelocity;
        myRigidbody2d.gravityScale = 0f;
    }
    void Die()
    {   
        

        if(myBodyCapsuleCollider2d.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {   
            audioManager.PlaySFX(audioManager.playerHurt);

            isAlive = false;
            myAnimator.SetTrigger("Die");
            myRigidbody2d.velocity = deathKick;
            Destroy(gameObject,0.75f);
            FindAnyObjectByType<GameSession>().ProcessPlayerDeath();
        }
        if(myFeetCollider2d.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {   
            audioManager.PlaySFX(audioManager.playerHurt);

            isAlive = false;
            myAnimator.SetTrigger("Die");
            myRigidbody2d.velocity = deathKick;
            Destroy(gameObject,0.75f);
            FindAnyObjectByType<GameSession>().ProcessPlayerDeath();
        }
    }
    
}
