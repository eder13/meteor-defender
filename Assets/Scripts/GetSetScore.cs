using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSetScore : MonoBehaviour
{
    public Text textField;

    public void setScore(int newScore)
    {
        textField.text = "Score: " + newScore;
    }

    public string getScore()
    {
        return textField.text;
    }
}
