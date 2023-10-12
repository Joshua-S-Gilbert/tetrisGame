# 2805ICT/3815ICT Assignment - Tetris

## Group 14

### Group Members:
- Lana Maller s5133498
- Joshua Gilbert s5233877
- Rio Nagata s5220717
- Zhendong Su s5123627

<br />

# Source Code

## Game Play
### GamePlay.cs:
Stores the game mode, score, number of lines cleared, level, game type and field width. This script contains functions for updating the score based on the number of lines cleared as well as updating the number of lines eliminated after each line is cleared in game. The text for displaying the game settings, score etc., is also managed in this script. When the settings are changed in the options menu, they are reflected in the game play scene handled by this script.
### Group.cs:
Contains functions relevant to an individual group (game piece). The private functions include isValidGridPos which checks if a group's new position is valid, and upgradeGrid which deleted the old group from the scene and displays the new group. There is a function that is called once per frame that checks for key presses to move the pieces accordingly. The left, right and down arrow keys move the pieces, while the up arrow key rotates the piece 90 degrees. When the escape key is pressed it will load the PauseMenu scene.
### Playfield.cs:
Sets up the game field size and grid to use when moving/deleting blocks. Contains functions for deleting full rows and decreasing the y position of rows above. Also has a function that checks if a group is inside the border of the game space.
### Spawner.cs:
Checks if the game mode is extended or normal and picks a random group from the appropriate list of groups (7 groups for normal and 9 for extended). When the script is first called it calls SpawnNext() to spawn the first group.

---
## Menus
### LeaderboardMenu.cs:
Displays the top scores in a separate menu
### MainMenu.cs:
Handles the scenes to load when the 'Play' and 'Quit' buttons are pressed.
### OptionsMenu.cs:
Updates the in game settings (music volume, game mode, field size, game type etc.) when the buttons, dropdowns or sliders are changed.
### PauseMenu.cs:
Handles the scenes to load when the 'Resume' and 'Quit to Main Menu' buttons are pressed.

---
## Sound Management
### AudioManager.cs:
Sets up all the sounds used in the game and contains functions for playing them.
### Sound.cs:
Sets up a single sound to be used in the game.

<br />

# Number of Lines
- **GamePlay.cs:** 96 lines
- **Group.cs:** 124 lines
- **Playfield.cs:** 102 lines
- **Spawner.cs:** 30 lines
- **LeaderboardMenu.cs:** 34 lines
- **MainMenu.cs:** 20 lines
- **OptionsMenu.cs:** 181 lines
- **PauseMenu.cs:** 31 lines
- **AudioManager.cs:** 66 lines
- **Sound.cs:** 25 lines

**Total Lines:** 709 lines

<br />

# Naming Convention
The code has been implemented with the naming conventions of C# in mind. All public classes, variables and functions are named with Pascal Case (e.g. GamePlay), while private variables and functions are named with Camel Case (e.g. updateGrid).

**Examples:**

public (Pascal Case)

`public class Group`

`public static int FieldWidth`

`public void UpdateLinesEliminated(int num)`

private (Camel Case)

`float lastFall`

`int rowsRemoved`

`void updateGrid`
