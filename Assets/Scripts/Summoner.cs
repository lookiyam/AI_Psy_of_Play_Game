using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private Animator anim;
    private Vector2 targetPosition;

    public float timeBetweenSummons;
    private float summonTime;

    public Enemy enemyToSummon;
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2 (randomX, randomY);
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player !=null)
        {
            if (Vector2.Distance(transform.position, targetPosition)> .5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("Run", true);
            }
            else
            {
                anim.SetBool("Run", false);

                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("summon");
                }
            }
        }
    }
    public void Summon()
    {
        if (player != null)
        {
            Instantiate(enemyToSummon, transform.position, transform.rotation);
        }
    }

}


