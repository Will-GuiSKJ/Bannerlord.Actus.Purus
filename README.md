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

## Ideas
1. Smithing rework
	- Player can smith weapons and armor through character dialog when at Town, and Castles of the clan they belong to if the Clan leader has favourable relations
	- If the Player owns the Town, it will have reduced prices when doing smithing, or if it has high relations with the Workshop or Castle owner
	- If the player owns the Smithy, it can do so for free just like how Smithing is now
	- A Player or a character from its Clan can use a Smithy they do not own, effectively renting it, for a price. This works very much like crafting is now and generates crafting XP
	- New Clan role for characters with Smithing skill. This will be the skill that governs how much loot equipment the player can get from battles. Looted equipment always comes with a severe cost debuff and are almost worthless to sell
1. Athelitics and Riding impact
	- evaluate minimum and maximum speeds
	- skill aproaches maximum speed early
	- skill aproaches armour weight mitigation late
1. Roguery rework
	- Roguery only impacts non-equipment loot and always generates some denars from battles won. (New bags of denar loot?)
	- New Clan role for characters with Roguery skill
1. Troop tree rework
	- Auto generate alternative gear set up for each unit so that it has at least 3 variants
	- All Tier one Faction troop should have either a shield or a two-handed weapon
1. Evaluate all melee skills impact on weapon speed and maximum damage
	- Archery should deal less damage?
	- Thrusting polearms should deal more damage!
1. Economic rework
	- Loot should be a poor source of income
	- Clans should maintain at least one caravan led by one of its members. More if in need of money
	- Clans should own workshops, at least one.
	- Clans with settlements should be in a better financial situation than Clans with not
1. War rework
	- War should only be declared for a specific goal. Once achieved, kingdom should protect its goal until the other party is ready to capitulate
	- War goal influences the target number of armies the AI will create, and how large each army will be.
		- If the desired number of armies fall bellow its target, the AI will try to create a new army
		- When armies are created, the invited parties will first try to maximize its party size and food provisions from its owned Settlements
		- Unlanded noble parties will try to first use any excess garrison troop from the ruler Settlements, than use any available Manpower the ruler may have
			- If that is still not enough, it will try to do the same thing from landed Clan nobles they have a strong positive relations with
	- War goal influences how many units will be needed in the armies. If kingdom does not have enough units it will try to hire Minor Factions or use its stored Manpower to conscript (generate) Tier 1 units
		- Each Clan leader decides his commitment to the war. From not showing up at all, causing massive relation drops, to commiting only a portion of its Garrison strength and Manpower, to bring his full force to bear
		- Conquered Settlements ownership voting is heavily influenced by how many war resources were committed by the participating Clans and relations with the ruler Clan
	- Wars can only end when one side has achieved its goal and the other side no longer thinks it can retake that goal
	- The empire factions start at war with each other
	- Each faction will have a score for each other Town and Castle in Calradia. Every time an Empire instigates war, it will be to conquer the Town or Settlement with the highest score.
	- When an empire is declared war upon, its goal are as follow, in order of priority: retake the attacking party war goal, protect the attacking party war goal, break sieging of the attacking party war goal, destroy enemy parties
	- If a war goal is secured, and the Settlement has good defenses (garrison at target and no walls breached), a new war goal will be added
	- Once a Clan's guarrisons have been depleted and its Manpower spent, it can no longer field parties
	- During war time, Clan parties are filled to capacity using their Garrison troops, or Manpower if needed
	- When not in an army, a Clan party is always in defense mode. 
	- **Double check how sieges affect a Settlement attributes and buildings**
1. Non-aggression pacts
	- Faction rulers can broke marriages between two clans from each faction. While said marriage exists, both kingdoms will be much less likely to go to war with each other
1. Alligiences
	- Factions can ask other factions to declare war with them for an ENOURMOUS amount of money
	- This is much cheaper, but still crazy expensive, if the two clans have a Non-aggression pact
1. Battle rework
	- Unit AI tweak so that it is competent at the 150+ skill level
1. Field battle Auto-resolve rework
	- Auto resolve will group units into the four basic groups: Melee, Foot Archer, Cavalry, Ranged Cavalry
	- Unit Groups are better at damaging certain types of Unit Groups, acting as one tier above its normal tier
	- Unit Group bonus are affected by the difference of the Tactic bonus of all noble participants in the battle
		- Each side starts with a base Tactics bonus equals to the party leader's Tactics skill. If multiple parties are involved in each side, tie breaker goes to highest Clan tier, then highest Leadership skill
		- Each side then adds the Tactics skills of all other nobles in their side. This number is multiplied by a value between 0 and 1 based on the party leader's Leadership skill and added to the overall Tactics bonus for their side
	- Unique
	- Combat happens in turns, where each turn one side has an attacking unit and a defending unit. The attacking unit chooses the defending unit for the other side
		- Ranged units always go first, potentially wreaking havoc on Melee and Cavalry units
	- Once a Foot Archer unit participates in 3 unit clashes, it becomes a Melee unit with an effective tier one below its normal tier
	- Once a Ranged Cavalry unit participates in 3 unit clashes, it becomes a Cavalry unit with an effective tier one below its normal tier
	- Starting morale dictates the threshold at which point one side routs, no longer attacking with any of its units
1. Siege battle Auto-resolve rework
	- Siege battles work like field battles, with a few distinctions
	- The sum of each wall's tier act like a Tactics boost for the defenders
	- The sum of each siege equipment acts like a Tactics boost for the their corresponding side
	- Cavalry units are considered as Melee units with an effective tier one below its normal tier from the very start of the battle
	- Ranged Cavalry units are considered as Foot Archer units with an effective tier one below its normal tier from the very start of the battle
	- Ranged units equipped with a Crossbow have a an increased bonus as a defender
	- Ranged units equiped with a Bow have an increased bonus as an attacker
1. Kingdom rework
	- Policies will be set for each kingdom at game start. Policy voting will be frozen unless for the player kingdom
	- Add policies tied to each kingdom that dictates how wars and peace can be declared
	- Add policies tied to each kingdom that dictates how it handles succession
	- Landed Clans of lower tier owe tithe to Clans of the immediate upper tier. Factions will be populated at game start to make sure pyramid of Clan tier hierarchy exists to support this
	- Unlanded Clans are opperate exactly like hired mercenaries, from a gameplay perspective, receiving money from the ruler
	- When not at war, landed Clan parties stay at their owned Settlements (based on Governorship assignments). Their parties consist of a small retinue of units taken from their Clan's Settlements, influenced by Clan tiers
		- Clan members are spread among the owned Settlements (Towns, Castles and Villages), with senior members being assigned to higher prosperity/hearth Settlements
	- When not at war, landed Clan parties do not move around, as their primary job while at peace is to oversee their Settlements
		- The exception is to go to Major Tournaments and Feasts
1. Cities rework
	- Provide great income through taxation
	- Can have criminal problems
	- Has a reduced regen rate for militia and garrison, compared to Castles
	- Has a lower garrison target number based on buildings, compared to Castles. Garrison up to the target number do not incour wages
	- Garrison is always of the ruling Clan troop line. Militia is always of the Culture troop line
	- Can't convert Tier 3+ garrison units into noble line
1. Castle rework
	- Don't provide as great income as Towns
	- Don't have to worry about criminals
	- Has an incrased regen rate for militia and garrison, compared to Cities
	- Has a higher garrison target number based on buildings, compared to Cities. Garrison up to the target number do not incour wages
	- Can convert Tier 3+ garrison units into noble line
	- Players should be able to smith weapons and armor at Castles. Castle smithies are not for-profit and do not operate like a Workshop
1. Villages rework
	- Villages no longer provide recruitable units
	- Villags instead provide Manpower points to its bound Settlement, which is converted into garrison by that Settlement or conscripts during war
		- Player Settlements do not auto generate Garrison, instead allowing the player to spend their Manpower points as they see fit
		- During war, players can only spend Manpower to recruit tier 1 units
	- Villages Manpower depends also depends on Notables relation to the owner Clan
1. Governorship
	- When Governors are at a Settlement, it can resolve the issues of that settlement. Bound Villages have a smaller/delayed chance of having its issues resolved, unless a Governor is placed directly at that Village
	- If the player owns a Settlement with no Governor, the player should act as its Governor while staying at the fief
	- AI should also be able to use Governors for any Settlement it owns
	- When player places a Clan member at a Village it does not own, it will instead act as an envoy to the owner Clan, increase relations between notables of that Village and the owner Clan. And in turn the player gains relations with the owner Clan
1. Desertion
	- Settlements can rebel if they are not of the same Culture as the owner Clan and loyalty, prosperity and security get too low. This will most likely happen when the owner Clan is at war and has depleated the garrison
	- Noble desertion should be very rare and immediatly trigger a war to retake the Settlements of said Noble, unless said noble's Settlements have a score lower than other Settlements that are not already part of the kingdom
1. Player Kingdom
	- Because noble desertion is very low, the player should endeavour to prepare quite a bit before starting a kingdom
	- The player should try to get their companions married to factions that will neighbour their new kingdom, so that they have some reprieve through Non-aggression pacts
	- Only companions of a minimal level can be promoted to Clan leaders under your kingdom
	- Player clan must be Clan tier 6, since all ruler Clans must be Clan tier 6
1. Renown rework
	- The amount of required Renonw to increase Clan level should be much higher
	- Quests should exist that reward a big lump sum of Renown to balance the higher Renow thresholds. These quests will act as effective social-political recognition of the a clan's new status
	- The amount of required Renow should make much less likely that AI Clans naturally increase in Clan tier
	- Special acts by the AI will trigger AI clans to raise or fall in level.
		- All ruler Clans must be Clan tier 6. If a clan, including the player's, get's promoted to clan Ruler, it will be given enough Renown to reach tier 6
		- If a Clan loses its status as the ruling Clan, it immediatly drops to Clan tier 5
		- If a Clan looses enough members that it would no longer be able to field its maximum number of parties, it drops a Clan tier
1. Marriage rework
	- Marriages that involve the player in some fashion will have Culture-dedicated quests, for role-playing purposes
	- Marrying someone from a Minor Faction to one of your Clan members, including the ruler, makes it cheaper to hire them as mercenaries
	- AI Clans will always marry within their kingdom, to maximize the number of potential nobles in a kingdom
	- Only Faction rulers can broke marriage between factions
	- Empire AI factions will not marry each other, as each desire above all else to reform the Claradic Empire by conquering the others
1. Minor Factions rework
	- Kingdoms will often give preference to hiring mercenaries from their own Culture
	- Bandit Minor Factions should be much more interwoven with the criminal gameplay
	- Kingdoms are always at war with their Cultural bandit Minor Faction
	- Rulers will pay good money for the execution of Minor Faction characters. This works for the AI too, but it depends on how much money the ruler has
	- Players with very good relations with a Minor Factions add their unit troop to the player Garissons' list of possible units they can spend Manpower on
1. Tournaments rework
	- Arena fights are a good way the player can train their combat skills during peace time
	- Regular Tournaments will happen less often, and never when the kingdom is at war
		- Nobles that are eligible to lead war parties and that are present at the Town hosting the Tournament will join
		- Nobles that are Governing a bound Village of the hosting Town will travel to the Town for the duration of the Tournament in order to participate
		- Tournament rewards are less expensive than Grand Tournaments
		- Tournaments that the player do not attend are resolved automatically
	- Grand Tournaments are hosted every so often during times of peace, and require the hosting Clan to have a good financial situation. No two Grand Tournaments can happen at the same time
		- Winning a Tournament grants a boost to relation between the hosting Clan and the winner Clan if relations between both were already neutral or positive.
			- If relations between the two were already negative, this relation worsens as the host Clan gets angry that their expensive event was used to boost a rival's Renown
		- All Clans will be invited
		- Clans with negative relations with the hosting Clan will decline the invitation, worsening relations further
		- Clans with neutral or positive relations with the hosting Clan will agree to attend
			- Clan nobles Governing Settlements with bad stats will not go, as they are needed at home
			- If a Clan does not have any noble that can go to the Tournament, it will decline the invitation
			- The Player will be given the opportunity to accept or decline the invitation. Accepting the invitation but failing to come will eventually auto decline the Player Clan, for an even larger relation penalty
		- The Tournament will only start when all parties that accepted arrive
		- During the Tournament, when Nobles, including the player, cause another to fall, there is a chance for relation gain or loss, based on the traits of the charaters involved and the existing relation between the Clans
			- This is intended to be a way to naturally make the political landscape of the kingdom change a bit, every so often. Same with Feasts.
		- Grand Tournaments that the player do not attend are resolved automatically
		- Kingdoms will not try to go to war if they have a Grand Tournament ongoing
		- Grand Tournaments are automatically cancelled if a war is declared
1. Feasts
	- When there is a death of a noble, a marriage or the conclusion of a victorious war, there is a chance that a Feast will be called if the kingdom is at peace
	- The Feast hosted by a higher Clan tier takes precedence, potentially causing the AI to cancel its scheduled feast so that the one for the higher Clan tier can happen
	- Feasts can be hosted by multiple Clans of the same-tier, causing a bit of a political ruckus, as nobles have to decide which one they will attend and which Clan will they slight
	- Much of the same logic for deciding each noble's attendace follows just like a Grand Tournament
	- Kingdoms will not try to go to war if they have a Feast ongoing
	- Feasts are automatically cancelled if a war is declared
	- All attending Clans gain small relations with each other. This gain is boosted if relations were already strong