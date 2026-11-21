# EXP_CIDADE

A small city sandbox built in Unity 6 (URP) to practice AI navigation and NPC behavior.

This is a learning project, not a finished game. I use it to test ideas and learn how things work. 🦊

## What I'm learning

- **Navigation:** baking a NavMesh with the AI Navigation package (`NavMeshSurface`), and controlling what is walkable with `NavMeshModifier`
- **NPC movement:** `NavMeshAgent` patrolling a list of waypoints
- **Obstacle sensing:** three `Raycast` sensors in front of the NPC that make it pick a new destination when it gets close to a wall
- **Timing:** a minimum time between destination changes, and waiting at each waypoint using coroutines
- **Animation:** a humanoid Mixamo character with an Animator Controller, switching between Idle and Walking through a `bool` parameter
- **Lighting:** experiments with baked lighting in a city scene

## Tech

- Unity 6 (Universal 3D / URP)
- C#
- AI Navigation package

## Running the project

1. Clone this repository.
2. Add the folder in Unity Hub (**Add → Add project from disk**).
3. Open it with the same Unity version (see `ProjectSettings/ProjectVersion.txt`).
4. Open `Assets/Scenes/SampleScene` and press **Play**.

## Credits

The city pack, the character and the animations are third-party assets and belong to their respective authors.

## Author

Made by **Yordy Fox** (aka [matheusrss](https://github.com/matheusrss)) while practicing game development.
