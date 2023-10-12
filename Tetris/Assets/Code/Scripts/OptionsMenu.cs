using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;    // for volume settings
using UnityEngine.UI;       // for resolutions
using TMPro;                // for TMP settings for dropdown

/**
* OptionsMenu class stores the state of option menu variables
*/
public class OptionsMenu : MonoBehaviour
{
  public AudioMixer AudioMixer;               //!< for volume
  public TMP_Dropdown ResolutionDropdown;     //!< for Resolutions
  Resolution[] Resolutions;                   //!< for Resolutions
  public GameObject GameSizeObject;
  public TMP_Dropdown GameSize;
  public TMP_InputField GameSizeField;
  public GameObject DropSpeedObject;
  public TMP_Dropdown DropSpeed;
  public TMP_InputField DropSpeedField;
  public GameObject ErrorButton;

  /**
  * Start is called before the first frame update
  */
  void Start()
  {   // this function is called on startup. sets resolutions.
    Resolutions = Screen.resolutions;       // includes group of resolutions
    ResolutionDropdown.ClearOptions();      // clears dropdown list

    List<string> Options = new List<string>();  // creates variable length list for resolutions

    int currentResolutionIndex = 0;     // for setting correct resolution later
    for (int i = 0; i < Resolutions.Length; i++)
    {   // generate list of resolutions
      string Option = Resolutions[i].width + " x " + Resolutions[i].height;
      Options.Add(Option);

      if (Resolutions[i].width == Screen.currentResolution.width &&   // sets to current resolution
          Resolutions[i].height == Screen.currentResolution.height)
      {
        currentResolutionIndex = i;
      }
    }

    ResolutionDropdown.AddOptions(Options);     // add list of resolutions to dropdown
                                                // the following sets resolution to current resolution:
    ResolutionDropdown.value = currentResolutionIndex;
    ResolutionDropdown.RefreshShownValue();
  }

  /**
  * Sets screen resolutions
  * @param resolutionIndex Integer value from user selection
  */
  public void SetResolution(int resolutionIndex)
  {
    Resolution Resolution = Resolutions[resolutionIndex];
    Screen.SetResolution(Resolution.width, Resolution.height, Screen.fullScreen);
  }

  /**
  * Set the game size according to the dropdown in the options menu
  * @param size Integer value from options dropdown
  */
  public void SetGameSize(int size)
  {
    if (size != 4 && GameSizeObject.activeSelf)
    {
      GameSizeObject.SetActive(false);
    }
    switch (size)
    {
      case 0: // Small
        GamePlay.FieldWidth = 8;
        return;
      case 1: // Normal
        GamePlay.FieldWidth = 10;
        return;
      case 2: // Large
        GamePlay.FieldWidth = 15;
        return;
      case 3: // Massive
        GamePlay.FieldWidth = 20;
        return;
      default:
        GamePlay.FieldWidth = 10;
        return;
    }
  }

  /**
  * Set the game size based on manual input from user
  */
  public void ManualGameSize()
  {   // sets user entered custom game size
      // need to use (inputfieldname).text to access value inside the field
    if (GameSizeField.text == "" || GameSizeField.text == "0")
    {
      // set game size to default
      ErrorButton.SetActive(true);
      GameSizeField.text = "10";
    }
    else
    {
      // set game size to whatever is in the Size variable
      // might need to use Parse or TryParse to convert str to int
    }
    return;
  }

  /**
  * Set the drop speed according to dropdown in options menu
  * @param speed Integer value from options dropdown
  */
  public void SetDropSpeed(int speed)
  {
    if (speed != 4 && DropSpeedObject.activeSelf)
    {
      DropSpeedObject.SetActive(false);
    }
    switch (speed)
    {
      case 0:
        GamePlay.Level = "Slow";
        return;
      case 1:
        GamePlay.Level = "Normal";
        return;
      case 2:
        GamePlay.Level = "Fast";
        return;
      case 3:
        GamePlay.Level = "Nightmare";
        return;
      default:
        GamePlay.Level = "Normal";
        return;
    }
  }

  /**
  * Set the drop speed based on manual input from user
  */
  public void ManualDropSpeed()
  { // sets the user entered custom drop speed
    // need to use (inputfieldname).text to access value inside the field
    if (DropSpeedField.text == "" || DropSpeedField.text == "0")
    {
      // set drop speed to default
      ErrorButton.SetActive(true);
      DropSpeedField.text = "10";
    }
    else
    {
      // set drop speed to whatever is in Speed variable.
      // might have to use Parse or TryParse here to convert str to int
    }
    return;
  }

  /**
  * Set the master volume
  * @param masterVolume Volume float value from options slider
  */
  public void SetMasterVolume(float masterVolume)
  {   // sets master volume
    AudioMixer.SetFloat("MasterVolume", masterVolume);
  }

  /**
  * Set the music volume
  * @param musicVolume Volume float value from options slider
  */
  public void SetMusicVolume(float musicVolume)
  {   // sets music volume
    AudioMixer.SetFloat("MusicVolume", musicVolume);
  }

  /**
  * Set the sfx volume
  * @param sfxVolume Volume float value from options slider
  */
  public void SetSFXVolume(float sfxVolume)
  {   // sets SFX volume
    AudioMixer.SetFloat("SFXVolume", sfxVolume);
  }

  /**
  * Set the menu sfx volume
  * @param menuSFXVolume Volume float value from options slider
  */
  public void SetMenuSFXVolume(float menuSFXVolume)
  {   // sets menu sounds volume
    AudioMixer.SetFloat("MenuSoundsVolume", menuSFXVolume);
  }

  /**
  * Set the screen resolution to full screen
  * @param isFullscreen Boolean value from options checkbox
  */
  public void SetFullscreen(bool isFullscreen)
  {   // enables or disables fullscreen mode
    Screen.fullScreen = isFullscreen;
  }

  /**
  * Set the game mode to extended/normal when the button is toggled
  * @param isExtendedMode Boolean value from options checkbox
  */
  public void SetExtendedMode(bool isExtendedMode)
  {
    if (isExtendedMode)
    {
      GamePlay.Mode = "Extended";
    }
    else
    {
      GamePlay.Mode = "Normal";
    }
  }
}
