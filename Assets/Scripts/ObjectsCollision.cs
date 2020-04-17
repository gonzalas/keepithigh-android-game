using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsCollision : MonoBehaviour
{
    private Rigidbody objectRb;
    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DropSpeed();
        objectRb.AddTorque(1, 1, 1);
    }

    void DropSpeed()
    {
        objectRb.drag = 10.0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Down"))
        {
            Destroy(gameObject);
        }
    }
}
