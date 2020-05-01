using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // reference the player script to deal damage to the player
    private Player playerScript;
    private Vector2 targetPosition;

    // bullet speed
    public float speed;

    // bullet damage useful to detect collision and calculate damage
    public int damage;

    public GameObject effect;

    // Start is called before the first frame update
    private void Start()
    {
        // detect the player and fetch the player script on that object
        // set position fololowing the player script position
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if the distance between player position and target position is small
        // move towards the the target position
        // after destroy the game object
        if (Vector2.Distance(transform.position, targetPosition) > .1f)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            Instantiate (effect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // detect collision 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
