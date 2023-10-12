using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* PauseMenu class the manages the pause menu buttons
*/
public class PauseMenu : MonoBehaviour
{
  /**
  * Load GamePage scene when 'Resume' button is pressed
  */
  public void ResumeGame()
  {
    SceneManager.LoadScene("GamePage");
    Debug.Log("Resume");
  }

  /**
  * Load MainMenu scene when 'Quit' button is pressed
  */
  public void QuitToMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
    Debug.Log("Quit");
  }

  /**
  * Update is called once per frame
  */
  void Update()
  {
    // Resume game if the escape key is pressed
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      SceneManager.LoadScene("GamePage");
    }
  }
}
