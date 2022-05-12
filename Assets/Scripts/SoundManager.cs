using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip laserSound;
    [SerializeField] AudioClip balloonSound;
    AudioSource lsrc;
    AudioSource bsrc;

    // Start is called before the first frame update
    void Start()
    {
        lsrc = GetComponent<AudioSource>();
        bsrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        lsrc.PlayOneShot(laserSound);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "balloon")
        {
            bsrc.PlayOneShot(balloonSound);
        }
    }


}
