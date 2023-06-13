# Game Basic Information #

## Summary ##

**A paragraph-length pitch for your game.**
What will you do if your leader betrays you? As a local multiplayer 2-D game, up to three players can work together (or not) to attempt to catch the pirate captain! Each pirate player has their own unique ability to escape danger and help each other succeed. Collect treasure in order to escape each level and be one step closer to taking revenge!

## Gameplay Explanation ##

**In this section, explain how the game should be played. Treat this as a manual within a game. It is encouraged to explain the button mappings and the most optimal gameplay strategy.**
Each player has their own unique skill:
Player 1: Press ‘W’, ‘A’, or ‘D’ keys for basic movement. Has a dash left or right when pressing ‘S’.
Player 2: Press ‘I’, ‘J’, or ‘L’ keys for basic movement. Can grow and shrink in size when pressing ‘K’.
Player 3: Uses the number pad keys ‘4’, ‘6’, or ‘8’ for basic movement. Doesn’t have another key for their ability but can double jump by pressing ‘8’ twice on the number pad.

Each player has a collision with each other, which is useful to solve puzzles with.

Players are bound to the screen with the camera being unable to move when players are at opposing sides of the screen.

For best results, use and combine skills to its fullest in order to solve puzzles.


**If you did work that should be factored in to your grade that does not fit easily into the proscribed roles, add it here! Please include links to resources and descriptions of game-related material that does not fit into roles here.**

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

## Movement/Physics: Zahira Ghazali

**Describe the basics of movement and physics in your game. Is it the standard physics model? What did you change or modify? Did you make your movement scripts that do not use the physics system?**

## Animation and Visuals: Huy Nguyen

**List your assets including their sources and licenses.**

**Describe how your work intersects with game feel, graphic design, and world-building. Include your visual style guide if one exists.**

## Input

**Describe the default input configuration.**

**Add an entry for each platform or input style your project supports.**

## Game Logic: Kaylie Lam and Yingchen Gu


**Document what game states and game data you managed and what design patterns you used to complete your task.**

Kaylie Lam:
I helped set up the main movement controls by using the Captain Controller Script from homework 1 as a basis for our own player controllers. I revised that code so that only the player movement of up, left, and right remains. I then copied those scripts into the rest of player 2 and 3 controller scripts so that they can then be individually key binded and given their abilities.

I also did the level design of the puzzles in the game. The tutorial level, called Jail escape, was a collaborative effort with the rest of the group in order to introduce game mechanics and player abilities for our group. I designed the rest of the three levels as a main part of my role. I didn’t design the level puzzles as much around the overall place of the level but rather instead for the development of the players’ game knowledge.
![alt text](https://cdn.discordapp.com/attachments/1092602368375398482/1109050593579892736/IMG_1130.png)



Yingchen Gu:








# Sub-Roles

## Cross-Platform

**Describe the platforms you targeted for your game release. For each, describe the process and unique actions taken for each platform. What obstacles did you overcome? What was easier than expected?**

## Audio: Yingchen Gu

**List your assets including their sources and licenses.**

**Describe the implementation of your audio system.**

**Document the sound style.** 

## Gameplay Testing: Kaylie Lam

**Add a link to the full results of your gameplay tests.**

**Summarize the key findings from your gameplay tests.**

## Narrative Design: Zahira Ghazali

**Document how the narrative is present in the game via assets, gameplay systems, and gameplay.** 

## Press Kit and Trailer: Huy Nguyen

**Include links to your presskit materials and trailer.**

**Describe how you showcased your work. How did you choose what to show in the trailer? Why did you choose your screenshots?**



## Game Feel: Yingyu Gu

**Document what you added to and how you tweaked your game to improve its game feel.**
