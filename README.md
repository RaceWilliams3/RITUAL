# RITUAL
Game Systems 3 Production

Unity Version 2021.3.20

## Playable Build
https://racewilliams3.github.io/RITUAL/

## CREDITS
Hex Grid Math- https://www.redblobgames.com/grids/hexagons/

Shader Grid- https://www.youtube.com/watch?v=X8cVhNHQOv8

Post Processing - https://www.youtube.com/watch?v=ZzUOgsYXhrY

## CHANGE LOG
9/11/23 - 9/18/23 Changes:

Created a basic hex grid system with cells that can find their own neighbors. 
Also, put in basic mouse interaction and a simple test for cells notifying neighbors about things. 

9/19/23 - 9/26/23 Changes:

Reworked how tiles are tracked internally 
Added a manager to generate a new random tile to place 
Attempted to add scoring but things are broken 


9/27/23 - 10/3/23 Changes:

Added basic main menu
Added basic game loop with scoring 
Reworked some lights and materials for more atmosphere 

10/4/23 - 10/10/23 Changes:

Fixed rotation of tiles
Added buffer for deselecting tiles to get rid of weird flashing
Added a queue system for keeping track of upcoming tiles (not visible in the scene just yet)

10/11/23 - 10/17/23 Changes:

Swapped the pedestal model and added some textures (Color, bump, and normal)
Added preview tiles and fixed the queue system for upcoming tiles.

10/18/23 - 10/24/23 Changes:

Refactored some of the connector display and rotation code

10/25/23 - 10/31/23 Changes:

Added a shader to the connectors to look more interesting
Fixed the rotation of tiles

11/1/23 - 11/7/23

Added animation to the lights for vibes
Reordered the preview tiles to be clearer
Added background sound effects
Added rotating and placing sound effects
Added rotating in both directions with Q and E

11/8/23 - 11/14/23
Added a completely new menu with how-to and option menu. 
Added sound effects for the menu. 
Added post-processing effects. 
Added a hold function.

11/15/23 - 11/29/23
Moved how to screen to when you play so you have to look. 
Added a quick reference to controls when playing the game. 
