# HDT Plugin Example  [![Github Releases](https://img.shields.io/badge/plugin-HDT-e6af2b.svg)](https://github.com/HearthSim/Hearthstone-Deck-Tracker?maxAge=2592000) [![GitHub release](https://img.shields.io/github/release/andburn/hdt-plugin-example.svg?maxAge=604800)](https://github.com/andburn/hdt-plugin-example/releases/latest)

A simple plugin for [Hearthstone Deck Tracker](https://github.com/Epix37/Hearthstone-Deck-Tracker) to illustrate some basic functionality and how to get started.
It displays your opponent's on curve class cards for his next turn.

![screenshot](http://i.imgur.com/dBBnawz.png)

## Building the Plugin

- To build the plugin you first need to build a development version of [Hearthstone Deck Tracker](https://github.com/Epix37/Hearthstone-Deck-Tracker), this should be as simple as getting the source from github and opening and building the project in Visual Studio.
- The next step is to build the plugin, double clicking `PluginExample.sln` will open the project in Visual Studio.
- First thing to do is add a reference to the location of your Hearthstone Deck Tracker executable (compiled in the first step).

![Add Reference](http://i.imgur.com/LLpgkOH.png)

and then set that references *Copy Local* property to false.

![Copy Local](http://i.imgur.com/kbiMhko.png)

- Add another reference for the `HearthDB.dll` found in the same directory as the Hearthstone Deck Tracker executable.
- You should then be able to build the plugin successfully.
- Go to your `PluginExample\bin\Release` folder and copy `PluginExample.dll` to the Hearthstone Deck Tracker Plugins folder.
