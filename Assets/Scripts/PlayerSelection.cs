using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;


public class PlayerSelection : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    private GameObject selectedPlayer;

    public Camera camera = null;
    public Button shipAButton = null;
    public Button shipBButton = null;

    private void Start()
    {
        if (shipAButton && shipBButton && camera)
        {
            Vector3 buttonWorldPositionButtonShipA = camera.ScreenToWorldPoint(new Vector3(shipAButton.GetComponent<RectTransform>().position.x, shipAButton.GetComponent<RectTransform>().position.y, 0f));
            players[0].transform.position = new Vector3(buttonWorldPositionButtonShipA.x, 0.5f, 0.0f);

            Vector3 buttonWorldPositionButtonShipB = camera.ScreenToWorldPoint(new Vector3(shipBButton.GetComponent<RectTransform>().position.x, shipBButton.GetComponent<RectTransform>().position.y, 0f));
            players[1].transform.position = new Vector3(buttonWorldPositionButtonShipB.x, 0.5f, 0.0f);
        }
    }

    public void selectShipA()
    {
        selectedPlayer = players[0];
        startGame(0);
    }

    public void selectShipB()
    {
        selectedPlayer = players[1];
        startGame(1);
    }

    private void startGame(int selectedCharacter)
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        Application.LoadLevel("SampleScene");
    }
}
