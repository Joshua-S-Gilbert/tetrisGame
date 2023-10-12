using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* MainMenu class manages loading relevant game scenes from main menu
*/
public class MainMenu : MonoBehaviour
{
  /**
  * When 'play' button is pressed, load GamePage scene
  */
  public void PlayGame()
  {
    SceneManager.LoadScene("GamePage");
  }

  /**
  * Quits the game
  */
  public void QuitGame()
  {
    Debug.Log("QUIT!");
    Application.Quit();
  }
}
