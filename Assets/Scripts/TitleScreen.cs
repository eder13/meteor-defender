using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Button playButton;

    private void Start()
    {
        Button btn = GetComponent<Button>();

        playButton = btn;

        playButton.onClick.AddListener(onPlayButtonClick);
    }

    public void onPlayButtonClick()
    {
        Debug.Log("I clicked on the Button!");
        Application.LoadLevel("ShipSelectScreen");   
    }
}
