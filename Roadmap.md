# Roadmap

## Guidelines
This roadmap details the features intendended to be included in Bannerlord - Actus Purus. Not all features have been evaluated for feasibility.

### Better Equipment Check
Check for better equipment for each slot in player's inventory or visiting shop.

### Settlement Icons
Icons that notify the player if a settlement has one of these:
1. Available Issues
2. High Relationship with Notable
3. Ongoing Tournament
> Icon visibility is based on Scout skill level

### Castle & Town Garrison Management
Gives castles and towns, both for player and AI, the ability to automatically recruit from connected villages into the garrison and train them to higher units.
1. Recruit availability depends on settlement owner's relationship with notables. Settlement recruits as soon as possible to simulate "first dibs" on local recruits
2. Garrison gains XP daily, troop tier capped at 3 for Towns and 6 for Castles
3. Recruitment is capped by owner's available income
4. Troop tier upgrade path chosen to maximize defense (no mounted units or polearm troops, heavy crossbow/archer troop bias)

### New Skill Systems
#### Scout
Scout skill affects _perceived_ party information, such as party size, while on the world map.
1. More accurate the closer the party is to hero's party
2. More accurate the higher the hero's Scout skill level is

Scout skill affects Castle's zone of control (More info in Castle section).

#### Leadership
1. Every (N)PC in an army receives small XP if army leader has a higher Leadership skill level and (N)PC has high relationship with leader. This simulates (N)PCs being in the leader's "inner circle"
	1. Extra XP if (N)PC has high Charm skill level

#### Tactics
1. Every (N)PC in an army receives small skill XP if army leader has a higher Tactics skill level and (N)PC has high relationship with leader. This simulates (N)PCs being in the leader's "inner circle"
	1. Extra XP if (N)PC has high Charm skill level

### Auto Resolve Calculations
#### General
1. Each unit is represented by 5 stats: AttackPower (based on unit weapon), AttackAccuracy (based on weapon skill level), Defense (based on unit armor), Health (100 + 25 if unit has a shield) and Morale
2. Initial Morale is affected by unit tier, commander Leadership skill level, Power Level difference, Cohesion (if Army) and Food supply
3. Each unit that dies causes Morale damage to 1 to 5 other units. When 0, unit routs and is removed from the roster
4. Global AttackPower bonus based on the difference of the Tactic skill level of defending and attacking parties
5. Small Global AttackAccuracy bonus based on the difference of the Scout skill level of defending and attacking parties

#### Field Battles
1. Lower Power Level party is set as the Defender. Higher Power Level party is set as the Attacker.
2. Each round, a unit chooses an eligible target and attack
2. Cavalry units have a bonus against ranged units
3. Ranged units have a bonus against infantry units
4. Infantry polearm units have a large bonus to AttackPower against cavalry units and give penalty to AttackAccuracy to Cavalry unit when defending
5. Cavalry units attacking priority is Ranged -> Cavalry -> Infantry
5. Ranged units attacking priority is Cavalry -> Infantry -> Ranged
5. Infantry units attacking priority is Infantry -> Ranged -> Cavalry

#### Sieges
1. Split between the approach and assault phases
2. Each round all units capable of attacking, do so. Defending units act first
3. All mounted units become either infantry or ranged units
4. Polearm units use secondary weapon and weapon skill instead
5. Infantry units have a bonus against ranged units
6. Siege weaponry is added to roster as a unit and troop units are removed to "man" the machines, non-ranged low-level troops are given priority to this assignment
	1. Target priority is Opposing Siege Weaponry -> Ranged -> Infantry
	2. When destroyed, units are __not__ added back to roster

##### Approach
###### Attackers
1. Ranged units are able to attack during approach, with a penalty to AttackAccuracy until invading the settlement
###### Defenders
1. Ranged units attack with a bonus to AttackAccuracy when targeting attacking units that are outside the walls

Approach phase ends when attacking army (plus towers/ram) reach the walls, units removed to man towers and ram are added back to roster.

##### Assault
###### Attackers
1. Each round, a number of attacking troops invade the settlement. Towers and breched gates provide higher throughput
	1. Battering ram, if available, attacks the gate until destroyed
	2. Once gate is destroyed, new pathway is created for attacking troops to invade
2. Once inside, infantry assaulting units are capable of attacking defending units
###### Defenders
1. Infantry units are able to attack any assaulting units inside the settlement

### AI
#### Ars Imperatoria
Faction Leader's create war plans when war is declared and communicates to all vassals, including PC.
Possible goals:
1. Border extension - Capture clump of Settlements, likely chosen when 2+ settlements near Faction's border are easily capturable
2. Economical warfare - Focus on village raids and caravans (Favourite of Sturgia), likely chosen when vassals are impoverished
3. War of attrition - Focus on destroying parties and take prisoners, likely chosen when neighboring faction has large number parties

### Kingdom
#### Castles vs. Towns
Castles and Towns should feel different to each other and provide different advantages.
1. Towns should be commercial centres and provide the bulk of taxes
	1. High criminal strength affects prosperity and siphons away taxes. High Roguery lords receive a taxation bonus however, to simulate politcal corruption
	2. Towns have high militia capacity and smaller garrison capacity, compared to Castles
2. Castles are military centres and provide high-level troops and access to noble lines, but reduced taxes
	1. Each minor faction is conected to a Castle, and gives small access to its troop line
	2. Castles have low militia capacity and high garrison capacity, compared to Towns
	3. Castles have an area of influence that warring parties, while inside, become succeptible to ambush by Castle garrison, affected by Scout skill level of castle governor
3. Castles, and Towns with a smithy, can provide forging services (crafting by proxy) to PC for a price
5. Governors are not stationary. Smaller vassals can be assigned as Governors instead of being granted a fief
	1. Governors behave more like lords, periodically patrolling the lands belonging to the fief with a subset of the Garrison	

#### Kingdom management
1. Extra tab in Kingdom screen for Military and Economical summaries of owned fiefs

#### Armies
1. (N)PC army leader with high relationship vassals gain bonus to Leadership/Tactics skill levels and lower cohesion depletion
2. (N)PC army leader with low relationship vassals gain penaltie to Leadership/Tactics skill levels and higher cohesion depletion
3. Armies with lots of mixed cultural troops loose cohesion quicker
4. Armies with low cohesion gain a penalty to Medinice and Tactics skill level

#### Religion
1. Each faction has its own religion, with all 3 Empire factions sharing the same religion
2. Small relation gain penalty for having different religion
3. Settlements with a Lord/Governor that has a different religion than populace applies penalty to loyalty
4. Ability to forcefully convert settlement to Lord's religion
5. Religius pressure between settlements

#### Multi-faction Treaties
1. Trade - Faction caravans give preference (and gain bonus money) to trade routes to factions in treaty
2. Defense - Factions will enter war to protect each other
3. Non Agression - Factions will not go to war with each other

#### World Events
1. Famine
2. Plague
3. Long Winters

### Issues
1. Minimise chance of _boring_ issues
2. Add new issues with more cultural flavour

### New Quests
Add more Campaign goals than just total domination. Including new Policies to support these new goals.
Potential goals:
1. Trading (money threshold)
2. Domination (default, conquer Calradia)
3. Religion (convert Calradia)
4. Diplomacy (peace length threshold + average relation threshold)

### Character Creation
Add many more background options to allow more different builds and role-play opportunities.

### Companions
1. Full auto level
2. Ability for PC to give companion party directives
	1. Protect fief
	2. Solve issues
	3. Recruit from specific faction	
