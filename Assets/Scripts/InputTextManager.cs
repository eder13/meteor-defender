using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputTextManager : MonoBehaviour
{
    public static Text textField;

    private void Start()
    {

    }

    public static void UpdateText(int newScore)
    {
        textField.text = "Score: " + newScore;
    }
}
