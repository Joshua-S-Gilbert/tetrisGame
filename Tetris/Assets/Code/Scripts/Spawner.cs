using System.Collections;
using UnityEngine;

/**
* Spawner class to store the game objects for normal and extended mode,
* and to spawn each game object during game play
*/
public class Spawner : MonoBehaviour
{
  public GameObject[] Groups;
  public GameObject[] GroupsExtended;

  /**
  * Spawns the next random game object
  */
  public void SpawnNext()
  {
    // If playing on extended mode, use extra pieces
    if (GamePlay.Mode == "Extended")
    {
      int i = Random.Range(0, GroupsExtended.Length);
      Instantiate(GroupsExtended[i], transform.position, Quaternion.identity);
    }
    else
    {
      int i = Random.Range(0, Groups.Length);
      Instantiate(Groups[i], transform.position, Quaternion.identity);
    }
  }

  /**
  * Start is called before the first frame update
  */
  void Start()
  {
    // Spawn the next group (game piece)
    SpawnNext();
  }
}
