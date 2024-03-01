using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotMove : MonoBehaviour
{
    private float bulletSpeed = 10.0f;
    private Rigidbody2D rigidBodyComponent;
    private Vector2 movement;

    private void Awake()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(bulletSpeed, 0);
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = movement;
    }
}
