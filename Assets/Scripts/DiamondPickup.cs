using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    
    [SerializeField] int pointsForPickingUpDiamond = 199;

    AudioManager audioManager;

    bool wasCollected = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !wasCollected)
        {   
            // audioManager.PlaySFX(audioManager.pickups);

            if (audioManager == null)
            {
                audioManager = GameObject.FindGameObjectWithTag("Audio")?.GetComponent<AudioManager>();
            }

            if (audioManager != null)
            {
                audioManager.PlaySFX(audioManager.pickups);
            }

            wasCollected = true;
            FindObjectOfType<GameSession>().AddScore(pointsForPickingUpDiamond);
            Destroy(gameObject);
        }    
    }
}
