using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is applied to the Bullet prefab.
// collision.gameObject is the object that the bullet is colliding with.
// gameObject is the Bullet.






public class Collision : MonoBehaviour
{
    //implement a feature that will spawn a bunch of random hexagons to act as fake particles
    //store the prefab to be used as particles in a variable
    public GameObject particlePrefab;
    public List<Sprite> sprites;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;


    // Task 3: Destroy bullets when they collide with all game objects except the player
    public void Start()
    {
        sprites = new List<Sprite>() { sprite1, sprite2, sprite3 };
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       
        //create a for loop that will spawn particles around where the bullet collides before it is destroyed
        //Use random numbers for x and Y position for a sense of fun
        //change velocity of it for funnies using code we used for bullets as a template i think
        //Particle prefab should have rigidbody so gravity makes it look silly
        for (int i = 0; i < 10; i++)
        {
           GameObject sillyParticle = Instantiate(particlePrefab, transform.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), 0.0f), transform.rotation);

            

            //adding velocity
            sillyParticle.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 10.0f), 0.0f);

            //pick random sprites everytime
            int randomSpriteSelect = Random.Range(0, sprites.Count);
            Sprite randomSpriteSelected = sprites[randomSpriteSelect];
            sillyParticle.GetComponent<SpriteRenderer>().sprite = randomSpriteSelected;
            //destroy the particle over time so it doesn't take up our valuable space!
            Destroy( sillyParticle, Random.Range(1.0f,2.0f));
            
        }

        Destroy(gameObject);
    }
}
