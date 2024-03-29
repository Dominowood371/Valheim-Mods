
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
[WorldSpawner.0]
Name=deer
Enabled=True
Biomes=Meadows,BlackForest,
PrefabName=Deer
HuntPlayer=False
MaxSpawned=4
SpawnInterval=100
SpawnChance=50
LevelMin=1
LevelMax=3
LevelUpMinCenterDistance=0
SpawnDistance=64
SpawnRadiusMin=0
SpawnRadiusMax=0
RequiredGlobalKey=
RequiredEnvironments=
GroupSizeMin=1
GroupSizeMax=3
GroupRadius=5
GroundOffset=0.5
SpawnDuringDay=True
SpawnDuringNight=True
ConditionAltitudeMin=0
ConditionAltitudeMax=1000
ConditionTiltMin=0
ConditionTiltMax=35
SpawnInForest=True
SpawnOutsideForest=False
OceanDepthMin=0
OceanDepthMax=0
ConditionDistanceToCenterMin=0
ConditionDistanceToCenterMax=0
ConditionWorldAgeDaysMin=0
ConditionWorldAgeDaysMax=0

[WorldSpawner.123]
PrefabName=Boar
Name = Angry Boar
TemplateId=Boar_123
HuntPlayer = true
```

## Config Options 

| Setting | Type | Default | Example | Description |
| --- | --- | --- | --- | --- |
| [Name](#config-options-Name) | string | My spawner | Murder Dwarf 9000 | Just a field for naming the configuration template |
| [TemplateId](#config-options-TemplateId) | string | | Murder_Dwarf_9000 | Technical setting intended for cross-mod identification of mobs spawned by this template. Sets a custom identifier which will be assigned to the spawned mobs ZDO as 'ZDO.Set(\"spawn_template_id\", TemplateIdentifier)'
| [PrefabName](#config-options-PrefabName) | string | Deer | Greydwarf | Prefab name of the entity to spawn |
| [Enabled](#config-options-Enabled) | bool | true | false | Toggle this template on-off. This means the settings of this template will NOT be applied, it is not a way to disable existing mobs |
| [Biomes](#config-options-Biomes) | string | | Meadows, BlackForest | Biomes in which entity can spawn. Leave empty to allow all |
| [HuntPlayer](#config-options-HuntPlayer) | bool | false | true | Sets AI to hunt a player target |
| [MaxSpawned](#config-options-MaxSpawned) | int | 1 | 100 | Maximum number of prefab spawned in local surroundings |
| [SpawnInterval](#config-options-SpawnInterval) | int | 90 | 300 | Seconds between new spawn checks. |
| [SpawnChance](#config-options-SpawnChance) | int | 100 | 0 | Chance to spawn pr spawn check. Range 0 to 100 |
| [LevelMin](#config-options-LevelMin) | int | 1 | 35 | Minimum level to spawn |
| [LevelMax](#config-options-LevelMax) | int | 1 | 3 | Maximum level to spawn |
| [LevleUpMinCenterDistance](#config-options-LevleUpMinCenterDistance) | float | 0 | 2000 | Minimum distance from world center, to allow higher than min level
| [SpawnRadiusMin](#config-options-SpawnRadiusMin) | float | 0 | 40 | Minimum spawn distance from player. 0 defaults to 40 | 
| [SpawnRadiusMax](#config-options-SpawnRadiusMax) | float | 0 | 80 | Maximum spawn distance from player. 0 defaults to 80 |
| [SpawnDistance](#config-options-SpawnDistance) | float | 0 | 10 | Must not have another spawn of same prefab within this distance for this template to spawn |
| [RequiredGlobalKey](#config-options-RequiredGlobalKey) | string | | defeated_bonemass | Required global key to spawn |
| [RequiredNotGlobalKey](#config-options-RequiredNotGlobalKey) | string | | defeated_bonemass, KilledTroll | Global keys which disable the spawning of this template |
| [RequiredEnvironments](#config-options-RequiredEnvironments) | string | | Misty, Thunderstorm | Require one of the listed environments to spawn. Leave empty to allow all |
| [GroupSizeMin](#config-options-GroupSizeMin) | int | 1 | 3 | Minimum count to spawn at a time. Group spawning | 
| [GroupSizeMax](#config-options-GroupSizeMax) | int | 1 | 10 | Maximum count to spawn at a time. Group spawning |
| [GroupRadius](#config-options-GroupRadius) | float | 3 | 10 | Size of circle to spawn group inside. A spot within SpawnRadiusMin and SpawnRadiusMax will be picked as center of this circle |
| [GroundOffset](#config-options-GroundOffset) | float | 0.5 | 5 | Offset to ground to spawn at. Negative means below ground, the higher the further into the sky |
| [SpawnDuringDay](#config-options-SpawnDuringDay) | bool | true | false | Toggles spawning at day. Will also cause despawning for creatures at day if false |
| [SpawnDuringNight](#config-options-SpawnDuringNight) | bool | true | false | Toggles spawning during night | 
| [SpawnInForest](#config-options-SpawnInForest) | bool | true | false | Toggles spawning in forests |
| [SpawnOutsideForest](#config-options-SpawnOutsideForest) | bool | true | false | Toggles spawning outside forests |
| [OceanDepthMin](#config-options-OceanDepthMin) | float | 0 | 0 | Minimum ocean depth to spawn in. Ignored if min == max |
| [OceanDepthMax](#config-options-OceanDepthMax) | float | 0 | 0 | Maximum ocean depth to spawn in. Ignored if min == max |
| [ConditionAltitudeMin](#config-options-ConditionAltitudeMin) | float | -1000 | 123 | Minimum altitude (distance to water surface) to spawn at |
| [ConditionAltitudeMax](#config-options-ConditionAltitudeMax) | float | -1000 | 123 | Maximum altitude (distance to water surface) to spawn at |
| [ConditionTiltMin](#config-options-ConditionTiltMin) | float | 0 | 120 | Minimum tilt of terrain surface to spawn at |
| [ConditionTiltMax](#config-options-ConditionTiltMax) | float | 35 | 45 | Maximum tilt of terrain surface to spawn at |
| [ConditionDistanceToCenterMin](#config-options-ConditionDistanceToCenterMin) | float | 0 | 1000 | Minimum distance to center to spawn |
| [ConditionDistanceToCenterMax](#config-options-ConditionDistanceToCenterMax) | float | 0 | 5000 | Maximum distance to center to spawn. 0 means limitless |
| [ConditionWorldAgeDaysMin](#config-options-ConditionWorldAgeDaysMin) | float | 0 | 12 | Minimum world age in in-game days to spawn |
| [ConditionWorldAgeDaysMax](#config-options-ConditionWorldAgeDaysMax) | float | 0 | 35 | Maximum world age in in-game days. 0 means no max |
| [DistanceToTriggerPlayerConditions](#config-options-DistanceToTriggerPlayerConditions) | float | 100 | 55 | Distance of player to spawner, for player to be included in player based checks such as ConditionNearbyPlayersCarryValue |
| [ConditionNearbyPlayersCarryValue](#config-options-ConditionNearbyPlayersCarryValue) | float | 0 | 100 | Checks if nearby players have a combined value in inventory above this condition. Eg. If set to 100, entry will only activate if nearby players have more than 100 worth of values combined |
| [ConditionNearbyPlayerCarriesItem](#config-options-ConditionNearbyPlayerCarriesItem) | string | | IronScrap, DragonEgg | Checks if any nearby player have any of the listed item prefab names in inventory |
| [ConditionNearbyPlayersNoiseThreshold](#config-options-ConditionNearbyPlayersNoiseThreshold) | float | 0 | 80 | Checks if any nearby player has a noise level at or above the threshold |
| [ConditionNearbyPlayersStatus](#config-options-ConditionNearbyPlayersStatus) | string | | Wet, Burning | Checks if any nearby player has one of the listed status effects |
| [SetFaction](#config-options-SetFaction) | string | | Undead | Assign a specific faction to spawn. If empty uses default of prefab |
| [SetRelentless](#config-options-SetRelentless) | bool | false | true | When true, forces mob AI to always be alerted |
| [SetTryDespawnOnConditionsInvalid](#config-options-SetTryDespawnOnConditionsInvalid) | bool | false | true | When true, mob will try to run away and despawn when spawn conditions become invalid. Eg. if spawning only during night, it will run away and despawn at night. Currently this only take into account conditions for daytime and environment |
| [SetTryDespawnOnAlert](#config-options-SetTryDespawnOnAlert) | bool | false | true | When true, mob will try to run away and despawn when alerted |
| [SetTamed](#config-options-SetTamed) | bool | false | true | When true, mob will be set to tamed status on spawn. Only possible if mob can be tamed |
| [SetTamedCommandable](#config-options-SetTamedCommandable) | bool | false | true | Experimental. When true, will set mob as commandable when tamed. When false, whatever was default for the creature is used. Does not always seem to work for creatures not tameable in vanilla |
| [ConditionLocation](#config-options-ConditionLocation) | string | | Runestone_Boars, FireHole | Locations in which this template is enabled. Leave empty for all |
| [ConditionAreaSpawnChance](#config-options-ConditionAreaSpawnChance) | float | 100 | 1.5 | Chance for spawn to spawn at all in the area. The chance will be rolled once for the area. Range is 0 to 100. Eg. if a whole area of BlackForest rolls higher than the indicated chance, this spawn template will never be active in that forest. Another BlackForest will have another roll however, that may activate this template there. Chance is rolled based on world seed, area id and template index |
| [ConditionAreaIds](#config-options-ConditionAreaIds) | string | | 1, 123, 543 | Advanced feature. List of area id's in which the template is valid. Note: If ConditionAreaSpawnChance is not 100 or disabled, it will still roll area chance |

## Supplemental

Spawn That will load additional configurations from configs with names prefixed with `spawn_that.world_spawners.`

This allows for adding your own custom templates to Spawn That, or simply separate your configs into more manageable pieces.
Eg. `spawn_that.world_spawners.my_custom_configuration.cfg`

The configurations loaded will be merged with the one loaded from the main files.

Merging may override previously loaded spawner templates.


# Default 

```INI
[Default.100000]
Name=My spawner	                         Просто поле для наименования шаблона конфигурации
Enabled = True                           Включите или выключите этот шаблон. Это означает, что настройки этого шаблона НЕ будут применяться, это не может отключить уже существующих мобов.
Biomes = Meadows,                        Биомы, в которых может заспавниться сущность. Оставьте пустым, чтобы разрешить во все места
PrefabName = Deer                        Название ID создаваемой сущности
HuntPlayer = False                       Устанавливает ИИ для охоты на цель игрока
SetFaction =                             Назначьте для спавна определенную фракцию. Если пусто, используется идентификатор по умолчанию
MaxSpawned = 1                           Максимальное количество существ, порождаемых в окрестностях
SpawnInterval = 90                       Секунды между новыми проверками спавна существ.
SpawnChance = 100                        Вероятность спавна существ. Диапазон от 0 до 100
LevelMin = 1                             Минимальный уровень существа при спавне
LevelMax = 1                             Максимальный уровень существа при спавне
LevelUpMinCenterDistance = 0             Минимальное расстояние от мирового центра, чтобы уровень был выше минимального.
SpawnDistance = 0                        На этом расстоянии не должно быть другого спавна того же ID, чтобы этот шаблон мог появиться.
SpawnRadiusMin = 0                       Минимальное расстояние спавна от игрока. 0 по умолчанию равно 40
SpawnRadiusMax = 0                       Максимальное расстояние спавна от игрока. 0 по умолчанию равно 80
RequiredGlobalKey =                      Требуется глобальный ключ для спавна
RequiredNotGlobalKey =                   Глобальные ключи, которые отключают создание этого шаблона
RequiredEnvironments =                   Требуется одна из перечисленных условий погоды для спавна. Оставьте пустым, чтобы учитывать все
GroupSizeMin = 1                         Минимальное количество спавнов за одинраз. Групповой спавн
GroupSizeMax = 1                         Максимальное количество спавнов за один раз. Групповой спавн
GroupRadius = 3                          Размер круга для создания группы существ внутри. Место в SpawnRadiusMin и SpawnRadiusMax будет выбрано в качестве центра этого круга.
GroundOffset = 0.5                       Смещение к земле для спавна. Отрицательное означает, что под землей, чем выше, тем дальше в небо
SpawnDuringDay = True                    Включает спавн существа днем. Также будет вызывать исчезновение существ днем, если False
SpawnDuringNight = True                  Включает спавн существа ночью
ConditionAltitudeMin = -1000             Минимальная высота (расстояние до поверхности воды) для спавна
ConditionAltitudeMax = -1000             Максимальная высота (расстояние до поверхности воды) для спавна
ConditionTiltMin = 0                     Минимальный угол наклона поверхности для спавна
ConditionTiltMax = 35                    Максимальный угол наклона поверхности для спавна
SpawnInForest = True                     Включает спавн в лесах
SpawnOutsideForest = True                Включает спавн за пределами леса
OceanDepthMin = 0                        Минимальная глубина океана для появления. Игнорируется, если min == max.
OceanDepthMax = 0                        Максимальная глубина океана для появления. Игнорируется, если min == max.
ConditionDistanceToCenterMin = 0         Минимальное расстояние до центра для спавна
ConditionDistanceToCenterMax = 0         Максимальное расстояние от центра для спавна. 0 означает беспредельный
ConditionWorldAgeDaysMin = 0             Минимальный возраст мира в игровых днях для спавна
ConditionWorldAgeDaysMax = 0             Максимальный возраст мира в игровых днях для спавна. 0 означает отсутствует максимум.
DistanceToTriggerPlayerConditions = 100  Расстояние от игрока до спавна, чтобы игрок мог быть включен в проверки на основе игрока, такие как ConditionNearbyPlayersCarryValue
ConditionNearbyPlayersCarryValue = 0     Проверяет, есть ли у ближайших игроков значение переноса в инвентаре выше этого условия. Например. Если установлено значение 100, активируется только в том случае, если у ближайших игроков есть более 100 значений вместе взятых.
ConditionNearbyPlayerCarriesItem =       Проверяет, есть ли у любого из ближайших игроков в инвентаре какие-либо из перечисленных имён идентификаторов.
ConditionNearbyPlayersNoiseThreshold = 0 Проверяет, не превышает ли уровень шума у любого находящегося поблизости игрока пороговое значение.
SetRelentless = False                    Когда true, заставляет ИИ мобов всегда быть предупрежденным.
SetTryDespawnOnConditionsInvalid = False Когда true, существо попытается убежать и исчезнуть, когда условия спавна станут недействительными. Например. если он появляется только ночью, он убегает и исчезает ночью. В настоящее время учитываются только условия для дневного времени и окружающей среды.
SetTryDespawnOnAlert = False             Когда true, моб попытается убежать и исчезнет при получении предупреждения.
```
