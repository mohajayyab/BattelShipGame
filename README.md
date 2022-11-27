# BattelShipGame
Built a console battel ship game with 2 players using OOP C#.

In this game there are two players as commanders of their naval fleet and the goal is to destroy the opponents fleet.
The gamespace is represented by a 10×10-sized table on which battleships are placed. These ships are rectangles with sizes from 4×1 to 1×1. The gameplay is defined as below.
1-Firstly, battleships are placed on the table by players from the largest ones to the smallests. A ship can be placed both vertically and horizontally, but two ships cannot intersect.
2-After ships are placed, players can shoot in turns to fields of the table by giving their row and column indices. If a targeted field has a (part of a) battleship on it, the shot hits that ship and the field gets marked by red. If all the parts of a ship were hit, it sinks (and removed from the game).
3-The player who destroys all the opponents ships first, wins.


