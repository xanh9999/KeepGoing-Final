using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingMushroom : MonoBehaviour
{   
    [SerializeField] float bouncingPower = 5f;

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bouncingPower, ForceMode2D.Impulse);
        }
    }

}
