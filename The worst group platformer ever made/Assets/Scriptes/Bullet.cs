using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    BossBehavior bossbehavior;
    EnemyHealth enemyHealth;
    public int destroyTime = 3;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
        //bossbehavior = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossBehavior>();
    }

    private void Update()
    {
       timer += Time.deltaTime;
        if (timer > destroyTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "EnemyBody")
        {
            Destroy(gameObject);
        }


    }
}
