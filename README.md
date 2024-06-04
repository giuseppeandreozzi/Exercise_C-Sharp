# Exercise C\# 

This repository will contain some exercise from the book "The C# Player's Guide (5th Edition), RB Whitaker"


## Exercise list

**Level 24 - Tic Tac Toe**<br/>
A simple program that implement the game of Tic Tac Toe, playable via console. Where each square is represented by a number, following the structure of the numpad on a keyboard.

**Level 26 - The Old Robot**<br/>
A simple program that implement the commands (on, off and north, south, west, east movement) for a robot. The user can insert three commands in the console and the program will print the state of the robot after every command executed.

**Level 31 - The Fountain of Objects**<br/>
A simple program that implement a grid game where the user can navigate in a 4x4 grid in order to find and turn on the fountain of objects, then going back to the entrance to win the game

**Level 34 - Better Random**<br/>
Implements the following extensions methods for Random class: NextDouble that gives a maximum value for a randomly generated double, NextString that allows you to pass in any number of string values and randomly pick one of them and CoinFlip that randomly picks a bool value (It should have an optional parameter that indicates the frequency of heads coming up)

**Level 35 - Exepti's game**<br/>
A simple game where two users picks a number between 0 and 9, if this number coincides with the randomly chosen one the player will lose and the game will end.

**Level 36 - The Sieve**<br/>
A simple program where the user can choose between three filter and afterwards he can insert repeatedly a number to verify if the filter either support or not the number provided from the user.

**Level 37 - Charberry Trees**<br/>
A simple program to work with events. The source of the event is a class that represent a charberry trees and the two listeners are: the first to notify that the fruits has ripened and the second to automatically harvest them.

**Level 39 - The Long Game**<br/>
A simple game where the user can enter his username and every time he press a key his score increments. If the user press the key Enter the game stops and the program will save the user's score in a file which name is the user's name. Furthermore, the program will use the score saved as initial score for the next time the user will play.

**Level 40 - The Potion Masters of Pattren**<br/>
A program where the user can create a potion using some ingredients. Following these rules:
* All potions start as water. 
* Adding stardust to water turns it into an elixir. 
* Adding snake venom to an elixir turns it into a poison potion. 
* Adding dragon breath to an elixir turns it into a flying potion. 
* Adding shadow glass to an elixir turns it into an invisibility potion. 
* Adding an eyeshine gem to an elixir turns it into a night sight potion.
* Adding shadow glass to a night sight potion turns it into a cloudy brew. 
* Adding an eyeshine gem to an invisibility potion turns it into a cloudy brew. 
* Adding stardust to a cloudy brew turns it into a wraith potion. 
* Anything else results in a ruined potion.

N.B: Program made in order to work with pattern matching

**Level 41 - Navigating Operand City + Indexing Operand City + Converting Directions to Offsets**<br/>
A simple program to work with operator overloading, indexer and custom conversion.

**Level 42 - The Three Lenses**<br/>
A simple program to work with query expressions (both keyword and method call syntax)

**Level 43 - The Repeating Stream**<br/>
A simple program to work with threads. One thread generate a random numbers and another wait for the user to press a key to spot a repetition on the generation.

**Level 44 - Asynchronous Random Word + Many Random Words**<br/>
A simple program to work with async task. The user can insert many word as he wants and the program will run a task for each word to reproduce it. 

**Level 45 - Uniter of Adds**<br/>
A simple program to work with dynamic type checking. Builded a method that can make an addition on two variable of any type using *dynamic* type. 

**Level 45 - The Robot Factory**<br/>
A simple program to work with dynamic object. The program will ask the user to create a robot and the program will hold the information about it in a dynamic object. 

**Level 48 - Colored Console**<br/>
A simple program to work with class library. The *Colored Console* project will use *ConsoleLibrary* (inside the directory *ClassLibrary*) as a class library to display some text to the console.

**Level 48 - The Great Humanizer**<br/>
A simple program to work with NuGet package. The program will use the package *Humanizer.Core* to display the DateTime in a human-readable message.

**Level 52 - The Final Battle**<br/>
The final exercise of the book. It's a battle game that includes two parties: Heroes and Monsters, starting from heroes party a team member attack a random member on the monsters party, after that a monsters team member attack a random member on heroes party and so on until the heroes or the monsters are all killed. The game mode is Player vs Player, Player vs Computer and Computer vs Computer. The player at each his turn can choose between: Do nothing, standard attack and use an health potion (that heal the current team member of 10 hp).
The monsters party is divided in three layers: *Skeleton*, *Two skeletons* and *The Uncoded One* (the final boss), instead the heroes party include only the Hero that the user can give his a name.
Every time the heroes party kill all the enemies in a monsters party layer, the members of the next layer become the current target of the heroes party. The heroes party will win if they kill all the enemies in all three layers of the monsters party.