using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

/**
* Sound class to set up Unity audio manager sound
*/
public class Sound
{
  public string Name;
  public AudioClip Clip;
  public AudioMixerGroup AudioMixerGroup;

  [Range(0f, 1f)]
  public float Volume = 1;
  [Range(.1f, 3f)]
  public float Pitch = 1;

  public bool Loop;

  [HideInInspector]
  public AudioSource Source;

  /**
  * Start is called before the first frame update
  */
  void Start()
  {
    Source.outputAudioMixerGroup = AudioMixerGroup;
  }
}
