# TowerDefence
TowerDefence Game made by using Unity, c#

**Order of Sections:**<br />
Why Tower Defense Game? <br />
What did I gained through this game project?<br />
Further Plan with this Game Project?<br />
Game Component explanation<br />

------------------------------------------------------
**Why Tower Defense Game?**
------------------------------------------------------
While I was working on my first personal project(which is 2d horror platformer game), I felt that I was spending so much time on the conflict I faced during designing the 2d horror platformer game though I need to create some games to improve & prove my skills. Hence, I decided to proceed to next game project, and thought it will be good for me if I create a game that players can play multiple times with a single system, like league of legends, tetris, etc..
While considering what type of game to create, tower defense genre caught my eye.

------------------------------------------------------
**What did I gained through this game project?**
------------------------------------------------------
I learned how to design a game system and it's importance.
First, I created a simple tower that shots a bullet with basic damage every 1 second.
Then, when I tried to create a second tower, I realised that it is much better to set the basic tower as parent class and rest towers as child classes since most towers share the same components, except for some specific components.
Just like that, I've done the same work for the bullets since I needed to have several types of bullets. Most of them needed to have different shape, and some needed to stay even after hitting enemy. Also, some of them needed to create other gameObjects or effects. It sounded a bit different in the beginning, but they still were all bullets.

After having such game programming design, I was able to increase the work speed. Time required to create a new type of tower has been shortened! Also, I was able to find any errors occurred during programming much easily by doing so. It felt like programming is about how well I can organize the components of the game to make better game system architecture.

I was able to enjoy the whole process, and also, it was really meaningful to me since all these experiences and things I realized were impressive to me.

------------------------------------------------------
**Further Plan with this Game Project?**
------------------------------------------------------
I have will to proceed further with this game project in the future.
Since I got only one body, it's sad that I cannot work on this project right now, but designing this game was fun, and time that I spent considering 'how can I make a better game, with more fun?' was valuable.

If I work on it right away, I might will try to add more types of enemies. I have some more enemy designs that I could not add yet, such as hansel and gretel enemy. After finishing working on enemy types, I will need to work on level design, and at the same time I will work on the Entrance Scene since the section I created so far is only a single stage. There will be several stages, and each stages will contain number of waves that player needs to go through to beat the stage.

I will research other Tower Defense Games such as Balloon Tower Defense for formats and some ideas to add more details on the game. Those can be informatino about UI design, tower concepts, stage architecture, some systems, BMs, etc.


------------------------------------------------------
**Game Component explanation**
------------------------------------------------------
Format of Tower:
 - attackable range (circle area)
 - tower collider(does not rotate)
 - tower sprite(rotation traces detected enemy)
 - tower damage
 - Bullet GameObject
 - Attack Speed
 - detected enemy list, cur targetting list, etc.

Types of Towers:
1. normal Tower
2. double shot Tower
3. missile launcher Tower
4. RailGun Tower
5. Sniper Tower
6. Buff Tower
7. Water Tower
8. Electricity Tower
9. Ghost Detector

I created towers that might have points where players will feel fun.
for example, missile launcher tower attacks by missile, which creates explosion. All enemies in explosion area takes damage.
railgun tower shoots laser, which damages enemy in range every 0.5s.
sniper tower has long reloading time, but its damage value is much greater than any other towers.
Buff tower increases damages of ally towers in range.
Water Tower makes enemies in range wet, making them slow down by 10%~20%.
Electricity Tower can make enemy stop for a short period of time. Also, if near by enemies are wet, the electricity moves along the wet enemies, damaging and stopping all of them.
Ghost Detector Tower detects and shows ghost enemies in range to ally towers. All other towers cannot detect&give dmg to ghost enemy without this tower.

Format of Enemy:
 - movement Speed
 - Max HP & cur HP
 - Own Color, etc.
 - if special type, affecting range or Special GameObject
Types of Enemy:
1. normal enemy
2. rogue enemy
3. tank enemy
4. boss
5. healer enemy
6. jammer enemy
7. ghost enemy

boss enemy has massive amount of hp. However, it has slow speed so player can try for a long time to hunt it.
healer enemy heals all enemies in range every few seconds. player cannot get all enemies only with few numbers of missile launcer & railgun anymore!
jammer enemy creates jamming explosion when it dies. All ally towers in jamming explosion range cannot attack enemies for few seconds!
ghost enemy cannot be found nor damaged by ally towers unless player builds ghost detector tower.

-----------
