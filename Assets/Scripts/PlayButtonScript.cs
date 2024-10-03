using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour
{
    public Button playButton;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            playButton.onClick.Invoke();
        }
    }

    // This method will be linked to the button's OnClick event
    public void OnPlayButtonPressed()
    {
        // Load the game scene (make sure the scene name is correct)
        SceneManager.LoadScene("Main");
    }
}
