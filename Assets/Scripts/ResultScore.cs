using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private Text textField;

    // Start is called before the first frame update
    void Start()
    {
        textField = GetComponent<Text>();
        textField.text = "Your Score: " + RockHealth.score;
    }
}
