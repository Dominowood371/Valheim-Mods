# Valheim-Mods
Сonfiguration mods for the game Valheim.

<details>
  <summary>Cheat Commands</summary>
  
## Cheat Commands
To activate cheat commands, type `devcommands` and press enter. You'll be able to use the cheat commands below in singleplayer mode. They won't work on a multiplayer server.

To deactivate cheat commands, type `devcommands` and press enter again.

 **How to Read this List:**

- Anything between parentheses ( ) is a comment describing the command. (don't type these)
- Anything in brackets [ ] are arguments that the command takes. (don't add the brackets when using the commands)
- Not every command has arguments and sometimes not all arguments are required

**Examples:**
`wind [angle] [intensity 0-1]`
To use this in game you would replace [angle] and [intensity] with numbers.
`wind 45 0.5`

```
goto [x] [z] (teleport to coordinates)
goto 0 0
goto 25 60
```

```
spawn [prefabName] [amount] [level]
spawn Troll (spawns 1 troll)
spawn Troll 1 2 (spawns a single level 2 troll)
spawn Troll 5 (spawns 5 trolls)
```

```
beard (makes your chin bald)
debugmode (creative mode see below for info)
dpsdebug (toggle damage per second debug)
event [eventName] (start an event)
exploremap (remove fog of war)
freefly (toggles flying)
genloc
ghost
god (enables godmode)
goto [x] [y] [z] (teleport to coordinates)
hair (makes you bald)
heal
imacheater (toggle cheat mode)
killall (kills nearby enemies/creatures)
location (set spawn location)
model
players [number] (scales the difficulty see more info below)
pos (prints your coordinates)
puke
raiseskill [skillName] [amount] (adds amount of levels to skill)
randomevent (starts random event)
removedrops (removes all items on ground)
resetcharacter (resets skills and inventory)
resetmap (cover map in fog)
resetskill [skillName] (reset skill to zero)
resetwind
save
skiptime [seconds]
sleep (fast forwards time by one day. watch as the sun and moon zoom by)
spawn [prefabName] [amount] [level]
stopevent
tame (tames nearby creatures)
wind [angle] [intensity 0-1]

help — показать все доступные команды;
kick [имя игрока / ip игрока / userID] — убрать («кикнуть») пользователя;
ban [имя игрока / ip игрока / userID] — забанить пользователя;
unban [имя игрока / ip игрока / userID] — разбанить пользователя;
banned — показать список забаненных;
ping — отправить пинг на сервер, чтобы увеличить время между действиями пользователей и реакцией на них в самой игре;
lodbias [число] — изменить значение lod. Оно отвечает за изображение высокодетализированных объектов на расстоянии. По умолчанию — 1,5;
info — показать информацию о системе.
devcommands — активировать режим читов.
help — показать список читов;
god — включить бессмертие (режим бога);
ghost — включить режим призрака, при котором противники будут вас игнорировать;
pos — узнать текущую позицию (координаты) игрока;
goto [x,z] — телепортироваться в указанную точку по координатам;
exploremap — открыть всю карту;
resetmap — отменить исследование всей карты;
killall — убить всех ближайших врагов на расстоянии до 100 метров;
tame — приручить всех зверей в округе, которых можно сделать домашними животными, на расстоянии до 100 метров;
save — сохранить игру
removedrops — убрать все выпадающие предметы в области на расстоянии до 100 метров;
location — установить место вашего воскрешения;
genloc — сгенерировать локации заново;
wind [угол] [интенсивность] — задать направление и скорость ветра (0 — безветрие, 0,1-0,3 — слабый ветер, 0,4-0,6 — умеренный ветер, 0,7-1 — сильный ветер и шторм в море);
resetwind — перезапустить параметры ветра;
skiptime [секунды] — промотать время на указанное число секунд;
tod [число] — установить время дня: 0 и 1 — полночь, 0.5 — полдень, -1 — вернуться к значениям по умолчанию;
sleep — промотать один день;
setkey [имя] — установить новый глобальный ключ;
resetkeys [имя] — сбросить указанный глобальный ключ;
listkeys — показать список глобальный ключей;
dpsdebug — включить или выключить отображение урона в секунду.
env [название] — установить среду отладки;
reserenv — сбросить среду отладки;
players [число] — регулировка шкалы сложности. Чтобы снизить её до минимума, введите число 0. Если вы хотите повысить её, вводите числа целые числа (1, 2, 3). Уровень сложности влияет на урон и здоровье всех существ в игре.
```
## Creative Mode

### How to Enable Creative/Debug Mode

1. Follow the steps above to enable cheatmode
2. Type `debugmode` into the console without quotes

### Controls and Features

- **Z** - Toggles Flying
- **B** - No Placement Cost
- **K** - Kills all monsters

Using "No Placement Cost" mode (B) you can **repair all equipment** from your inventory, **place buildings for free** with a hammer, and **craft items for free** from your inventory.
  
</details>
