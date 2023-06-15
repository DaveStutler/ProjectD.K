# Game Basic Information #

## Summary ##

What will you do if your leader betrays you? As a local multiplayer 2-D puzzle platformer game, up to three players can work together (or not) to attempt to escape! Each pirate player has their own unique ability to escape danger and help each other succeed. Collect keys and treasure in order to escape each level and be one step closer to taking revenge and away from jail! 


## Gameplay Explanation ##

Each player has their own unique skill:
- Player 1: Press ‘W’, ‘A’, or ‘D’ keys for basic movement. Has a dash left or right after pressing ‘S’.

- Player 2: Press ‘I’, ‘J’, or ‘L’ keys for basic movement. Can grow and shrink in size when pressing ‘K’.

- Player 3: Uses the number pad keys ‘4’, ‘6’, or ‘8’ for basic movement. Doesn’t have another key for their ability but can double jump by pressing ‘8’ twice on the number pad.

Each player has a collision with each other, which is necessary at times to clear puzzles. 

Players are bound to the screen with the camera being unable to move when players are at opposing sides of the screen.

For best results, use and combine skills to their fullest in order to solve puzzles and obtain the three keys required to beat the level. 

Puzzles have platforms that are created or walls that are destroyed to get to the end of the level and need to be solved in order to obtain a key. 


**If you did work that should be factored into your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

Zahira Ghazali - Placing the assets into scenes (specifically Dungeon and Forest) and furnishing of the different scenes (so lighting, decorating, creation of prefabs etc.) and adapting the levels into the actual scene.


# Main Roles #

Your goal is to relate the work of your role and sub-role in terms of the content of the course. Please look at the role sections below for specific instructions for each role.

Below is a template for you to highlight items of your work. These provide the evidence needed for your work to be evaluated. Try to have at least 4 such descriptions. They will be assessed on the quality of the underlying system and how they are linked to course content. 

*Short Description* - Long description of your work item that includes how it is relevant to topics discussed in class. [link to evidence in your repository](https://github.com/dr-jam/ECS189L/edit/project-description/ProjectDocumentTemplate.md)

Here is an example:  
*Procedural Terrain* - The background of the game consists of procedurally-generated terrain that is produced with Perlin noise. This terrain can be modified by the game at run-time via a call to its script methods. The intent is to allow the player to modify the terrain. This system is based on the component design pattern and the procedural content generation portions of the course. [The PCG terrain generation script](https://github.com/dr-jam/CameraControlExercise/blob/513b927e87fc686fe627bf7d4ff6ff841cf34e9f/Obscura/Assets/Scripts/TerrainGenerator.cs#L6).

You should replay any **bold text** with your relevant information. Liberally use the template when necessary and appropriate.

## Producer

**Describe the steps you took in your role as producer. Typical items include group scheduling mechanism, links to meeting notes, descriptions of team logistics problems with their resolution, project organization tools (e.g., timelines, depedency/task tracking, Gantt charts, etc.), and repository management methodology.**

## User Interface: Yingyu Gu

**Describe your user interface and how it relates to gameplay. This can be done via the template.**

The user interface is an important part of our game because the scene with the play button and the scene where you can select the levels all play a large role in how our game functions. 

I designed the start menu and selection scene using the assets and tiles we added in order to make our game more interesting. In the start menu scene, there is a large PLAY button that will redirect the scene to a level select scene based on a script that I wrote. I added all the important scenes (start menu, selection scene, jail escape, dungeon, forest, a work in progress island scene, thank you scene, and a credit scene) to our build index so we can smoothly transition through all the necessary scene using Unity's `SceneManager`. ![alt text](https://cdn.discordapp.com/attachments/272048987295580171/1118682788820951050/image.png)

In the selection scene, I created a backgorund using tilemaps and added 4 large boxes to hold the short gif of each of our level gameplay. In each of those boxes I made a video player that can play a gif of each of the game's level to show  players a short preview of how each level is like. ![Image of the selection screne](https://media.discordapp.net/attachments/272048987295580171/1118683497796747264/image.png?width=2161&height=1093) I also added a small volume button on the top right and wrote a script that allows players to choose whether they want the menu background music to keep playing or not. 

Furthermore, I wrote a script that will lock the levels that they player has not reached yet. The player will be able to unlock the next level (this will cause the level to be brighter and will remove the chain) once they complete the previous level. ![Here is an image of the second scene unlocked](https://media.discordapp.net/attachments/272048987295580171/1118685217117437982/image.png?width=2161&height=1097) 

After the player reaches the last level in our game, they will be directed to a thank you scene. ![Thank you scene:](https://media.discordapp.net/attachments/272048987295580171/1118686867974537266/image.png?width=2161&height=1078) Once the player clicks at  a random place on the thank you scene. They will be brought to the final rolling credit scene that shows all our names aand roles. ![Credit scene:](https://media.discordapp.net/attachments/272048987295580171/1118687269096787989/image.png?width=2161&height=1097)

## Movement/Physics/Input: Zahira Ghazali

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

### Movement

For movement, each player is given a designated portion of the keyboard to use; each person gets a third of the entire keyboard to allow for multiple players on one keyboard. The player controllers for all three players used the original player controller on the first exercise as a base with tweaks added to make movement more precise and intuitive based on keyboard input and to allow for the abilities SizeUp, DoubleJump and Dash.

For instance, originally movement in either horizontal direction caused the sprite of the player to continue moving in that direction even after the key had been released by the player. This doesn't allow for as much control over the character by the player which is more of a necessity in our game as it is puzzle centered so I added an additional script to stop horizontal movement after the keyboard key had been released (StopHorizontalMovement.cs) was added that would cease all movement in the x-direction after the key being pressed (left or right key) had been released. Similarly, movement in the horizontal direction would stop after a period of time despite the player still holding the key on the keyboard which was not ideal as players would likely be controlling their characters one handed due to having three players on an individual keyboard; thus I added additional conditions to the standard movement in the player controllers to check for whether the key was being held or whether it had been released. In the event of a release, the player would immediately stop moving in that direction but if the player were to continue holding a direction, they would continue to move in that direction. Also, to prevent players from being able to jump infinitely anywhere in the scene, colliders and tags were used to only allow players to jump when they had collided with a platform that had the tag Floor. In the case of DoubleJump - the ability where the player could jump once in midair - a counter was used to allow the player to jump once more when not in contact with a collider as to prevent the infinite jump from occurring while still allowing the player with that ability to jump once in midair (the ability for DoubleJump was done by Yingyu Gu). Aside from these exceptions (stopping movement in the horizontal direction) movement for each of the player characters is fairly standard and conforms to the standard physics model. 


The scripts for each of the player controllers are linked below: 

[IPlayerController](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/IPlayerController.cs)
[Player1Controller](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/Player1Controller.cs)
[Player2Controller](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/Player2Controller.cs)
[Player3Controller](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/Player3Controller.cs)

The script stopping player movement in the horizontal direction:
[StopHorizontalMovement](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/StopHorizontalMovement.cs)


### Input and Interactions

In terms of input, besides keyboard input, there is the interactions between different objects in the scene. Specifically, the interaction between players and buttons to create or destroy platforms, the different types of platforms that were created, as well as the different types of buttons that were used throughout the scene. These will be discussed below starting with buttons and then platforms before finally ending with the door and key controller.  

#### Buttons

There are three types of button mechanics throughout the scene: buttons that create platforms, buttons that destroy platforms (or walls), and lastly invisible buttons that control platforms that appear and disappear. These three types of buttons allow players to progress through the scene either by providing ways to get around obstacles or destroying the obstacles themselves. 

[Button Creating Platform Script](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/ButtonCreatePlatform.cs)
[Button Destroying Platform Script](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/ButtonDestroyWall.cs)
[Button Controlling the Disappearing Platform](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/DestroyWobbly.cs)

#### Platforms

There are a few different types of platforms: Death platforms, Floor platforms, disappearing platforms, and checkpoints. The disappearing platform (also can be seen implemented in the button controlling the disappearing platform script) is a platform that appears and disappears in the same position. This is done by taking the original position of the first platform that had been in the scene and using that transform to spawn and destroy a new platform of the same prefab. Floor platforms are platforms that the player can walk across and jump off of; if the platform is not labeled with the floor tag the player will be able to walk across it but they will not be allowed to jump. Death platforms (or prefabs rather as Arrow also uses Death as a tag) are platforms that have the tag death. Walking across these or interacting with these will cause the player to die and cause them to respawn at the last interacted checkpoint. There are only two types of items with the Death tag: Death boxes (kill boxes that force the player back to the checkpoint instead of letting them fall forever), and Arrows which are projectiles made by the ArrowCreators which spawn the Arrows over time until they are destroyed (also through the ButtonDestroyWall). The last type of platform are Checkpoints which use the Checkpoint tag; these function as respawn points and are meant to serve as points from which the player can restart from rather than returning all the way back to the beginning of the level. 

The script for creating arrows can be seen below:

[ArrowCreator](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/ArrowController.cs)


#### Door and Key Controller

Rather than having a UI, the keys - once collected by the player - follow the player that collected them around. At the end of a level if all three players have a total of three keys then they can "open" the door at the end of the level and progress to the next stage. This is done through the DoorController that tracks the number of keys so far collected by the player; if the number of keys is equal to three the door automatically opens. The Door also serves as the SceneManager for each of the "level" like scenes. 

The scripts for the controller for the keys and the door can be seen below:
[Key Controller](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/KeyController.cs)
[Door Controller](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/DoorController.cs)

## Animation and Visuals: Huy Nguyen

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**



## Game Logic


**Document what game states and game data you managed and what design patterns you used to complete your task.**
Kaylie Lam:
I helped set up the main movement controls by using the Captain Controller Script from homework 1 as a basis for our own player controllers. I revised that code so that only the player movement of up, left, and right remains. I then copied those scripts into the rest of player 2 and 3 controller scripts so that they can then be individually key binded and given their abilities.

I also did the level design of the puzzles in the game. The tutorial level, called Jail escape, was a collaborative effort with the rest of the group in order to introduce game mechanics and player abilities for our group. I designed the rest of the three levels as a main part of my role. I didn’t design the level puzzles as much around the overall place of the level but rather instead for the development of the players’ game knowledge.
![tutorial](https://cdn.discordapp.com/attachments/1092602368375398482/1109050593579892736/IMG_1130.png)


Levels 1 and 2 were designed to be fairly short with focus on exploring the potentials for the players. Level 3, which was to be our final level, is focused around testing the players’ knowledge of the game.

Level 1, also known as the Dungeon level, was focused around showing some of the teamwork capabilities that each player has with each other as well as some more of the potential dangers to be seen in the game.
![alt text](https://cdn.discordapp.com/attachments/1092602368375398482/1118063675048218686/IMG_0109.png)




Level 2, also known as the Forest level, was focused on showing even more of what the players' individual skills can do as well as showing off more of the game’s mechanics. As seen by puzzle 3 having the size-shifting player to shrink in order to solve the puzzle.
![alt text](https://cdn.discordapp.com/attachments/1092602368375398482/1118063676126146580/IMG_0110.png)


Level 3, also known as the Island level, was focused around testing the players' overall knowledge of the game. At the time of designing, Zahira, who is in charge of narrative design, wanted to incorporate a secret ending that would unlock based on the level’s completion speed. So most of these puzzles were designed to be not that complicated yet be an obstacle in the way of getting the secret ending. Some beginning puzzles shown in the level design were meant to be more time wasting in solving the level. Knowledge of the game’s mechanics rather than the players’ would be tested in these types of puzzles. For example, the second puzzle in the designs below were designed to test camera knowledge, forcing the player to jump off of the platform in order for the camera to act as another platform for them to reach the button. But because these types of puzzles weren’t tested for feasibility, I made the level design document a bit more open so that the people implementing level designs were able to rearrange the puzzles for the level in any way they wanted, making it easy for them to not implement any that wouldn’t work.
![alt text](https://cdn.discordapp.com/attachments/1092602368375398482/1118063676751093820/IMG_0111.png)


Yingchen Gu:







# Sub-Roles

## Cross-Platform

**Describe the platforms you targeted for your game release. For each, describe the process and unique actions taken for each platform. What obstacles did you overcome? What was easier than expected?**
The primary platform that we targetted for our game release is that of PC thus there were no issues platforms wise. However, if given more time we would've liked to find a way to make the game truly multiplayer or at least use three different controllers as supposed to having different "regions" of the keyboard bound to each of the players. 

## Audio: Yingchen Gu

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing: Kaylie Lam

**Add a link to the full results of your gameplay tests.**

Link to each gameplay tests:
https://docs.google.com/document/d/1D_9nhd4iOXguF67Z_IPUJWIznvpqB5S6Lz76Yq2A4hg/edit?usp=sharing

**Summarize the key findings from your gameplay tests.**

Most of the suggestions in round 1 consisted of gameplay design critiques to likely enhance player experience. There was a couple missing components such as the button not working through being bound to an object. The only real bugs found was the camera box issue.



## Narrative Design: Zahira Ghazali

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 
The plot revolves around three pirates - Scrappy, Biggs, and Cappy - who were arrested after their old captain used them as bait to run away from the most recent kingdom they had plundered. It's been a while since the three of them have been stuck in the jail but one extremely early - really Biggs it's too early - morning they are able to successfully make their escape from their jail cells and decide to make a getaway. Except the more they progress towards the edge of the island they find the place increasingly devoid of life. Marlow their old torturer is missing as are much of the guardsman, the forest is dark and eerie and silent like it shouldn't be. Something is wrong.

With more time I would have liked to expand the story by adding interactable items acrosss all the levels and expanding into the fourth level where the pirates finally make their way to the edge of the island and are about to board a boat which would be the final stage of their "escape". If the players try to board the boat normally without interacting with anything the pirates find themselves in a dark void with nothing else around them and no idea where they are. This would be the so-called normal ending and the cliffhanger would mark the end of the game. Through the different interactions with objects scattered across the stages - encouraging the players to try "exploring" and find a reason behind the disappearances of people and creatures across the levels - the players would be able to get the "best ending" as supposed to the normal ending where they realize that something or someone is trying to literally "erase" them out of existence. Like a certain pirate captain that really should know better and probably knows that he'd better act quickly before they catch on. The last level would have been a timed trial with somewhat simpler puzzles in places but with a race against the clock in order to get this best ending. However due to time constraints the last level - level four - remains locked and we decided to put a cliffhanger on level three with level four marked as coming soon which will likely be expanded upon in the future. 

The story is told through text dialogue that occurs at the beginning of each scene as a part of the UI. The progression of the levels and the differing setting for each of the levels (beginning with Jail, going to Dungeon, going to Forest, ending at Island with them making a getaway) was a story design choice as to show the story arc of their escape. Assets used in each of the regions also reflect the overall setting of the region; for instance, in Jail there are two NPC characters locks in tiny squares, the room is darkly lit with only torches on the wall to see by etc. Similarly, Forest has lamps, fences, rocks and the buttons instead of being actual buttons like that found in either Dungeon or Jail are totems found throughout the level. 

[Dialogue Controller](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/Cutscene1Controller.cs)
[Extended Dialogue Controller (meant to appear after a while of gameplay)](https://github.com/DaveStutler/ProjectD.K/blob/72f8f8cc7c37f263c1a2f9fa15e4fed9b022f066/rip-off-picopark/Assets/Scripts/CutsceneForestDelayed.cs)

The story was written using the Cutscene1Controller.cs which outputted different strings assigned to it as a text in the Canvas UI. The specific font used was an asset chosen as it fit the overall somewhat pixel art like art-style of our game. 

[Pixel Font Style Asset](https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059)


## Press Kit and Trailer: Huy Nguyen

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel: Yingyu Gu

**Document what you added to and how you tweaked your game to improve its game feel.**

To improve the game feel, I added lock/unlock mechanics to the level selection. This improves how the player interacts the game because each level has a different name and the first level must be `Jail Escaape` sinc this has the tutorial. By locking certain levels, the game becomes self explanatory to the player since they can only select certain levels as they progress. It also allow players to have a sense of accomplishment when they unlock newer, more difficult levels. 

We also purposely decided to allow players to push each other in order to add a sense of chaos in the gameplay. This allows our game to put a huge emphasis on teamwork, since all the players must work together to achieve the same goal (without killing/pushing each other off the platform). Our players (3 players) are also all crammed into one keyboard, which makes the game feel more chaotic and exciting. 

Each of our audio choices also reflect the level map. For example, in the forest level, we chose to use "sugar plum fairy" piece to depict a creepy, but exciting feeling to our players. The music isn't too fast so players will not feel rushed when trying to complete the level. We also added a cute, but annoying footstep sound to add on to the chaos because getting the team annoyed at each other can also bring a new type of teamwork to the table. 

Overall, all of our asset, audio, and movement choices come together to create a chaotic but fun game feel, which is exactly what we are hoping to see when players play our game.
