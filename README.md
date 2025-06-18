# How to Run the Project

## Prerequisites:
- Unity Editor **version 2021.3 LTS** or later (recommended)
- If building for iOS:
  - A Mac with **Xcode installed**
  - Apple Developer Account (to sign and deploy .ipa files)
  - Unity iOS Build Support module installed

## Run in Editor:
1. Open the project folder in Unity.
2. Go to `Scenes` folder and open `Menu.unity`.
3. Click **Play** in the Unity Editor.
4. Use your mouse to simulate touch interactions.

---
# Design Choices

## Song Management
- Songs are stored as `SongData` ScriptableObjects inside the `Resources/Songs` folder.
- Song selection UI dynamically loads all songs at runtime and generates buttons.

## Tile System
- Tiles are spawned at a fixed interval based on song BPM.
- Each tile is a prefab with `TileAction` script that handles tap detection and scoring.

## Scoring
- Tapping tiles near the `ScoreLine` grants a score (Perfect, Great, Cool, Miss).
- If a tile reaches the end without being tapped, the game ends.

## Cross-Platform Input
- Supports both mouse click and mobile touch input using `Input.GetMouseButtonDown()` and `Input.touchCount`.
- Game is designed to work on mobile (iOS) and desktop platforms.

---

## Notes
- This project was developed and tested primarily in Unity Editor using simulated mouse input.
- Actual gameplay performance and touch response should be verified on a real iOS device.
