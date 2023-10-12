using UnityEngine.Audio;
using System;
using UnityEngine;

/**
* Unity AudioManager class to play audi during the game
*/
public class AudioManager : MonoBehaviour
{
  public Sound[] sounds;

  public static AudioManager Instance;

  /**
  * Method called when script instance is being loaded,
  * and sets up the audio Source
  */
  void Awake()
  {
    if (Instance == null)
    {
      Instance = this;
    }
    else
    {
      Destroy(gameObject);
      return;
    }
    DontDestroyOnLoad(gameObject);  // keep the audio manager object active

    foreach (Sound s in sounds)
    {
      s.Source = gameObject.AddComponent<AudioSource>();
      s.Source.clip = s.Clip;
      s.Source.volume = s.Volume;
      s.Source.pitch = s.Pitch;
      s.Source.loop = s.Loop;
      s.Source.outputAudioMixerGroup = s.AudioMixerGroup;
    }
  }

  /** 
  * Start is called before the first frame update
  */
  void Start()
  {
    Play("backgroundMusic");
  }

  /**
  * Play an audio clip in Unity
  */
  public void Play(string name)
  {
    Sound s = Array.Find(sounds, Sound => Sound.Name == name);
    // if the sound is not found
    if (s == null)
    {
      Debug.LogWarning("Sound: " + name + " not found!");
      return;
    }
    s.Source.Play();    // play sound
  }

  /**
  * Play an audio clip that scales the AudioSource volume by voumeScale
  */
  public void FullPlay(string name)
  {
    Sound s = Array.Find(sounds, Sound => Sound.Name == name);
    // if the sound is not found
    if (s == null)
    {
      Debug.LogWarning("Sound: " + name + " not found!");
      return;
    }
    s.Source.PlayOneShot(s.Clip, s.Volume); // play sound
  }

}
