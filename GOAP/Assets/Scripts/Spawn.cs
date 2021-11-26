using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject patientPrefab;
    public int numIntialPatients = 5;
    public int minDurationSpawn = 1;
    public int maxDurationSpawn = 10;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numIntialPatients; i++)
        {
            Vector3 location = new Vector3();
            location.x = this.transform.position.x + Random.Range(-10, 10);
            location.z = this.transform.position.z + Random.Range(-10, 10);
            location.y = 1.55f;
            Instantiate(patientPrefab, location, Quaternion.identity);
        }
        Invoke("SpawnPatient", 1);
    }

 
    void SpawnPatient()
    {
        Vector3 location = new Vector3();
        location.x = this.transform.position.x + Random.Range(-10, 10);
        location.z = this.transform.position.z + Random.Range(-10, 10);
        location.y = 1.55f;
        Instantiate(patientPrefab, location, Quaternion.identity);
        Invoke("SpawnPatient", Random.Range(minDurationSpawn, maxDurationSpawn));
    }
}
