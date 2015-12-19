# HDT Plugin Example
A simple plugin for [Hearthstone Deck Tracker](https://github.com/Epix37/Hearthstone-Deck-Tracker) to illustrate some basic functionality and how to get started.
A text box in the center of the screen displays the names of the cards currently in the players hand.

## Building the Plugin

- Double clicking `PluginExample.sln` will open the project in Visual Studio.
- First thing to do is add a reference to the location of your Hearthstone Deck Tracker executable

![Add Reference](http://i.imgur.com/LLpgkOH.png)

and then set that references *Copy Local* property to false.

![Copy Local](http://i.imgur.com/bhdqQ0T.png)
- You should then be able to build the plugin successfully.
- Go to your `PluginExample\bin\Release` folder and copy `PluginExample.dll` and `card.png` to the Hearthstone Deck Tracker Plugins folder.
