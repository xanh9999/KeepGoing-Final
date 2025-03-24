using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTrap : MonoBehaviour
{   

    public Transform firePoint;
    public GameObject bullet;
    float timeBetween;
    public float startTimeBetween;
    
    void Start()
    {
        timeBetween = startTimeBetween;
    }

    
    void Update()
    {
        if (timeBetween <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            timeBetween = startTimeBetween;
        }
        else{
            timeBetween -= Time.deltaTime;
        }
    }
    
}
