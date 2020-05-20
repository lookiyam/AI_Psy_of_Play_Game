﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    public Weapon weaponToEquip;

    public GameObject effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MyPlayer")
        {
            Instantiate (effect, transform.position, Quaternion.identity);
            collision.GetComponent<Player>().ChangeWeapon(weaponToEquip);
            Destroy(gameObject);
        }
    }


}
