# Bannerlord.Actus.Purus
["Pure Actuality"](https://en.wikipedia.org/wiki/Actus_purus)

**Bannerlord Supported Version: 1.5.7**

## Goal
This project is a mod for Mount &amp; Blade 2 Bannerlord that aims to create a perfected version of the game, in my eyes anyway. Though I plan for this mod to grow and include many facets, its main goal is to provide Quality of Life features and more Roleplaying content to the game, making the world of Calradia feel more alive.

To achieve such, these are my principles:
1. Keep as much of the core of Bannerlord intact, both as functionality as well as Lore.
1. Keep new functionality simple whenever possible. Complex functionality is hard to test, balance and maintain.
1. Add content to existing system rather than create new ones. Though new systems *may* be added in the future, the focus is largely on enhancing existing gameplay elements for a more enjoyable experience.
1. Modular & Configurable. Considering the various systems that will be affected by this mod, being able to turn off or configure each one is important so players can combine Actus Purus with other mods to create *their* vision of a perfected Bannerlord.
1. Self-contained. Basically, this means keeping requirements of other mods at a minimum, hopefully to 0.

## Features

### Character Presets
During Character Creation, you can now cycle through a number of male and female BodyProperties that you define in this mod's `Settings.xml` file.  
Any presets found on the Nexus or copied from Bannerlord character creation screen will work.  
The mod comes with a number of existing presets.

**Disclaimer:** Existing presets were pulled from my favourite Nexus creations and are *not* made by me. If you are one of the authors and wish me to remove your preset or would like me to credit it to you, please PM me.

### Blank Character Creation
When enabled, this will "reset" your character once the **Rebuild Your Clan** quest starts.  
This means all your Attributes and Skills will be set to 0 and all your Focus Points, Perks and Traits removed.  
You are then awarded 24 Attribute Points and 10 Focus Points to spend as you wish.

### Minor Faction Troop Recruitment
All minor factions now allow the player to recruit some of its junior troops through new Dialogs.  
Once your Clan is Tier 3 (or Tier 2 if you are of the same Culture as the minor faction) and once you reach 20 relation with heroes of the minor faction, you are able to recruit 20 of the lowest tier troop of that faction for 1000 denars.  
That faction will not allow you to recruit more until you have no more of those troops, meaning those recruits either upgraded or died.  
For players with high Roguery skill, the relation requirement is reduced to as little as 5 for outlaw minor factions.  
This is completely generic, meaning this *should* work with any custom minor faction such as those added by the [Calradia at War mod](https://www.nexusmods.com/mountandblade2bannerlord/mods/411).

### Generic Configurations
- Set starting cap of number of workshops for player, at Clan tier 0.
- Set starting cap of number of parties for player, at Clan tier 0.
- Set starting cap of number of companions for player, at Clan tier 0.
- Garrisons are made up of a configurable percentage of units from the settlement's owner's culture
	- Each day, a configurable number of garrison base troops are generated.
	- Ex: an Empire castle held by a Sturgian lord will have some of its automatically generated garrison units be Sturgian units

### Skills

#### Governor Perks
So many perks in Bannerlord have Governor facets, which are 100% useless to the player. Now, all Settlements owned by the player **without** a governor assigned, will use the player's character perks as if the player was the assigned governor.  
Many of the perks will still require that the player spend time in their settlement for them to take effect.

### Combat AI Progression
Vanilla Bannerlord unlocks the full potential of Combat AI prowess in a linear format based on the combat skill of the unit in question, from 0 prowess at Skill level 0 of a combat skill to full prowess at Skill level 350.  
This means that a unit with One Handed Skill at level 250 (a very high level) only has 5/7 of its AI Combat prowess unlocked.  
This option changes this linear progression to a logarithmic progression, meaning 80% of a unit's AI Combat prowess is unlocked at a combat Skill level of around 180, with the full 100% still unlocked at level 350.  
This will make combat more difficult, specially against AI Hero units.  
Vanilla difficulty combat settings are still respected and influence this progression accordingly.

### Combat Damage Multipliers
Vanilla Bannerlord allows the player to control the difficulty by allowing the player to choose how much damage the Player, its parties and friendly units can receive.  
This setting allows the player to control how much damage is dealt to all units, both friendly and enemy.  
This setting allows the player to gain some control over the *pace* of battle. Lengthening the engagements by lowering the overall damage that units do to each other, or speeding it up by increasing this damage.  
The vanilla difficulty settings are not overridden by this option, meaning that an easy difficulty coupled with a low Combat Damage Multiplier will make the game even **easier**.

### Crafting
- Heroes now restore stamina while moving in the world map, at a configurable rate.
- Configurable Stamina cost multipliers for Smelting, Smithing and Refining.
- Configurable Part Research XP multiplier.

### Equipment Battle Reward
- Allows a weighted chance (based on item value) of *any* equipment drop from a troop you have battled.
	- Each troop is evaluated based on its equipment set.
	- An item is chosen from that set based on a weighted (based on value) random chance.
	- Then the item is evaluated against a drop chance that is dependent on the ItemValueThreshold configuration.

### Passive XP Gain
Each day, several skills are awarded a set amount of XP for the player.
- XP can be awarded to all skills or only to those with Focus Points
- XP can be awarded to player character only or for all adult members of the player's Clan (including companions).
- Configurable Skill Level cap that determines whether a Skill can be awarded XP.
- Each individual Skill can be configurable to receive any amount of daily XP.

## Known Issues

### Character Presets
1. Sometimes the preset button stays on screen after closing the character creation screen
	- This usually happens when opening the character editor after the campaign has started.
1. Changing between genders can sometimes crash to desktop
	- This seems related to how some BodyProperties don't translate well between gender. This is a vanilla issue and it is **not** part of this mod.
1. Character Preset button layer is impacting the player's ability to rotate the character model during Character Creation
	- The Layer that contains the preset button has InputRestrictions on it, which is what *makes* the button clickable, but has the side effect of interfering with the click-and-drag to rate the character.

## Roadmap
For all the features I intend to add to this mod, please see the [Roadmap](https://github.com/Will-GuiSKJ/Bannerlord.Actus.Purus/blob/master/Roadmap.md).

## I Need Your Help!
One of the main things I want to add with this mod is a whole plethora of quests, starting with adding quests to Minor Factions to both flesh them out as well as give reputation so players can recruit their units.  
However, *coming up* with those quests is an exercise in imagination that a can't dedicate too much time to.  
So, if you have ideas for a cool questline for a minor faction or even for anything else please let me know!

## Modder Support
I have spent so many years enjoying the benefits of mods in my games, specially Skyrim, without ever supporting the authors.  
So now that I got into modding, it would be highly hypocritical for me to ask you to support me.

However, if you are one of those awesome people that support your mod authors and you wish to contribute monetarily in some way to this mod, I ask you that you make a donation to a local charity of your choice instead. I am particularly partial to animal shelters.