# Game Design Document for Zombie Survival RPG

## Table of Contents

1. [Overview](https://www.notion.so/Zombie-Game-f0423f198d2441778492aaab1a160fdf?pvs=21)
2. [Gameplay Mechanics](https://www.notion.so/Zombie-Game-f0423f198d2441778492aaab1a160fdf?pvs=21)
3. [World Design](https://www.notion.so/Zombie-Game-f0423f198d2441778492aaab1a160fdf?pvs=21)
4. [Assets](https://www.notion.so/Zombie-Game-f0423f198d2441778492aaab1a160fdf?pvs=21)
5. [Prefabs and Reusable Designs](https://www.notion.so/Zombie-Game-f0423f198d2441778492aaab1a160fdf?pvs=21)
6. [Components](https://www.notion.so/Zombie-Game-f0423f198d2441778492aaab1a160fdf?pvs=21)
7. [Task Management](https://www.notion.so/Zombie-Game-f0423f198d2441778492aaab1a160fdf?pvs=21)
8. [Timeline](https://www.notion.so/Zombie-Game-f0423f198d2441778492aaab1a160fdf?pvs=21)

## 1. Overview <a name="overview"></a>

- Game Concept: A brief summary of the game.
- Target Audience: Define the target demographic.
- Platform: Specify the platforms (PC, mobile, etc.)
- Art Style: Pixel Art

## 2. Gameplay Mechanics <a name="gameplay-mechanics"></a>

### Day and Night Cycle

- Objective: Create a dynamic day and night cycle in the game world.
- Implementation Steps:
    1. Create a time system that tracks the in-game time.
    2. Implement changes in lighting and ambient effects based on the time of day.
    3. Adjust NPC behaviors, such as sleep patterns and availability, according to the time of day.
    4. Integrate gameplay mechanics that are affected by the day and night cycle, such as zombie behavior and visibility.

### Seasons

- Objective: Implement seasonal changes in the game world, including visual effects and gameplay variations.
- Implementation Steps:
    1. Develop a system that tracks the current season in the game.
    2. Modify environmental elements, such as foliage and weather patterns, to reflect the current season.
    3. Introduce gameplay mechanics influenced by the seasons, such as changes in resource availability and enemy behavior.

### Zombie Types

1. Faster moving ones that run - **Sprinters**
    - Objective: Create zombies that are freshly turned and exhibit fast movement.
    - Implementation Steps:
        1. Design unique sprinter zombie models and animations.
        2. Adjust movement speed and attack patterns to reflect their agility.
        3. Determine the appropriate balance between their strength and vulnerability.
2. Smarter ones - **Savvy Zombies**
    - Objective: Introduce zombies that can open unlocked car and house doors and carry items.
    - Implementation Steps:
        1. Implement AI behavior for savvy zombies to detect and interact with doors.
        2. Develop the ability for zombies to carry items that increase their attack damage.
        3. Determine the chance of encountering savvy zombies based on the game's difficulty.
3. Jumpers - **Leap Zombies**
    - Objective: Create zombies that can jump up buildings and across streets.
    - Implementation Steps:
        1. Define the jump mechanics for leap zombies, including distance and height.
        2. Design unique animations for their jumping movements.
        3. Determine the spawning locations and frequency of leap zombies in the game world.

### Melee Weapons

- Objective: Provide a variety of melee weapons for player use.
- Implementation Steps:
    1. Design and model different melee weapons, such as a bat, lead pipe, and crowbar.
    2. Implement weapon handling and attack animations for each melee weapon.
    3. Determine the damage and durability values for each weapon.
    4. Develop functionality for using the crowbar as a tool to pry open car doors, containers, and house doors.

### Guns

- Objective: Include multiple types of guns in the game.
- Implementation Steps:
    1. Design and model various guns, such as a handgun, shotgun, rifle, sniper rifle, rocket launcher, and grenade launcher.
    2. Implement shooting mechanics and animations for each gun.
    3. Define different damage values, range, and accuracy for each gun.
    4. Introduce ammunition management for guns.

### Food and Craftable Items

- Objective: Provide a wide range of food items and craftable objects in the game.
- Implementation Steps:
    1. Design and model different types of food items, including canned food, fruits, and vegetables.
    2. Develop a crafting system that allows players to create furniture, cars, clothing, weapons, armor, and other useful items.
    3. Determine the recipes and required resources for crafting each item.
    4. Implement functionality for cooking and preparing food.

### Electricity and Water Systems

- Objective: Simulate electricity and water systems in the game world.
- Implementation Steps:
    1. Create a power grid system with power lines, substations, and power stations.
    2. Develop functionality to provide electricity to homes, street lights, and other structures.
    3. Implement a plumbing system that simulates water distribution and cutoffs.
    4. Introduce mechanics that make survival more challenging when water supply is randomly cut off.

### Diverse Locations and Structures

- Objective: Design and create various locations and structures for players to explore.
- Implementation Steps:
    1. Develop tall buildings, mansions, skyscrapers, apartment buildings, trailers, work sites, research labs, factories, suburban homes, basements, bunkers, military bases, malls, grocery stores, sporting goods stores, gas stations, banks, and other unique locations.
    2. Populate each location with appropriate props, furniture, and interactive elements.
    3. Ensure that each location offers distinct gameplay opportunities and challenges.

### Player Skills and Abilities

- Objective: Implement a skill system that allows players to train and unlock new abilities.
- Implementation Steps:
    1. Design a skill tree with various skill branches and abilities.
    2. Define the requirements for unlocking each skill.
    3. Develop gameplay mechanics associated with each skill, such as improved combat techniques, crafting efficiency, or survival instincts.
    4. Implement a progression system that allows players to earn experience points and allocate them to unlock skills.
- Core Loop: Describe the main gameplay loop (e.g., explore, loot, survive).
- Player Actions: List actions like move, shoot, interact, etc.
- Game Systems: Detailed breakdown of each game system.
    - Hunger System
        - Objective: Simulate hunger mechanics for the player character.
        - GameObject List: Player character
        - Script List: HungerSystem.cs
        - Assets Required: None
        - Implementation Steps:
            1. Attach HungerSystem.cs script to the player character.
            2. Implement logic to decrease hunger over time.
            3. Handle player character's behavior when hunger reaches critical levels.
        - Dependencies: None
        - Testing: Test hunger system functionality in different scenarios.
    - Weather System
        - Objective: Simulate weather mechanics in the game world.
        - GameObject List: None
        - Script List: WeatherSystem.cs
        - Assets Required: None
        - Implementation Steps:
            1. Attach WeatherSystem.cs script to the game world.
            2. Implement logic to change weather conditions dynamically.
            3. Update gameplay elements based on weather conditions.
        - Dependencies: None
        - Testing: Test weather system functionality across different weather states.
    - Combat System
        - Objective: Implement combat mechanics for player interaction with enemies.
        - GameObject List: Player character, enemies
        - Script List: CombatSystem.cs, EnemyAI.cs
        - Assets Required: None
        - Implementation Steps:
            1. Attach CombatSystem.cs script to the player character.
            2. Implement logic for attacking and defending.
            3. Attach EnemyAI.cs script to enemy characters.
            4. Implement enemy AI behavior during combat.
        - Dependencies: None
        - Testing: Test combat system by engaging in battles with enemies.
    - Inventory System
        - Objective: Manage player's inventory and item interactions.
        - GameObject List: Player character, items
        - Script List: InventoryManager.cs
        - Assets Required: Item Icons
        - Implementation Steps:
            1. Attach InventoryManager.cs script to the player character.
            2. Implement logic for adding, removing, and using items.
            3. Display inventory UI with item icons.
        - Dependencies: Item Icons
        - Testing: Test inventory system by adding, removing, and using items.
    - Quest System
        - Objective: Implement quest mechanics for player progression.
        - GameObject List: Player character, NPCs
        - Script List: QuestSystem.cs, NPCInteraction.cs
        - Assets Required: None
        - Implementation Steps:
            1. Attach QuestSystem.cs script to the player character.
            2. Implement logic for accepting, completing, and tracking quests.
            3. Attach NPCInteraction.cs script to NPCs.
            4. Implement NPC interactions related to quests.
        - Dependencies: None
        - Testing: Test quest system by accepting, completing, and tracking quests.
    - NPC Interactions
        - Objective: Implement interactions between the player character and NPCs.
        - GameObject List: Player character, NPCs
        - Script List: NPCInteraction.cs
        - Assets Required: None
        - Implementation Steps:
            1. Attach NPCInteraction.cs script to NPCs.
            2. Implement dialogue options and behaviors for NPCs.
            3. Handle player character's responses and consequences.
        - Dependencies: None
        - Testing: Test NPC interactions with different dialogue options.

### NPC Personalities and Traits

- Objective: Create NPCs with goals, personalities, backgrounds, and traits.
- Implementation Steps:
    1. Design a system for generating NPCs with unique traits, such as strengths, weaknesses, and behavioral patterns.
    2. Develop dialogue and interaction options that allow players to learn about NPCs' goals and pasts.
    3. Implement AI routines that govern NPC behavior based on their personalities and traits.
    
    Can you flesh out the whole document and reprint it and add the Unity depth like we did earlier?
    

## 3. World Design <a name="world-design"></a>

- Map Layout: Overview of the game world.
- Zones: Different areas in the game (e.g., city, forest, etc.)
- Points of Interest: Locations like shops, safe houses, etc.

## 4. Assets <a name="assets"></a>

- GameObject List: Detailed list of all GameObjects.
    - Characters: Player, NPCs, Zombies
    - Items: Weapons, Food, Tools
    - Environment: Trees, Buildings, etc.
- Script List: All scripts and their functionalities.
    - PlayerController.cs
    - InventoryManager.cs
    - CombatSystem.cs
    - HungerSystem.cs
    - WeatherSystem.cs
    - QuestSystem.cs
    - EnemyAI.cs
    - NPCInteraction.cs
- Art Assets: All 2D/3D art assets.
    - Character Sprites
    - Item Icons
    - Environment Tiles
- Sound Assets: All SFX and songs.
    - Gunshots
    - Zombie Groans
    - Background Music
- Animation Assets: All animations.
    - Player Walk Cycle
    - Zombie Attack Animation

## 5. Prefabs and Reusable Designs <a name="prefabs-and-reusable-designs"></a>

- Prefab List: All prefabs and their components.
    - Zombie Prefab
    - Weapon Prefab
- Reusable Scripts: Scripts that can be used in multiple places.
    - HealthSystem.cs
    - DamageSystem.cs

## 6. Components <a name="components"></a>

For each system, create a separate section detailing:

- Objective
- GameObject List
- Script List
- Assets Required
- Implementation Steps
- Dependencies
- Testing

## 7. Task Management <a name="task-management"></a>

- To-Do List: Tasks that need to be completed.
- Bug Tracking: List of known bugs and steps to reproduce.

## 8. Timeline <a name="timeline"></a>

- Milestones: Important dates and deliverables.

## 9. Monetization <a name="monetization"></a>

- Revenue Models: Describe the ways the game will generate revenue (e.g., ads, in-app purchases).
- Pricing Strategy: Specify the pricing model (free-to-play, premium, etc.).

## 10. Marketing and Promotion <a name="marketing-and-promotion"></a>

- Target Marketing: Define the strategies to reach the target audience.
- Promotional Activities: Outline the planned marketing and promotional activities.

The <a name="marketing-and-promotion"></a> part in each section's title is an HTML anchor tag. It is used to create a hyperlink within the document. The "a" tag with the "name" attribute serves as the target location for the hyperlink. In this case, it is used to create a clickable table of contents that allows users to navigate directly to a specific section by clicking on its title.

## 11. External Resources <a name="external-resources"></a>

- [GitHub](https://github.com/Herpsta/Zombie-Survival-RPG): Check out the game's GitHub repository for the latest updates and source code.

## 12. Credits <a name="credits"></a>

- Creator: Joshua Lister
- Game Design: Joshua Lister
- Artwork: Joshua Lister
- Sound Design: Joshua Lister
- Programming: Joshua Lister

Technical Implementation:

### **Day and Night Cycle**

- **Objective**: Create a dynamic day and night cycle in the game world.
- **Unity Steps**:
    1. Create an empty GameObject and name it **`TimeManager`**.
    2. Attach a script called **`TimeManager.cs`** to handle the day-night cycle.
    3. Use Unity's **`Light`** component to simulate the sun and adjust its intensity and color based on the time of day.
    4. Update NPC and enemy behaviors based on the time, possibly using Unity's **`Animator`** for sleep/wake cycles.

### **Seasons**

- **Objective**: Implement seasonal changes in the game world.
- **Unity Steps**:
    1. Create an empty GameObject and name it **`SeasonManager`**.
    2. Attach a script called **`SeasonManager.cs`** to handle seasonal changes.
    3. Use Unity's **`ParticleSystem`** for seasonal effects like falling leaves or snow.
    4. Update resource availability and enemy behaviors based on the current season.

### **Zombie Types**

### Sprinters

- **Objective**: Create fast-moving zombies.
- **Unity Steps**:
    1. Create a new prefab for the sprinter zombie.
    2. Attach a script called **`SprinterZombieAI.cs`** to handle its unique behaviors.
    3. Use Unity's **`Animator`** to manage different animations for sprinting, attacking, etc.

### Savvy Zombies

- **Objective**: Create smarter zombies.
- **Unity Steps**:
    1. Create a new prefab for the savvy zombie.
    2. Attach a script called **`SavvyZombieAI.cs`** to handle interactions like opening doors.
    3. Use Unity's **`Rigidbody`** and **`Collider`** components to allow these zombies to carry items.

### Leap Zombies

- **Objective**: Create jumping zombies.
- **Unity Steps**:
    1. Create a new prefab for the leap zombie.
    2. Attach a script called **`LeapZombieAI.cs`** to handle the jumping mechanics.
    3. Use Unity's **`Rigidbody.AddForce()`** method to implement the jumping behavior.

### **Melee Weapons**

- **Objective**: Provide a variety of melee weapons.
- **Unity Steps**:
    1. Create prefabs for each type of melee weapon.
    2. Attach a script called **`MeleeWeapon.cs`** to handle weapon behaviors.
    3. Use Unity's **`Collider`** and **`Rigidbody`** components for hit detection and physics.

### **Guns**

- **Objective**: Include multiple types of guns.
- **Unity Steps**:
    1. Create prefabs for each type of gun.
    2. Attach a script called **`Gun.cs`** to handle shooting mechanics.
    3. Use Unity's **`Raycasting`** for bullet trajectory and hit detection.

### **Food and Craftable Items**

- **Objective**: Provide a range of food and craftable items.
- **Unity Steps**:
    1. Create prefabs for each type of food and craftable item.
    2. Attach a script called **`CraftingSystem.cs`** to handle crafting mechanics.
    3. Use Unity's UI system to create crafting menus and interfaces.

### **Electricity and Water Systems**

- **Objective**: Simulate electricity and water systems.
- **Unity Steps**:
    1. Create GameObjects to represent power lines, substations, etc.
    2. Attach a script called **`UtilitySystem.cs`** to manage these systems.
    3. Use Unity's **`ParticleSystem`** to simulate water flow and electrical sparks.

### **Diverse Locations and Structures**

- **Objective**: Create various locations for exploration.
- **Unity Steps**:
    1. Use Unity's **`Terrain`** and **`Tilemap`** systems to design diverse locations.
    2. Attach scripts like **`LocationManager.cs`** to handle location-specific logic.
    3. Use Unity's **`NavMesh`** system for NPC and enemy pathfinding within these locations.

### **Player Skills and Abilities**

- **Objective**: Implement a skill system.
- **Unity Steps**:
    1. Create a UI panel for the skill tree using Unity's UI system.
    2. Attach a script called **`SkillSystem.cs`** to manage skill points and unlocks.
    3. Use Unity's **`Animator`** to handle any new animations that come with skill unlocks.

### **NPC Personalities and Traits**

- **Objective**: Create NPCs with unique traits.
- **Unity Steps**:
    1. Attach a script called **`NPCPersonality.cs`** to each NPC GameObject.
    2. Use Unity's **`DialogueSystem`** (if you have one) to incorporate personality traits into dialogues.
    3. Use Unity's **`Animator`** and **`NavMeshAgent`** to reflect NPC personalities in their movements and actions.
    
    ### **Horde Behavior Among Zombies**
    
    ### Objective
    
    Implement a system where zombies can form hordes and move as a group.
    
    ### Unity Steps
    
    1. **Create Horde Manager**
        - Create an empty GameObject in the scene and name it **`HordeManager`**.
        - Attach a new script called **`HordeManager.cs`**.
    2. **Zombie Grouping**
        - In **`HordeManager.cs`**, create a list to hold zombies that are part of a horde.
        - Use Unity's **`NavMeshAgent`** to control individual zombie movements.
    3. **Horde Formation Logic**
        - Implement logic to check if zombies are close enough to form a horde.
        - Use **`Vector3.Distance`** to measure the distance between zombies.
    4. **Horde Movement**
        - Implement logic to move the horde towards a target or waypoint.
        - Use **`NavMeshAgent.SetDestination`** to set the movement target for each zombie in the horde.
    5. **Horde Disband Logic**
        - Implement conditions under which a horde should disband, such as reaching a destination or upon certain player actions.
    
    ---
    
    ### **Zombies Attracted to Sight and Sound**
    
    ### Objective
    
    Zombies are attracted to visual and auditory stimuli.
    
    ### Unity Steps
    
    1. **Update Zombie AI**
        - Open the existing **`ZombieAI.cs`** script.
        - Add variables to hold sight and sound detection ranges.
    2. **Line-of-Sight Detection**
        - Use Unity's **`Physics.Raycast`** for line-of-sight detection.
        - Implement logic to move the zombie towards the player if they are in sight.
    3. **Sound Detection**
        - Create a **`SphereCollider`** around the zombie to act as an "audio detection radius."
        - Use Unity's **`OnTriggerEnter`** and **`OnTriggerExit`** to detect when sound sources enter or leave this radius.
    
    ---
    
    ### **Zombies Attracted to Various Sounds**
    
    ### Objective
    
    Zombies are attracted to the sounds of animals, NPCs, other zombies, and the player.
    
    ### Unity Steps
    
    1. **Create Audio Sources**
        - Create different **`AudioSource`** components for animals, NPCs, other zombies, and the player.
    2. **Update Zombie AI**
        - Modify **`ZombieAI.cs`** to include reactions to different types of sounds.
        - Use tags or layers to differentiate between sound sources.
    3. **Sound Range**
        - Use Unity's **`AudioSource`** component to set the range of each sound.
        - Use **`AudioListener`** to detect if the sound is within range of a zombie.
    
    ---
    
    ### **Driveable Vehicles**
    
    ### Objective
    
    Implement a variety of driveable vehicles in the game.
    
    ### Unity Steps
    
    1. **Vehicle Prefabs**
        - Create prefabs for each type of vehicle like cars, trucks, and motorcycles.
        - Attach colliders and **`Rigidbody`** components for physics interactions.
    2. **Vehicle Controller Script**
        - Create a new script called **`VehicleController.cs`**.
        - Implement vehicle physics, including acceleration, turning, and braking.
    3. **Wheel Physics**
        - Use Unity's **`WheelCollider`** for realistic wheel physics.
        - Implement suspension and friction settings.
    4. **Vehicle UI**
        - Create a UI panel to display vehicle controls and status.
        - Use Unity's UI Text and Image components to display speed, fuel, etc.
    5. **Entering/Exiting Vehicles**
        - Implement logic for the player to enter and exit vehicles.
        - Use Unity's **`OnTriggerEnter`** to detect when the player is near a vehicle.
