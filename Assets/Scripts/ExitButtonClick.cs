using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButtonClick : MonoBehaviour
{
    public Button menuButton;

    void Start()
    {
        Button btn = GetComponent<Button>();
        menuButton = btn;
        menuButton.onClick.AddListener(onMenuButtonClicked);
    }

    public void onMenuButtonClicked()
    {
        // reset the score counter
        RockHealth.score = 0;

        // go back to main screen
        Application.LoadLevel("TitleScreen");
    }
}
