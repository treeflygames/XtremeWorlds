# Branch Notice
This 2.0.0 branch is currently unstable and should not be used for anything at the moment. It is full of unstable and experimental features and changes that might be implemented in future versions. Using it can and most likely will break any games made on the 1.X.X versions.

### What's New in Version 2.0.0

The 2.0.0 version is all about remaking the engine using some more up to date frameworks and coding patterns and practices. While most of the core functionality remains the same, there will be some serious behind the scenes changes that are for the goal of making the engine better and easier to maintain. Here is a list of some key features that have been changed or added:

- Added Entity Framework support for the game data database.

### Important Notes

The following things are important to note for users and developers to know when using the engine. These may before moved to their own wiki pages as needed at a later date, especially for the complex issues.

- **Changing Database Table Prefix**  
In order to change the database table prefix with the new entity framework powered database you need to create a migration after changing the table prefix setting in the configuration. After changing the prefix you will need to run the following dotnet command 'dotnet ef migrations add "ChangedTablePrefix"' and recompile the engine. There is no way around this at the current time, this is a limitation of the entity framework with no feasable workarounds.

&nbsp;  

MirageWorlds Game Engine
=================

Simple 2D ORPG Game Engine written in VB.Net
Based on the Orion+ conversion and MirageBasic.

What is it?
===========
This is a tilebased 2D ORPG game engine. It features a client and server application setup with a basic GUI on both ends.

Setup
===========
Install PostgreSQL and use the password for the database as mirage. You can change this in the source-code.
https://www.postgresql.org/

Game Features:
==============
Basic Character Creation/Class Selection
Movement/Attacking
NPC/Computer Characters for attacking
Items & Spells
Event System

Creation Features:
==================
The client has editors for the world (maps), items, spells, animations, npcs, and more from the in game admin panel.

How do I use this software?
===========================
If you are a programmer then you will probably prefer to compile the most recent version from source. Download the engine here, open up the solution in Visual Studio compile both projects and start the client and server application. They should connect automatically. IP and Port options are stored in the root/data (files)/config.ini files.

How do I access the editors?
============================
Log into the game with the client. On the server, open the player list, right click on your character and promote yourself to an admin. Go back to the client and tap Insert for each of the editor options.

Support & Updates:
==================
The home for this engine is [https://miragesource.net](https://web.miragesource.net/) if you need support or tips in game creation feel free to visit us. If you find any bugs feel free to report them on the official Mirage Source discord: https://discord.gg/49yhWHByFp

Im working on updating it to a more useable base to use.
