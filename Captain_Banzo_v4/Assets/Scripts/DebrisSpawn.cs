using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawn : MonoBehaviour
{
    public GameObject debrisPrefab; //Prefab of the debris object to spawn
    public Vector3 spawnArea = new Vector3(500,500,500); // Play area/Spawn area
    public int maxDebrisCount = 10; //Max number of debris to spawn in-game
    public float minSpawnDistance = 5f; // Minimum distance between spawned debris
    private List<GameObject> debrisList = new List<GameObject>(); // Counter to track the amount of debris
    // Start is called before the first frame update
    void Start()
    {
        for (int d = 0; d < maxDebrisCount; d++) // Spawns all debris at the same time
        {
            SpawnDebris(); //Spawns all debris on game start
        }
    }

    void SpawnDebris() // Method that spawns debris in any available postion
    {
        Vector3 spawnPosition;
        int attempts = 0; //Counter to limit the number of postion attempts
        bool validPosition = false; //indicator for when position is found

        do
        {
            spawnPosition = new Vector3 // Generate random postion within spawn area
            (
                // X,Y,Z coords within half the spawn area's width,height and depth respectively
                Random.Range(-spawnArea.x / 2, spawnArea.x /2),
                Random.Range(-spawnArea.y / 2, spawnArea.y /2),
                Random.Range(-spawnArea.z / 2, spawnArea.z /2)
            );

            // Check if position is clear of other objects
            validPosition = true; // assume the postion is valid

            for (int d = 0; d < debrisList.Count; d++)
            {
                // Measure distance between new spawn and existing spawn position
                if (Vector3.Distance(spawnPosition, debrisList[d].transform.position) < minSpawnDistance)
                {
                    // Adds debris to be removed
                    validPosition = false; 
                    break;
                }
            }

            attempts++; // Increments attempts counter
        }

        while
         (!validPosition && attempts < 10); // Stops infinite loop

         if (validPosition)
         {
            GameObject newDebris = Instantiate(debrisPrefab, spawnPosition, Quaternion.identity); //Instantiate the debris prefab with default rotation at the position
            debrisList.Add(newDebris); // Adds new debris to the the debris lsit
         }
    }

    // Update is called once per frame
    void Update()
    {
     // Loops through debris list to remove null references
     for (int d = debrisList.Count - 1; d >= 0; d--) //
     {
        if (debrisList[d] == null) // Check if debris is destroyed or out of bounds
        {
            debrisList.RemoveAt(d); // remove the anomoly from the list
        }
     }   
    }
}


// References
//Create with Code--
//Challenge 4 & 5