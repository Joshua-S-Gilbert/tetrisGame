using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* Group class for managing an individual game object
*/
public class Group : MonoBehaviour
{
  /**
  * Check if the current group position is still inside the borders of the game
  */
  bool isValidGridPos()
  {
    foreach (Transform child in transform)
    {
      Vector2 v = Playfield.RoundVector(child.position);

      // If not inside the border then return false
      if (!Playfield.InsideBorder(v))
        return false;

      // If a block already exists in the grid and it's not part of its group return false
      if (Playfield.Grid[(int)v.x, (int)v.y] != null && Playfield.Grid[(int)v.x, (int)v.y].parent != transform)
        return false;
    }
    return true;
  }

  /**
  * Update the game grid 
  */
  void updateGrid()
  {
    // Remove group children (blocks) from the grid
    for (int y = 0; y < Playfield.h; ++y)
      for (int x = 0; x < Playfield.w; ++x)
        if (Playfield.Grid[x, y] != null)
          if (Playfield.Grid[x, y].parent == transform)
            Playfield.Grid[x, y] = null;

    // Add new group children to the grid
    foreach (Transform child in transform)
    {
      Vector2 v = Playfield.RoundVector(child.position);
      Playfield.Grid[(int)v.x, (int)v.y] = child;
    }
  }

  float lastFall = 0; //!< Counter to keep track of the time between each drop

  /**
  * Update is called once per frame
  */
  void Update()
  {
    // If the left arrow key is pressed then move the group to the left 1 space
    if (!GamePlay.Paused)
    {
      if (Input.GetKeyDown(KeyCode.LeftArrow))
      {
        // Update the position of the group left 1
        transform.position += new Vector3(-1, 0, 0);

        // If the move is valid then update the grid accordingly otherwise put the group back
        if (isValidGridPos())
          updateGrid();
        else
          transform.position += new Vector3(1, 0, 0);
      }
      // If the right arrow key is pressed then move the group to the right 1 space
      else if (Input.GetKeyDown(KeyCode.RightArrow))
      {
        transform.position += new Vector3(1, 0, 0);

        if (isValidGridPos())
          updateGrid();
        else
          transform.position += new Vector3(-1, 0, 0);
      }
      // If the up arrow key is pressed then rotate the group 90 degrees
      else if (Input.GetKeyDown(KeyCode.UpArrow))
      {
        transform.Rotate(0, 0, -90);

        if (isValidGridPos())
          updateGrid();
        else
          transform.Rotate(0, 0, 90);
      }
      // If the down arrow key is pressed or the time from the last block fall is >= 1
      // then move the group down
      else if (Input.GetKeyDown(KeyCode.DownArrow) ||
              Time.time - lastFall >= GamePlay.GetDropSpeed())
      {
        transform.position += new Vector3(0, -1, 0);

        // If the move is valid update the grid otherwise put the group back
        // and check if any rows need to be deleted and spawn the next group
        if (isValidGridPos())
        {
          updateGrid();
        }
        else
        {
          transform.position += new Vector3(0, 1, 0);

          // Delete any full rows
          Playfield.DeleteFullRows();

          // Spawn the next group
          FindObjectOfType<Spawner>().SpawnNext();

          // Disable the script
          enabled = false;
        }

        lastFall = Time.time;
      }
      // Show PauseMenu on escape key press
      else if (Input.GetKeyDown(KeyCode.Escape))
      {
        FindObjectOfType<GamePlay>().PauseGame();
      }
    }
    else if (Input.GetKeyDown(KeyCode.Escape))
    {
      FindObjectOfType<GamePlay>().UnpauseGame();
    }
  }

  /**
  * Start is called before the first frame update
  */
  void Start()
  {
    // If the starting position is not valid then game over
    if (!isValidGridPos())
    {
      Debug.Log("GAME OVER");
      FindObjectOfType<GamePlay>().ShowGameOverMenu();
      Destroy(gameObject);
    }
  }
}
