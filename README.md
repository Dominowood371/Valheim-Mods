# Valheim-Mods
–°onfigurations for mods of the game Valheim.

<details>
  <summary>Cheat Commands</summary>
  
## Cheat Commands
To activate cheat commands, type `devcommands` and press enter. You'll be able to use the cheat commands below in singleplayer mode. They won't work on a multiplayer server.

To deactivate cheat commands, type `devcommands` and press enter again.

Type `debugmode` into the console without quotes
  
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

help ‚ÄĒ –Ņ–ĺ–ļ–į–∑–į—ā—Ć –≤—Ā–Ķ –ī–ĺ—Ā—ā—É–Ņ–Ĺ—č–Ķ –ļ–ĺ–ľ–į–Ĺ–ī—č;
kick [–ł–ľ—Ź –ł–≥—Ä–ĺ–ļ–į / ip –ł–≥—Ä–ĺ–ļ–į / userID] ‚ÄĒ —É–Ī—Ä–į—ā—Ć (¬ę–ļ–ł–ļ–Ĺ—É—ā—Ć¬Ľ) –Ņ–ĺ–Ľ—Ć–∑–ĺ–≤–į—ā–Ķ–Ľ—Ź;
ban [–ł–ľ—Ź –ł–≥—Ä–ĺ–ļ–į / ip –ł–≥—Ä–ĺ–ļ–į / userID] ‚ÄĒ –∑–į–Ī–į–Ĺ–ł—ā—Ć –Ņ–ĺ–Ľ—Ć–∑–ĺ–≤–į—ā–Ķ–Ľ—Ź;
unban [–ł–ľ—Ź –ł–≥—Ä–ĺ–ļ–į / ip –ł–≥—Ä–ĺ–ļ–į / userID] ‚ÄĒ —Ä–į–∑–Ī–į–Ĺ–ł—ā—Ć –Ņ–ĺ–Ľ—Ć–∑–ĺ–≤–į—ā–Ķ–Ľ—Ź;
banned ‚ÄĒ –Ņ–ĺ–ļ–į–∑–į—ā—Ć —Ā–Ņ–ł—Ā–ĺ–ļ –∑–į–Ī–į–Ĺ–Ķ–Ĺ–Ĺ—č—Ö;
ping ‚ÄĒ –ĺ—ā–Ņ—Ä–į–≤–ł—ā—Ć –Ņ–ł–Ĺ–≥ –Ĺ–į —Ā–Ķ—Ä–≤–Ķ—Ä, —á—ā–ĺ–Ī—č —É–≤–Ķ–Ľ–ł—á–ł—ā—Ć –≤—Ä–Ķ–ľ—Ź –ľ–Ķ–∂–ī—É –ī–Ķ–Ļ—Ā—ā–≤–ł—Ź–ľ–ł –Ņ–ĺ–Ľ—Ć–∑–ĺ–≤–į—ā–Ķ–Ľ–Ķ–Ļ –ł —Ä–Ķ–į–ļ—Ü–ł–Ķ–Ļ –Ĺ–į –Ĺ–ł—Ö –≤ —Ā–į–ľ–ĺ–Ļ –ł–≥—Ä–Ķ;
lodbias [—á–ł—Ā–Ľ–ĺ] ‚ÄĒ –ł–∑–ľ–Ķ–Ĺ–ł—ā—Ć –∑–Ĺ–į—á–Ķ–Ĺ–ł–Ķ lod. –ě–Ĺ–ĺ –ĺ—ā–≤–Ķ—á–į–Ķ—ā –∑–į –ł–∑–ĺ–Ī—Ä–į–∂–Ķ–Ĺ–ł–Ķ –≤—č—Ā–ĺ–ļ–ĺ–ī–Ķ—ā–į–Ľ–ł–∑–ł—Ä–ĺ–≤–į–Ĺ–Ĺ—č—Ö –ĺ–Ī—ä–Ķ–ļ—ā–ĺ–≤ –Ĺ–į —Ä–į—Ā—Ā—ā–ĺ—Ź–Ĺ–ł–ł. –ü–ĺ —É–ľ–ĺ–Ľ—á–į–Ĺ–ł—é ‚ÄĒ 1,5;
info ‚ÄĒ –Ņ–ĺ–ļ–į–∑–į—ā—Ć –ł–Ĺ—Ą–ĺ—Ä–ľ–į—Ü–ł—é –ĺ —Ā–ł—Ā—ā–Ķ–ľ–Ķ.
devcommands ‚ÄĒ –į–ļ—ā–ł–≤–ł—Ä–ĺ–≤–į—ā—Ć —Ä–Ķ–∂–ł–ľ —á–ł—ā–ĺ–≤.
help ‚ÄĒ –Ņ–ĺ–ļ–į–∑–į—ā—Ć —Ā–Ņ–ł—Ā–ĺ–ļ —á–ł—ā–ĺ–≤;
god ‚ÄĒ –≤–ļ–Ľ—é—á–ł—ā—Ć –Ī–Ķ—Ā—Ā–ľ–Ķ—Ä—ā–ł–Ķ (—Ä–Ķ–∂–ł–ľ –Ī–ĺ–≥–į);
ghost ‚ÄĒ –≤–ļ–Ľ—é—á–ł—ā—Ć —Ä–Ķ–∂–ł–ľ –Ņ—Ä–ł–∑—Ä–į–ļ–į, –Ņ—Ä–ł –ļ–ĺ—ā–ĺ—Ä–ĺ–ľ –Ņ—Ä–ĺ—ā–ł–≤–Ĺ–ł–ļ–ł –Ī—É–ī—É—ā –≤–į—Ā –ł–≥–Ĺ–ĺ—Ä–ł—Ä–ĺ–≤–į—ā—Ć;
pos ‚ÄĒ —É–∑–Ĺ–į—ā—Ć —ā–Ķ–ļ—É—Č—É—é –Ņ–ĺ–∑–ł—Ü–ł—é (–ļ–ĺ–ĺ—Ä–ī–ł–Ĺ–į—ā—č) –ł–≥—Ä–ĺ–ļ–į;
goto [x,z] ‚ÄĒ —ā–Ķ–Ľ–Ķ–Ņ–ĺ—Ä—ā–ł—Ä–ĺ–≤–į—ā—Ć—Ā—Ź –≤ —É–ļ–į–∑–į–Ĺ–Ĺ—É—é —ā–ĺ—á–ļ—É –Ņ–ĺ –ļ–ĺ–ĺ—Ä–ī–ł–Ĺ–į—ā–į–ľ;
exploremap ‚ÄĒ –ĺ—ā–ļ—Ä—č—ā—Ć –≤—Ā—é –ļ–į—Ä—ā—É;
resetmap ‚ÄĒ –ĺ—ā–ľ–Ķ–Ĺ–ł—ā—Ć –ł—Ā—Ā–Ľ–Ķ–ī–ĺ–≤–į–Ĺ–ł–Ķ –≤—Ā–Ķ–Ļ –ļ–į—Ä—ā—č;
killall ‚ÄĒ —É–Ī–ł—ā—Ć –≤—Ā–Ķ—Ö –Ī–Ľ–ł–∂–į–Ļ—ą–ł—Ö –≤—Ä–į–≥–ĺ–≤ –Ĺ–į —Ä–į—Ā—Ā—ā–ĺ—Ź–Ĺ–ł–ł –ī–ĺ 100 –ľ–Ķ—ā—Ä–ĺ–≤;
tame ‚ÄĒ –Ņ—Ä–ł—Ä—É—á–ł—ā—Ć –≤—Ā–Ķ—Ö –∑–≤–Ķ—Ä–Ķ–Ļ –≤ –ĺ–ļ—Ä—É–≥–Ķ, –ļ–ĺ—ā–ĺ—Ä—č—Ö –ľ–ĺ–∂–Ĺ–ĺ —Ā–ī–Ķ–Ľ–į—ā—Ć –ī–ĺ–ľ–į—ą–Ĺ–ł–ľ–ł –∂–ł–≤–ĺ—ā–Ĺ—č–ľ–ł, –Ĺ–į —Ä–į—Ā—Ā—ā–ĺ—Ź–Ĺ–ł–ł –ī–ĺ 100 –ľ–Ķ—ā—Ä–ĺ–≤;
save ‚ÄĒ —Ā–ĺ—Ö—Ä–į–Ĺ–ł—ā—Ć –ł–≥—Ä—É
removedrops ‚ÄĒ —É–Ī—Ä–į—ā—Ć –≤—Ā–Ķ –≤—č–Ņ–į–ī–į—é—Č–ł–Ķ –Ņ—Ä–Ķ–ī–ľ–Ķ—ā—č –≤ –ĺ–Ī–Ľ–į—Ā—ā–ł –Ĺ–į —Ä–į—Ā—Ā—ā–ĺ—Ź–Ĺ–ł–ł –ī–ĺ 100 –ľ–Ķ—ā—Ä–ĺ–≤;
location ‚ÄĒ —É—Ā—ā–į–Ĺ–ĺ–≤–ł—ā—Ć –ľ–Ķ—Ā—ā–ĺ –≤–į—ą–Ķ–≥–ĺ –≤–ĺ—Ā–ļ—Ä–Ķ—ą–Ķ–Ĺ–ł—Ź;
genloc ‚ÄĒ —Ā–≥–Ķ–Ĺ–Ķ—Ä–ł—Ä–ĺ–≤–į—ā—Ć –Ľ–ĺ–ļ–į—Ü–ł–ł –∑–į–Ĺ–ĺ–≤–ĺ;
wind [—É–≥–ĺ–Ľ] [–ł–Ĺ—ā–Ķ–Ĺ—Ā–ł–≤–Ĺ–ĺ—Ā—ā—Ć] ‚ÄĒ –∑–į–ī–į—ā—Ć –Ĺ–į–Ņ—Ä–į–≤–Ľ–Ķ–Ĺ–ł–Ķ –ł —Ā–ļ–ĺ—Ä–ĺ—Ā—ā—Ć –≤–Ķ—ā—Ä–į (0 ‚ÄĒ –Ī–Ķ–∑–≤–Ķ—ā—Ä–ł–Ķ, 0,1-0,3 ‚ÄĒ —Ā–Ľ–į–Ī—č–Ļ –≤–Ķ—ā–Ķ—Ä, 0,4-0,6 ‚ÄĒ —É–ľ–Ķ—Ä–Ķ–Ĺ–Ĺ—č–Ļ –≤–Ķ—ā–Ķ—Ä, 0,7-1 ‚ÄĒ —Ā–ł–Ľ—Ć–Ĺ—č–Ļ –≤–Ķ—ā–Ķ—Ä –ł —ą—ā–ĺ—Ä–ľ –≤ –ľ–ĺ—Ä–Ķ);
resetwind ‚ÄĒ –Ņ–Ķ—Ä–Ķ–∑–į–Ņ—É—Ā—ā–ł—ā—Ć –Ņ–į—Ä–į–ľ–Ķ—ā—Ä—č –≤–Ķ—ā—Ä–į;
skiptime [—Ā–Ķ–ļ—É–Ĺ–ī—č] ‚ÄĒ –Ņ—Ä–ĺ–ľ–ĺ—ā–į—ā—Ć –≤—Ä–Ķ–ľ—Ź –Ĺ–į —É–ļ–į–∑–į–Ĺ–Ĺ–ĺ–Ķ —á–ł—Ā–Ľ–ĺ —Ā–Ķ–ļ—É–Ĺ–ī;
tod [—á–ł—Ā–Ľ–ĺ] ‚ÄĒ —É—Ā—ā–į–Ĺ–ĺ–≤–ł—ā—Ć –≤—Ä–Ķ–ľ—Ź –ī–Ĺ—Ź: 0 –ł 1 ‚ÄĒ –Ņ–ĺ–Ľ–Ĺ–ĺ—á—Ć, 0.5 ‚ÄĒ –Ņ–ĺ–Ľ–ī–Ķ–Ĺ—Ć, -1 ‚ÄĒ –≤–Ķ—Ä–Ĺ—É—ā—Ć—Ā—Ź –ļ –∑–Ĺ–į—á–Ķ–Ĺ–ł—Ź–ľ –Ņ–ĺ —É–ľ–ĺ–Ľ—á–į–Ĺ–ł—é;
sleep ‚ÄĒ –Ņ—Ä–ĺ–ľ–ĺ—ā–į—ā—Ć –ĺ–ī–ł–Ĺ –ī–Ķ–Ĺ—Ć;
setkey [–ł–ľ—Ź] ‚ÄĒ —É—Ā—ā–į–Ĺ–ĺ–≤–ł—ā—Ć –Ĺ–ĺ–≤—č–Ļ –≥–Ľ–ĺ–Ī–į–Ľ—Ć–Ĺ—č–Ļ –ļ–Ľ—é—á;
resetkeys [–ł–ľ—Ź] ‚ÄĒ —Ā–Ī—Ä–ĺ—Ā–ł—ā—Ć —É–ļ–į–∑–į–Ĺ–Ĺ—č–Ļ –≥–Ľ–ĺ–Ī–į–Ľ—Ć–Ĺ—č–Ļ –ļ–Ľ—é—á;
listkeys ‚ÄĒ –Ņ–ĺ–ļ–į–∑–į—ā—Ć —Ā–Ņ–ł—Ā–ĺ–ļ –≥–Ľ–ĺ–Ī–į–Ľ—Ć–Ĺ—č–Ļ –ļ–Ľ—é—á–Ķ–Ļ;
dpsdebug ‚ÄĒ –≤–ļ–Ľ—é—á–ł—ā—Ć –ł–Ľ–ł –≤—č–ļ–Ľ—é—á–ł—ā—Ć –ĺ—ā–ĺ–Ī—Ä–į–∂–Ķ–Ĺ–ł–Ķ —É—Ä–ĺ–Ĺ–į –≤ —Ā–Ķ–ļ—É–Ĺ–ī—É.
env [–Ĺ–į–∑–≤–į–Ĺ–ł–Ķ] ‚ÄĒ —É—Ā—ā–į–Ĺ–ĺ–≤–ł—ā—Ć —Ā—Ä–Ķ–ī—É –ĺ—ā–Ľ–į–ī–ļ–ł;
reserenv ‚ÄĒ —Ā–Ī—Ä–ĺ—Ā–ł—ā—Ć —Ā—Ä–Ķ–ī—É –ĺ—ā–Ľ–į–ī–ļ–ł;
players [—á–ł—Ā–Ľ–ĺ] ‚ÄĒ —Ä–Ķ–≥—É–Ľ–ł—Ä–ĺ–≤–ļ–į —ą–ļ–į–Ľ—č —Ā–Ľ–ĺ–∂–Ĺ–ĺ—Ā—ā–ł. –ß—ā–ĺ–Ī—č —Ā–Ĺ–ł–∑–ł—ā—Ć –Ķ—Ď –ī–ĺ –ľ–ł–Ĺ–ł–ľ—É–ľ–į, –≤–≤–Ķ–ī–ł—ā–Ķ —á–ł—Ā–Ľ–ĺ 0. –ē—Ā–Ľ–ł –≤—č —Ö–ĺ—ā–ł—ā–Ķ –Ņ–ĺ–≤—č—Ā–ł—ā—Ć –Ķ—Ď, –≤–≤–ĺ–ī–ł—ā–Ķ —á–ł—Ā–Ľ–į —Ü–Ķ–Ľ—č–Ķ —á–ł—Ā–Ľ–į (1, 2, 3). –£—Ä–ĺ–≤–Ķ–Ĺ—Ć —Ā–Ľ–ĺ–∂–Ĺ–ĺ—Ā—ā–ł –≤–Ľ–ł—Ź–Ķ—ā –Ĺ–į —É—Ä–ĺ–Ĺ –ł –∑–ī–ĺ—Ä–ĺ–≤—Ć–Ķ –≤—Ā–Ķ—Ö —Ā—É—Č–Ķ—Ā—ā–≤ –≤ –ł–≥—Ä–Ķ.
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
