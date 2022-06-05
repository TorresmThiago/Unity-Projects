using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //Not going to implement now, there are a few enemies I'd like to make first

    //But I had the idea on how to implement this on a large scale method

    //There will be a GameObject called WaveManager, and on this script there will
    //be a few variables (so far... Perhaps using a Object called Wave this can make more sense):
    //  Waves -> Public list that contains the enemies that will spawn
    //  SpawnNextWave -> Checks if all spawned enemies are dead so the next wave can be spawn
    //  SpawnRate -> Time between enemy spawn in the same wave

    //The position of the spawn points will depend on the number of enemies divided by the screen size
}
