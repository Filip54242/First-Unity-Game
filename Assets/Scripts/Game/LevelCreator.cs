using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject[] hazards;
    public GameObject enemy;
    public int playerSpaceRadius;
    public Boundary boundary;
    public int dificulty;
    // Start is called before the first frame update
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
        Vector3 vector=new Vector3(xCoordinates[Random.Range(0, 2)], 0, zCoordinates[Random.Range(0, 2)]);
        Debug.Log(vector.ToString());
        return new Vector3(xCoordinates[Random.Range(0, 2)], 0, zCoordinates[Random.Range(0, 2)]);

    }
    public void CreateLevel(int level)
    {
        for (int i = 0; i < ((hazards.Length + level) % dificulty); i++)
        {
            GameObject hazard = hazards[Random.Range(0, hazards.Length)];

            Vector3 spawnPosition = createRandomSpawn();

            Quaternion spawnRotation = Random.rotation;
            Instantiate(hazard, spawnPosition, spawnRotation);

        }

    }
}
