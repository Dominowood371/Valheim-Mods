
# Spawn That! 

This is an advanced tool for configuring all world spawners.

With this, it is possible to change almost all of the default settings for the way spawners work in Valheim.
Want to have a world without trolls? Possible! (probably)
Want to have a world with ONLY trolls? Possible! (almost)
Want to have a world where greydwarves only spawn at night? Possible!
Just want to have more/less of a mob type? Simple modifiers exist!

# Features

- Change spawning rates of specific mobs
- Replace existing spawn configurations throughout the world
- Set almost any of the default parameters the game uses
- Add your own spawn configuration to the world
- Modify the localized spawners by mob type and location
- Dump existing game templates as files using the same format as the mod configs. 
	- Easy to copy-paste and change the parts you want.
	- Investigate what the world throws at you.
- Server-side configs
- Modify the spawners in camps, villages and dungeons
- Conditions and settings specific to integrated mods:
	- [Creature Level and Loot Control](https://valheim.thunderstore.io/package/Smoothbrain/CreatureLevelAndLootControl/)
	- [MobAILib](https://www.nexusmods.com/valheim/mods/1188)
	- [Epic Loot](https://valheim.thunderstore.io/package/RandyKnapp/EpicLoot/)

# Documentation

Documentation can be found on the [Spawn That! wiki](https://github.com/ASharpPen/Valheim.SpawnThat/wiki).


# Example 

```INI
[WorldSpawner.321]
Name = Angry Test Boars
PrefabName = Boar
Biomes = Meadows
Enabled = true
HuntPlayer=true
MaxSpawned = 30
SpawnInterval = 1
SpawnChance = 100
SpawnDuringDay = true
SpawnDuringNight = true
ConditionLocation = Runestone_Boars
ConditionDistanceToCenterMin = 500
ConditionAreaSpawnChance = 50

[WorldSpawner.321.CreatureLevelAndLootControl]
SetInfusion=Fire

[WorldSpawner.321.EpicLoot]
ConditionNearbyPlayerCarryLegendaryItem = HeimdallLegs
```
