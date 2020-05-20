using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    Player playerScript;
    public int healAmount;

    public GameObject effect;

    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("MyPlayer").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MyPlayer")
        {
            Instantiate (effect, transform.position, Quaternion.identity);
            playerScript.Heal(healAmount);
            Destroy(gameObject);
        }
    }

}
