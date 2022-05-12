using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] Vector3 laserForce;
    [SerializeField] SoundManager soundManager;
    [SerializeField] Animator animator;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Fire button
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            

        }
     
    }

    public void Shoot()
    {   // Play laser sound
        animator.SetTrigger("Shoot");
        soundManager.PlaySound();
        // Spawning the bullet and setting the direction of fire
        GameObject laser = Instantiate(laserPrefab, firePoint.transform.position, firePoint.transform.rotation);
        // If no collision destroy after 3 seconds
        Destroy(laser, 2f);

    }


}
