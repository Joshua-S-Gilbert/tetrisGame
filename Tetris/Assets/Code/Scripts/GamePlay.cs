using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
* GamePlay class to keep the state of the game settings, score and lines eliminated
*/
public class GamePlay : MonoBehaviour
{
  public TMP_Text ScoreText;
  public TMP_Text FinalScoreText;
  public TMP_Text LinesEliminatedText;
  public TMP_Text LevelText;
  public TMP_Text ModeText;
  public TMP_Text GameTypeText;

  public int Score
  { get; set; }
  public int LinesEliminated
  { get; set; }
  public static string Level
  { get; set; } = "Slow";
  public static string Mode
  { get; set; } = "Normal";
  public static string GameType
  { get; set; } = "Normal";
  public static int FieldWidth
  { get; set; } = 10;
  public static bool Paused
  { get; set; } = false;

  public GameObject GameSpaceSmall;
  public GameObject GameSpaceNormal;
  public GameObject GameSpaceLarge;
  public GameObject GameSpaceMassive;

  public GameObject GameOverMenu;
  public GameObject PauseMenu;

  public void ShowGameOverMenu()
  {
    GameOverMenu.SetActive(true);
    FinalScoreText.text = String.Format("Score: {0}", Score);
  }

  public void HideGameOverMenu()
  {
    GameOverMenu.SetActive(false);
  }

  public void PauseGame()
  {
    PauseMenu.SetActive(true);
    Paused = true;
  }

  public void UnpauseGame()
  {
    PauseMenu.SetActive(false);
    Paused = false;
  }

  public void PlayAgain()
  {
    SceneManager.LoadScene("GamePage");
  }

  public void Quit()
  {
    HideGameOverMenu();
    SceneManager.LoadScene("MainMenu");
  }

  /** 
  * Updates the score according to the number of rows removed
  * @param rowsRemoved Number of rows that have been removed during game play
  */
  public void UpdateScore(int rowsRemoved)
  {
    switch (rowsRemoved)
    {
      case 1:
        Score += 100;
        break;
      case 2:
        Score += 300;
        break;
      case 3:
        Score += 600;
        break;
      case 4:
        Score += 1000;
        break;
      default:
        break;
    }
    ScoreText.text = String.Format("Score: {0}", Score);
  }

  /** 
  * Updates the total number of lines eliminated after every line is cleared
  * @param num Number of lines that have been eliminated
  */
  public void UpdateLinesEliminated(int num)
  {
    LinesEliminated += num;
    LinesEliminatedText.text = String.Format("Lines Eliminated: {0}", LinesEliminated);

  }

  public static double GetDropSpeed()
  {
    switch (Level)
    {
      case "Slow":
        return 1.2;
      case "Normal":
        return 1.0;
      case "Fast":
        return 0.4;
      case "Nightmare":
        return 0.1;
      default:
        return 1.0;
    }
  }

  /**
  * Start is called before the first frame update
  */
  void Start()
  {
    Paused = false;
    ModeText.text = $"Mode: {Mode}";
    LevelText.text = $"Level: {Level}";
    GameTypeText.text = $"Game Type: {GameType}";
    LinesEliminatedText.text = "Lines Eliminated: 0";

    // Display the appropriate game space according to the field width
    switch (FieldWidth)
    {
      case 8: // Small
        GameSpaceSmall.SetActive(true);
        break;
      case 10: // Normal
        GameSpaceNormal.SetActive(true);
        break;
      case 15: // Large
        GameSpaceLarge.SetActive(true);
        break;
      case 20: // Massive
        GameSpaceMassive.SetActive(true);
        break;
      default:
        GameSpaceNormal.SetActive(true);
        break;
    }
  }
}
