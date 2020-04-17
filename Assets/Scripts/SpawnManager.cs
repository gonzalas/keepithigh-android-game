using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> objects;
    private float spawnHigh = 25.0f;
    private float spawnLimits = 6.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateObjects", 0, 2);
    }

    void CreateObjects()
    {
        int index = Random.Range(0, objects.Count);
        Instantiate(objects[index], new Vector3(Random.Range(-spawnLimits, spawnLimits), spawnHigh, 1), objects[index].transform.rotation);
    }
}
