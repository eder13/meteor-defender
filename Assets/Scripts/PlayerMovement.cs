using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public Vector2 shipSpeed = new Vector2(35, 35);

    private Vector2 movement;
    private Rigidbody2D playerBody;

    private float MAX_SPEED_DIR = 0.2f;

    private AudioSource audioSource;
    public AudioClip audioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private Vector2 updateMovement()
    {

        if (SceneManager.GetActiveScene().name != "SampleScene")
        {
            return new Vector2(0, 0);
        }

        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        if (xDir != 0 && Mathf.Abs(xDir) > MAX_SPEED_DIR)
        {
            xDir = xDir < 0 ? -MAX_SPEED_DIR : MAX_SPEED_DIR;
        }

        if (yDir != 0 && Mathf.Abs(yDir) > MAX_SPEED_DIR)
        {
            yDir = yDir < 0 ? -MAX_SPEED_DIR : MAX_SPEED_DIR;
        }

        return new Vector2(xDir * shipSpeed.x, yDir * shipSpeed.y);
    }

    private void ShootMissile()
    {
        if (SceneManager.GetActiveScene().name != "SampleScene")
            return;

        if (Input.GetButtonDown("Jump")) {
           
            // grab the weapon script and shoot
            WeaponShootTrigger weaponShootTrigger = GetComponent<WeaponShootTrigger>();

            if (weaponShootTrigger != null)
            {
                if (weaponShootTrigger.canShoot())
                {
                    audioSource.PlayOneShot(audioClip);
                    weaponShootTrigger.Attack(true);
                } else
                {
                    Debug.Log("Can not shoot!");
                }
            } else
            {
                Debug.LogError("Could not get instance weaponShootTrigger from component");
            }

            return;
        }
    }

    // This is like the constructor -> when object is being created
    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        Debug.Log("The playerBody position on Start: " + playerBody.position.x + "|" + playerBody.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        movement = updateMovement();
        ShootMissile();
    }

    private void FixedUpdate()
    {
        playerBody.velocity = movement;
    }
}
