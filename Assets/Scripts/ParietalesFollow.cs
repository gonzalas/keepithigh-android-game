using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParietalesFollow : MonoBehaviour
{
    public Transform character;

    void FixedUpdate()
    {
        transform.position = character.transform.position + new Vector3(0, 2f, 0);
    }
}
