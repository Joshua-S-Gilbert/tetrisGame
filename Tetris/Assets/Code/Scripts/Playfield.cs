using System.Collections;
using UnityEngine;

/**
* Playfield class manages the game grid and game objects
*/
public class Playfield : MonoBehaviour
{
  public static int w = GamePlay.FieldWidth; //!< playfield width based on field size option
  public static int h = 25; //!< playfield height
  public static Transform[,] Grid = new Transform[w, h]; //!< playfield grid

  /** 
  * Round the x and y coordinates of the vector so groups will
  * always move at block sizes of 1
  * @param v Vector to round
  */
  public static Vector2 RoundVector(Vector2 v)
  {
    return new Vector2(Mathf.Round(v.x),
                        Mathf.Round(v.y));
  }

  /** 
  * Check if a vector is inside the borders of the game
  * @param pos Vector to check position of
  */
  public static bool InsideBorder(Vector2 pos)
  {
    // x position must be greater than zero and less than the width of the grid
    // y position must be greater than zero 
    return ((int)pos.x >= 0 && (int)pos.x < w && (int)pos.y >= 0);
  }

  /** 
  * Delete a row that needs to be cleared
  * @param y Index of row to delete
  */
  public static void DeleteRow(int y)
  {
    // Loop through blocks in a row
    for (int x = 0; x < w; ++x)
    {
      // Destroy the game object and set the grid position to null
      Destroy(Grid[x, y].gameObject);
      Grid[x, y] = null;
    }
  }

  /** 
  * Decrease the y coordinate of a row when rows below it are cleared
  * @param y Index of row to decrease
  */
  public static void DecreaseRow(int y)
  {
    // Loop through blocks in a row
    for (int x = 0; x < w; ++x)
    {
      if (Grid[x, y] != null)
      {
        // Decrease block y coordinate by 1
        Grid[x, y - 1] = Grid[x, y];
        Grid[x, y] = null;

        // Update position of the block
        Grid[x, y - 1].position += new Vector3(0, -1, 0);
      }
    }
  }

  /** 
  * Helper function to decrease all the rows above a row that is going to be cleared
  * @param y Index of row to decrease above rows
  */
  public static void DecreaseRowsAbove(int y)
  {
    // Loop through rows up to the height
    for (int i = y; i < h; ++i)
    {
      DecreaseRow(i);
    }
  }

  /** 
  * Check if a row is full so it can be cleared
  * @param y Index of row to check if full
  */
  public static bool IsRowFull(int y)
  {
    // Loop through blocks in a row
    for (int x = 0; x < w; ++x)
    {
      // Check if there is a block at each coordinate
      if (Grid[x, y] == null)
      {
        return false;
      }
    }
    return true;
  }

  /** 
  * After a move, delete all the rows that are now full
  */
  public static void DeleteFullRows()
  {
    int rowsRemoved = 0;    // keep a counter of rows removed in one go
    for (int y = 0; y < h; ++y)
    {
      // If a row is full then delete it, decrease the rows above it,
      // update the total number of lines eliminated, and increment
      if (IsRowFull(y))
      {
        DeleteRow(y);
        DecreaseRowsAbove(y + 1);
        FindObjectOfType<GamePlay>().UpdateLinesEliminated(1);
        rowsRemoved++;
        --y;
      }
    }
    // Update the score according to the number of rows removed
    FindObjectOfType<GamePlay>().UpdateScore(rowsRemoved);
  }
}
