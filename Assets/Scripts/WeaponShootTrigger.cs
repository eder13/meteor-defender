using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This scripts spawns a bullet in front of the ship wherever it's standing
 */
public class WeaponShootTrigger : MonoBehaviour
{
    // shot prefab
    public Transform singleShotPrefab;

    // shot threshold where the shot should despwan if it does not hit anything
    private const float destroyThreshold = 9.5f;

    // variables for shooting cooldowns
    private const float shotRateShipA = 0.25f;
    private float shotCooldownShipA = 0.0f;
    private const float shotRateShipB = 0.4f;
    private float shotCooldownShipB = 0.0f;

    private void Update()
    {
        if (shotCooldownShipA > 0)
        {
            shotCooldownShipA -= Time.deltaTime;
        }
        if (shotCooldownShipB > 0)
        {
            shotCooldownShipB -= Time.deltaTime;
        }

        // Remove the Shot prefab if out of the screen
        foreach (Transform shot in GameObject.FindObjectsOfType<Transform>())
        {
            if (shot.CompareTag("SingleShotPrefTag"))
            {
                if (shot.position.x > destroyThreshold)
                {
                    Destroy(shot.gameObject);
                }
            }
        }
    }

    public void Attack(bool isPlayer)
    {
        if (canShoot())
        {
            // instantiate a prefab
            var shotPref = Instantiate(singleShotPrefab) as Transform;

            // bring it in front of the current object, available via transform
            shotPref.position = transform.position;

            // move the shot -> simple shot from player towards enemy 
            ShotMove shotMove = shotPref.gameObject.GetComponent<ShotMove>();

            shotCooldownShipA = shotRateShipA;
            shotCooldownShipB = shotRateShipB;
        }
    }

    public bool canShoot()
    {
        bool isShipB = PlayerPrefs.GetInt("selectedCharacter") == 1;

        if (isShipB)
        {
            return shotCooldownShipB <= 0;
        }

        return shotCooldownShipA <= 0;
    }
}
