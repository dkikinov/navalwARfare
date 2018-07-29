# navalwARfare
## Inspiration
At AdrenaLAN, we wanted to do something that would breathe life back into the classics. And so, we chose to homage Battleship. Despite it's popularity, even the classics get forgotten. With AR being more and more accessible, we decided to improve the classic by adding more factors and dimensions (literally) to help bring this classic game back into the spotlight. 

## What it does
Users place down their naval units (each in secret) within a unique 3D grid. Users then take turns firing at where they believe the opponent's units are. Rather than picking set locations, users will fire in a line at their chosen coordinate. The game will register any hits, and alternate turns until one player has lost all of their naval units.

## How we built it
The game was built in Unity 3D where it conceptualized and built locally to play within a single screen. This concept was then put on top of an AR marker using Vuforia to allow the players more freedom with their views. Online multiplayer was attempted, but proved far too time-consuming to be implemented.

## Challenges we ran into
Unity Networking at it's basic form is for real-time games where each player sends updates to the server and the server updates all clients with the movements. Since Naval wARfare is a turn based game it proved to be more difficult as the server would be required to block one player while the other took their turn and vice versa. With the way the code was setup, it would have needed to be rewritten almost in full to accommodate this change.

AR scaling was also a bit of a challenge. We wanted the game to be playable and fully visible, but without requiring too much physical space.

## Accomplishments that we're proud of
The game is working mostly as intended. Players are able to play off of one device in AR with all the expected strategy.

## What we learned
Unity Networking requires a lot of additional set up for turn-based games. Unity and AR were both new to some of the team members so this was a great learning experience in those technologies as well.

## What's next for Naval wARfare
Hopefully implement that damn online multiplayer. Potentially release on the Play Store.
