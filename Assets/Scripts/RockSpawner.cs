using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockSpawner : MonoBehaviour
{
    public Transform rockPrefab;
    public Transform barrierPrefab;

    public static InputTextManager inputTextManager;

    public static int score = 0;

    private Collider2D barrierCollider;

    private float destroyThreshold = -10.0f;

    private void Awake()
    {
       
    }

    private void Update()
    {
        foreach (Transform rock in GameObject.FindObjectsOfType<Transform>())
        {
            if (rock.CompareTag("RockPrefTag"))
            {
                if (rock.position.x < destroyThreshold)
                {
                    Destroy(rock.gameObject);
                }
            }
        }
    }

    private void Start()
    {
        var barrierPref = Instantiate(barrierPrefab) as Transform;

        Vector2 pos = new Vector2(-9.0f, -0.65f);

        barrierPref.position = pos;

        barrierCollider = barrierPref.GetComponent<Collider2D>();
    }

    public void SpawnRock()
    {
        var rockPref = Instantiate(rockPrefab) as Transform;

        Physics2D.IgnoreCollision(rockPref.GetComponent<Collider2D>(), barrierCollider);

        float xPos = 9.5f;
        float yPos = Random.Range(-4.5f, 4.5f);

        Vector2 pos = new Vector2(xPos, yPos);

        rockPref.position = pos;
        rockPref.tag = "RockPrefTag";
    }

    public static void UpdateStaticScore()
    {
        score += 1;
    }

    public void UpdateScore()
    {
        score += 1;
    }
}
