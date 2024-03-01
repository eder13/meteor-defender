using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyRockScript : MonoBehaviour
{
    private float approachingSpeedMax = 14.0f;
    private float approachingSpeedMin = 7.0f;

    private Vector2 movement;
    private Rigidbody2D rigidbodyComponent;

    private int damageOnHit = 1;

    private float waitNextSpawn = 0.5f;
    private float countdown = 0.5f;

    void Awake()
    {
        rigidbodyComponent = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(-Random.Range(approachingSpeedMin, approachingSpeedMax), 0);

        // after some time, spawn another rock

        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            SpawnNewRock();
            countdown = waitNextSpawn;
        }

    }

    void SpawnNewRock()
    {
        // grap the spawner and spawn
        RockSpawner rockSpawner = GetComponent<RockSpawner>();

        if(rockSpawner != null)
            rockSpawner.SpawnRock();
    }

    void FixedUpdate()
    {
        rigidbodyComponent.velocity = movement;
    }

    // Getters
    public int damage
    {
        get
        {
            return damageOnHit;
        }
    }
}
