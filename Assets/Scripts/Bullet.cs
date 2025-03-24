using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField] float bulletSpeed = 10f;
    Rigidbody2D myRigidbody;
    PlayerMovementScript player;
    float xSpeed;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovementScript>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    
    void Update()
    {
        myRigidbody.velocity = new Vector2 (xSpeed, 0f);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {   
            audioManager.PlaySFX(audioManager.flyMonsterHurt);
            Destroy(other.gameObject);
        }
        Destroy(gameObject);    
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);  
    }

    
}
