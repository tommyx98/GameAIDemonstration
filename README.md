# Game AI Project README

## Overview

This project demonstrates various forms of game AI through the development of a game using Unity and C#. The primary objective is to showcase different AI behaviors rather than focusing on the overall gameplay experience. The project includes features such as A* pathfinding, steering behaviors, and finite state machines.

## Features

### Implemented AI Techniques
1. **A\* Pathfinding**: Utilized in the main scene for navigating through a maze.
2. **Steering Behaviors**:
    - Flocking
    - Separation
    - Cohesion
    - Alignment
    - Obstacle Avoidance
    - Leader Following
    - Arrival
    - Wander
    - Pathfollowing
    - Seek
    - Pursuit
    - Flee
3. **Finite State Machines**: Used in various levels to control behavior states.

### Detailed Description of Levels and AI

#### Main Scene (A* Pathfinding)
- The player navigates through a maze using A* pathfinding. Pressing corresponding numbers will reveal the fastest path to the exit.

#### Level 1 (Steering Behaviors)
- Demonstrates flocking behavior with ships moving together, showing alignment, cohesion, separation, and obstacle avoidance.

#### Level 2 (Interactive AI with Finite State Machine)
- The player controls a yellow arrow to catch green arrows while avoiding a missile. The green arrows flee when approached by the player.

#### Level 3 (Pathfollowing and Seek)
- The player creates new paths by dragging points, and an agent follows these paths using seek behavior.

#### Level 4 (Leader Following)
- Agents follow a randomly chosen leader. The player can make agents scatter or follow the leader by pressing buttons.



