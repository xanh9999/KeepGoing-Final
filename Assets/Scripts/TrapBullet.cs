using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrapBullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {   
        if (other.gameObject.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
    }
    
}
