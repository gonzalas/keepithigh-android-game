using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCloud : MonoBehaviour
{
    public List<GameObject> clouds;
    private float leftLimit = -12;


    void Start()
    {
        InvokeRepeating("CreatingCloud", 0, 17);
    }

    void CreatingCloud()
    {
        float highCloud = Random.Range(4, 15);
        int index = Random.Range(0, clouds.Count);
        Instantiate(clouds[index], new Vector3(leftLimit, highCloud, 2), clouds[index].transform.rotation);
    }

}
