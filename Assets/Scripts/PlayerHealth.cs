using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;

    public bool isMainPlayer;

    // Start is called before the first frame update
    void Start()
    {
        health = 1;
    }

    public void checkAlive()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        checkAlive();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MovingEnemyRockScript movingRock = collision.gameObject.GetComponent<MovingEnemyRockScript>();

        if (movingRock != null)
        {
            // A rock hit the plane
            Debug.Log("Got Hit by a rock!");

            // destroy the rock
            Destroy(movingRock.gameObject);

            health = health - movingRock.damage;
        }
    }
}
