using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System;

/**
* LeaderboardMenu class stores the leaderboard data
*/
public class LeaderboardMenu : MonoBehaviour
{
  public TextAsset LeaderBoardFile;   //!< for Leaderboard.text
  public TMP_Text[] TextList;         //!< for the list of leaders

  /**
  * Start is called before the first frame update
  */
  void Start()
  {
    var splitFile = new string[] { "\r\n", "\r", "\n" };  // split the file into lines based on these parameters
    var splitLine = new char[] { ',' };                   // split each line into a list based on these parameters
    var Lines = LeaderBoardFile.text.Split(splitFile, System.StringSplitOptions.RemoveEmptyEntries);    // generate lines list
    for (int i = 0; i < 10; i++)
    {
      var Line = Lines[i].Split(splitLine, System.StringSplitOptions.None);   // split line into a list
      try
      {
        TextList[i].text = String.Format("{0}. {1, -5} {2, 10}", i + 1, Line[1], Line[0]);    // set text object to formatted string for display
      }
      catch
      {
        TextList[i].text = String.Format("{0}. --", i); // in case there is an error reading the data, print "--"
      }
    }
  }
}
