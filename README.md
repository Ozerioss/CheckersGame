## Synopsis

Checkers game made using Unity. It is a 3D game of a regular checkers game 

## Explanation of the classes and some of the code

The BoardManager class is applied to a chessboard on Unity so we can set the size of the List and put the reference to the assets in it.
In our case the List contains 4 objects : White checkers piece, Black checkers piece, White king and Black king. 
In BoardManager.cs we spawn all the checkers pieces and move them.
The checkers piece are assigned the Movement.cs script to give them a list of allowed moves.
The allowed moves array is then returned and used from the BoardManager to move the pieces from the movecheckerpiece() method.
A piece is selected when it is clicked once and the method SelectCheckersPiece() is found in BoardManager.cs class.
When a piece is selected we highlight the piece itself with an outline ( not yet in this build ) and highlight all the possible moves for the selected piece.
The method to highlight allowed moves can be found in the BoardHighlights.cs.
The highlight is set to public so we can modify the object from Unity ( modify the object itself or the material )

The Movement.cs class and King.cs class inherit from the Checkers.cs class which is an abstract class containing the CurrentX and CurrentY of each piece.
In Movement.cs we return the possible moves for a normal checkers piece ( either for the black team or the white team ).
In King.cs we return the possible moves for the King piece which is spawned only when we reach the end of the board ( when y == 7 for the black team and when y == 0 for the white team ).
The case where we spawn the king piece can be found in the BoardManager.cs class under the MoveCheckersPiece method.

## Builds

This was initially made to be installed on a Raspberry pi 3, but since we are using the input class this can be used with mouse and keyboard combo as well as 
a phone screen.
