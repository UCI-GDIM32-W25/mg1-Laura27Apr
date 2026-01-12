[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/MjLLqDcN)
# HW1
## Devlog
### 1 Preferred name & Pronouns
Laura Liu, she/her

### 2
For MG1, we initially broke down the game into three core components: Bunny, Plant, and UI. Then, we planned their respective attributions and actions. For example, the Player must have speed, seed count, and the ability to move after pressing WASD keys. The plant must appear when the space bar is pressed and coordinate with the UI to display the number of planted and remaining seeds.

In the code, the player corresponds to the bunny entity defined in the activity. To enable WASD movement control, I first implemented WASD movement within the Update() method using Input.GetAxis("Horizontal") and Input.GetAxis("Vertical").

While coding and adjusting the Player's Inspector later on, I discovered that the Plant doesn't exist as a separate component. Its planting status and quantity changes are managed within the Player. Then I created a SeedPrefab in Unity and dragged it into the PlayerScript. To create the "press space to plant" action, we needed to detect a space key press. Therefore, I made the PlantSeed( ) method call when Input.GetKeyDown(KeyCode.Space) was detected. While editing the PlantSeed() method, I realized that our break-down didn't mention the requirement that planting should only occur when there are still seeds remaining. I reflected that this might be considered "common sense," since it's obvious that planting isn't possible when there are no more seeds. However, this step is crucial. If such "common sense" isn't explicitly coded, the program won't automatically understand it. Therefore, I first wrote code to check _numSeedsLeft. Then, using Instantiate( _plantPrefab), I generated a plant GameObject at the player's current position, matching the breakdown's behavior design: "Hit space button -- plant appears." Within this method, I simultaneously update _numSeedsPlanted and _numSeedsLeft and call PlantCountUI.UpdateSeeds() to synchronize data changes with the UI.

The UI display component is managed exclusively by the PlantCountUI, aligning with the approach of treating "UI" as a separate module in the breakdown activity. The script references the TextMeshPro text component in the Canvas to display the number of planted and remaining seeds. Initially, I mistakenly referenced _plantedText and _remainingText in the Inspector as Text_SeedsPlanted and Text_SeedsRemaining, which are text objects containing static descriptive text, such as "Seeds planted:" instead of the dedicated numerical display components, Text_SeedsPlantedNum and Text_SeedsRemainingNum. This error caused numerical values to be written into the label text, resulting in chaotic UI display issues.

In the initial breakdown plan, we discussed using Debug.Log to display and inspect changes in seed quantities. However, during setup, the UI already displayed the remaining and planted seed counts in real time. Therefore, Debug.Log was not extensively used in the final version to output these values. Instead, we relied primarily on the UI to verify that the data was updating correctly. I only used Debug.Log during my early testing phase to confirm that the PlantSeed() method was successfully called. Once the functionality stabilized, I removed it.



## Open-Source Assets
If you added any other outside assets, list them here!
- [Sprout Lands sprite asset pack](https://cupnooble.itch.io/sprout-lands-asset-pack) - character and item sprites
