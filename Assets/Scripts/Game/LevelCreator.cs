using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    private Vector3[] possibleSpawnPoints;
    public GameObject[] hazards;
    public GameObject enemy;
    public float enemySpawnOffset = 1.0f;
    public int playerSpaceRadius;
    public Boundary boundary;
    public int dificulty;

    void ShuffleSpawnPositions()
    {
        for (int i = 0; i < possibleSpawnPoints.Length; i++)
        {
            Vector3 temp = possibleSpawnPoints[i];
            int randomIndex = Random.Range(i, possibleSpawnPoints.Length);
            possibleSpawnPoints[i] = possibleSpawnPoints[randomIndex];
            possibleSpawnPoints[randomIndex] = temp;
        }
    }
    void Start()
    {
        possibleSpawnPoints = new Vector3[]
        {
            new Vector3( boundary.xMax - enemySpawnOffset,0.0f, boundary.zMax - enemySpawnOffset),
            new Vector3( boundary.xMax - enemySpawnOffset,0.0f, boundary.zMin + enemySpawnOffset),
            new Vector3( boundary.xMin + enemySpawnOffset,0.0f, boundary.zMax - enemySpawnOffset),
            new Vector3( boundary.xMin + enemySpawnOffset,0.0f, boundary.zMin + enemySpawnOffset),
        };
        ShuffleSpawnPositions();
    }
    Vector3 createRandomSpawn()
    {
        int[] xCoordinates =
        {
            Random.Range(playerSpaceRadius,(int)(boundary.xMax)),
            Random.Range((int)(boundary.xMin),-playerSpaceRadius)
        };
        int[] zCoordinates =
        {
            Random.Range(playerSpaceRadius,(int)(boundary.zMax)),
            Random.Range((int)(boundary.zMin),-playerSpaceRadius)
        };
        Vector3 vector = new Vector3(xCoordinates[Random.Range(0, 2)], 0, zCoordinates[Random.Range(0, 2)]);
        return new Vector3(xCoordinates[Random.Range(0, 2)], 0, zCoordinates[Random.Range(0, 2)]);

    }
    void SpawnHazards(int level)
    {
        for (int i = 0; i < ((hazards.Length + level) % dificulty); i++)
        {
            GameObject hazard = hazards[Random.Range(0, hazards.Length)];

            Vector3 spawnPosition = createRandomSpawn();

            Quaternion spawnRotation = Random.rotation;
            Instantiate(hazard, spawnPosition, spawnRotation);

        }

    }
    void SpawnEnemyes(int level)
    {
        int numberOfEnemyes = (level + 1) % dificulty;
        int spawnPoints = (numberOfEnemyes / 4) + 1;
        for (int point = 0; point < numberOfEnemyes; point++)
        {
            Instantiate(enemy, possibleSpawnPoints[point % spawnPoints],Quaternion.identity);
        }

    }
    public void CreateLevel(int level)
    {
        SpawnHazards(level);
        SpawnEnemyes(level);
    }
}
