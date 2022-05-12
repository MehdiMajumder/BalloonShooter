using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonMovement : MonoBehaviour
{
    // To Add force to the balloon
    [SerializeField] Vector3 force;
    // Balloons sprites array
    [SerializeField] Sprite[] balloonSprite;
    // Rigidbody to add force
    private Rigidbody2D balloonRB;
    // For changing sprite
    private SpriteRenderer spriteRenderer;
    // To find speed of the balloons
    Vector3 LastVelocity;

    Scenemanager sceneManager;

    // Start is called before the first frame update
    void Start()
    {

        sceneManager = FindObjectOfType<Scenemanager>();
        // Getting the component of the Game Object
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Accessing the sprite and assigning it to generate random balloon sprites
        spriteRenderer.sprite = balloonSprite[Random.Range(0, 5)];
        // Randomizing the balloons X spawn position
        transform.position = new Vector3(Random.Range(10f, 175f), transform.position.y, transform.position.z);
        // Getting the component and assigning it to the rigidbody
        balloonRB = GetComponent<Rigidbody2D>();
        // Applying force to the balloon so balloons go in different directions and speeds
        force = new Vector3(Random.Range(25, 175), Random.Range(150, 175), 0);
        //Applying the force
        balloonRB.AddForce(force);

    }

    // Update is called once per frame
    void Update()
    {
        // Finding the last velocity of the balloon
        LastVelocity = balloonRB.velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Finding the speed
        var speed = LastVelocity.magnitude;
        // Finding and applying the direction of the balloons
        var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
        // The Maximum value is applied
        balloonRB.velocity = direction * Mathf.Max(speed, 0f);

        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        

    }


    public void OnTriggerEnter2D(Collider2D collision)
        { 
        //Destroy the balloons when the laser hits
        if (collision.gameObject.tag == "Laser")
        {
            // increase score
            sceneManager.SetScore(1);

            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            
        }

        // If the balloon ever collides with the rightmost wall it gets destroyed
        else if (collision.gameObject.tag == "RightWall")
        {
           Destroy(this.gameObject);
        }

       
    }

}
