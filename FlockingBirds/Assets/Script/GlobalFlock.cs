using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour
{
    public GameObject birdPrefab;
    public static int airSize = 100;
    static int numBirds = 700;
    public static GameObject[] birds = new GameObject[numBirds];
    public static Vector3 goalPos = new Vector3(0, 0, 0);
    GameObject player;
    Vector3 playerPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerPos = player.transform.position;
        goalPos = new Vector3(Random.Range(playerPos.x - airSize, playerPos.x + airSize),
                              Random.Range(playerPos.y + 10f, playerPos.y + airSize), 
                              Random.Range(playerPos.z + 10f, playerPos.z + airSize));
        for(int i = 0; i < numBirds; i++)
        {
            Vector3 pos = new Vector3(Random.Range(playerPos.x - airSize, playerPos.x + airSize),
                              Random.Range(playerPos.y + 10f, playerPos.y + airSize),
                              Random.Range(playerPos.z + 10f, playerPos.z + airSize));
            birds[i] = (GameObject)Instantiate(birdPrefab, pos, Quaternion.LookRotation(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f))));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 1)
        {
            goalPos = new Vector3(Random.Range(playerPos.x - airSize, playerPos.x + airSize),
                                Random.Range(playerPos.y + 10f, playerPos.y + airSize),
                                Random.Range(playerPos.z + 10f, playerPos.z + airSize));
        }
    }
}
