# HDT Plugin Example
A simple plugin for [Hearthstone Deck Tracker](https://github.com/Epix37/Hearthstone-Deck-Tracker) to illustrate some basic functionality and how to get started.
It displays your opponent's on curve class cards for his next turn.

![screenshot](http://i.imgur.com/dBBnawz.png)

## Building the Plugin

- Double clicking `PluginExample.sln` will open the project in Visual Studio.
- First thing to do is add a reference to the location of your Hearthstone Deck Tracker executable

![Add Reference](http://i.imgur.com/LLpgkOH.png)

and then set that references *Copy Local* property to false.
- Add another reference for the `HearthDB.dll` found in the same directory as the Hearthstone Deck Tracker executable.

![Copy Local](http://i.imgur.com/bhdqQ0T.png)
- You should then be able to build the plugin successfully.
- Go to your `PluginExample\bin\Release` folder and copy `PluginExample.dll` and `card.png` to the Hearthstone Deck Tracker Plugins folder.
