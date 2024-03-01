using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockHealth : MonoBehaviour
{
    public int health = 1;

    public static int score = 0;

    void OnGUI()
    {
        GUI.contentColor = Color.black;
        GUI.skin.label.fontSize = 38;
        GUI.Label(new Rect(24, 24, 200, 50), "Score: " + score.ToString());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shooting shot = collision.gameObject.GetComponent<Shooting>();

        if (shot != null)
        {
            score += 1;
            Destroy(gameObject);
            Destroy(shot.gameObject);
        }
    }
}
