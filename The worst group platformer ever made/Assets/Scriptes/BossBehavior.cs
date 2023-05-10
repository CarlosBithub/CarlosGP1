using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //create a set a health variable for our boss
    public int bossHealth = 100;
    public float speed = 15f;
    public float attackRange = 16f;
    //create a series of bool to track the bosses phases
    public bool phase2 = false;
    
    public bool isdead = false;
    public Transform player;
    public bool isFlipped = false;
    PlayerManager playerManager;

    //create a shot location as a reference
    public Transform shotLocation;
    public GameObject projectile1;
    public GameObject projectile2;
    //gameobject that helps activate the boss
    

    //create a time system to shoot this projectile every 5 seconds with the
    //change this number
    public float timer;
    public int waitingTime;

    //create a second time system for phase one.
    public float timer2;
    public int waitingtime2;
    


    private void Start()
    {
        //Found and got our reference and sets the information we are looking for
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        //(position,rotation,scale)
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {
        //create a series of if else statements that will check to see
        //if the boss is below 7 and above 3 its phase 2, below 3 and above 1 its phase 3,
        //and is less then or equal to 0 its dead.

        if (bossHealth < 50 && bossHealth > 0)
        {
            
            phase2 = true;
            speed = 3;
            attackRange = 16;
        }
        
        else if (bossHealth <= 0)
        {

            phase2 = false;
            isdead = true;
            Destroy(gameObject);
            
        }

        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
    }

    public void ProjectileShoot2()
    {

        if (timer > waitingTime)
        {
            if (phase2)
            {
                //creates a new gameobject based off our prefab.
                //Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                GameObject clone = Instantiate(projectile2, shotLocation.position, Quaternion.identity);
                timer = 0;
            }
        }
    }

    public void ProjectileShoot1()
    {
        if (timer2 > waitingtime2)
        {
            if (!phase2)
            {
                GameObject clone2 = Instantiate(projectile1, shotLocation.position, Quaternion.identity);
                timer2 = 0;
            }
        }
    }


    //make the boss rotate at the player's direction;
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = true;
        }else if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            isFlipped = false;
        }
    }


    public void TakeBossDamage()
    {
        bossHealth -= 1;
    }
}
