# MCBattleShip
Simple battleship game with WPF
Context:
This problem is based on the battleship game. The battle ship ground is a 10x10 grid.
A fleet is composed of a carrier (5 holes), battleship (4 holes), 1 destroyer (3 holes each), 1 submarine (3 holes) and 1 small assault chip.
A user places his fleet on the grid which remains fixed during the life of the game.

Goal:
We need a function which given a coordinate within the grid tells the caller whether the game is over (complete fleet is destroyed), whether it was a miss, or whether one of the boats was hit and if so, whether the boat sank (all holes have been hit).

Aditional information:
The map coordinates are in the range 0-9
All the cells in one ship have a liniar diplayment.
