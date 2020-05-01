using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour
{
    // represent the boss HP
    public int health;

    // each time the boss take damage he has to spawn a random enemy
    // this represent the arrey of enemies that the boss have to spawn
    public Enemy [] enemies;

    // this variable represent the offset where the spawned random enemy has to spawn
    public float spawnOffset;

    // since the boss has two stages, this varible allows to detect when he has half health, in order to trigger the chase state
    private int halfHealth;

    // this is a reference to the animator component, that is needed to detect the trigger of the second stage
    private Animator anim;

    // variable that will calculate the damage that the boss deal
    public int damage;

    public GameObject effect;

    private SceneTransition sceneTransition;

    private void Start() 
    {
        // declare the variable that notice when the boss has half helath, while recalling the animator component
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
        sceneTransition = FindObjectOfType<SceneTransition>();

    }
    
    // function that allows the boss recognise when he is hitted by the bullet
    public void TakeDamage(int amount) 
    {
        health -= amount;
        if (health <= 0)
        {
            Instantiate (effect, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            sceneTransition.LoadScene("Win");
        }

        // if the boss has less or equal to half health
        // trigger stage2
        if (health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        // declare a varianble that allows the boss to spawn an enemy within the set arrey
        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        // than instantiate the random enemy in the boss position tilted by an offset variable
        Instantiate(randomEnemy, transform.position + new Vector3(spawnOffset, spawnOffset, 0), transform.rotation);
    }

    // Detect collision by trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if the collision object has the tag of player
        // call the player component and deal damage
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
