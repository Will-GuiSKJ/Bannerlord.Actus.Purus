# Roadmap

## Guidelines
This roadmap details the features intendended to be included in Bannerlord - Actus Purus. Not all features have been evaluated for feasibility.

### Castle & Town Garrison Management
Gives castles and towns, both for player and AI, the ability to automatically recruit from connected villages into the garrison and train them to higher units.
1. Recruit availability depends on settlement owner's relationship with notables. Settlement recruits as soon as possible to simulate "first dibs" on local recruits
1. Garrison gains XP daily, troop tier capped at 3 for Towns and 6 for Castles
1. Recruitment is capped by owner's available income
1. Troop tier upgrade path chosen to maximize defense (no mounted units or polearm troops, heavy crossbow/archer troop bias)

### New Skill Systems
#### Scout
Scout skill affects _perceived_ party information, such as party size, while on the world map.
1. More accurate the closer the party is to hero's party
1. More accurate the higher the hero's Scout skill level is

Scout skill affects Castle's zone of control (More info in Castle section).

#### Leadership
1. Every (N)PC in an army receives small XP if army leader has a higher Leadership skill level and (N)PC has high relationship with leader. This simulates (N)PCs being in the leader's "inner circle"
	1. Extra XP if (N)PC has high Charm skill level

#### Tactics
1. Every (N)PC in an army receives small skill XP if army leader has a higher Tactics skill level and (N)PC has high relationship with leader. This simulates (N)PCs being in the leader's "inner circle"
	1. Extra XP if (N)PC has high Charm skill level

### Auto Resolve Calculations
TBD.

### AI
#### Ars Imperatoria
Faction Leader's create war plans when war is declared and communicates to all vassals, including PC.
Possible goals:
1. Border extension - Capture clump of Settlements, likely chosen when 2+ settlements near Faction's border are easily capturable
1. Economical warfare - Focus on village raids and caravans (Favourite of Sturgia), likely chosen when vassals are impoverished
1. War of attrition - Focus on destroying parties and take prisoners, likely chosen when neighboring faction has large number parties

### Kingdom
#### Castles vs. Towns
Castles and Towns should feel different to each other and provide different advantages.
1. Towns should be commercial centres and provide the bulk of taxes
	1. High criminal strength affects prosperity and siphons away taxes. High Roguery lords receive a taxation bonus however, to simulate politcal corruption
	1. Towns have high militia capacity and smaller garrison capacity, compared to Castles
1. Castles are military centres and provide high-level troops and access to noble lines, but reduced taxes
	1. Castles have low militia capacity and high garrison capacity, compared to Towns
	1. Castles have an area of influence that warring parties, while inside, become succeptible to ambush by Castle garrison, affected by Scout skill level of castle governor
1. Castles, and Towns with a smithy, can provide forging services (crafting by proxy) to PC for a price
1. Governors are not stationary. Smaller vassals can be assigned as Governors instead of being granted a fief
	1. Governors behave more like lords, periodically patrolling the lands belonging to the fief with a subset of the Garrison	

#### Kingdom management
1. Extra tab in Kingdom screen for Military and Economical summaries of owned fiefs

#### Armies
1. (N)PC army leader with high relationship vassals gain bonus to Leadership/Tactics skill levels and lower cohesion depletion
1. (N)PC army leader with low relationship vassals gain penaltie to Leadership/Tactics skill levels and higher cohesion depletion
1. Armies with lots of mixed cultural troops loose cohesion quicker
1. Armies with low cohesion gain a penalty to Medinice and Tactics skill level

#### Religion
1. Each faction has its own religion, with all 3 Empire factions sharing the same religion
1. Small relation gain penalty for having different religion
1. Settlements with a Lord/Governor that has a different religion than populace applies penalty to loyalty
1. Ability to forcefully convert settlement to Lord's religion
1. Religius pressure between settlements

#### Multi-faction Treaties
1. Trade - Faction caravans give preference (and gain bonus money) to trade routes to factions in treaty
1. Defense - Factions will enter war to protect each other
1. Non Agression - Factions will not go to war with each other

#### World Events
1. Famine
1. Plague
1. Long Winters
1. Foreign Invasion

### New Endgame(s)
Add more Campaign goals than just total domination. Including new Policies to support these new goals.
Potential goals:
1. Trading (money threshold)
2. Domination (default, conquer Calradia)
3. Religion (convert Calradia)
4. Diplomacy (peace length threshold + average relation threshold)

### New Quests & Dialogues
1. More dialogue variation in existing conversations to better the roleplay aspect
2. Enhanced minor quests with better story arcs
1. Add new quests, including fleshing out minor factions

### Character Creation
Add many more background options to allow more different builds and role-play opportunities.

### Fun Defeat
Add more mechanics to make having your party wiped out and being taken prisoner be more fun (or at least less soul crushin).
