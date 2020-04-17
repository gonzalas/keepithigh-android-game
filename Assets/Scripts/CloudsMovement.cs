using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMovement : MonoBehaviour
{
    [SerializeField]
    float cloudSpeed = 1f;
    [SerializeField]
    private Rigidbody cloudRb;
    private float rightLimit = 12;

    // Start is called before the first frame update
    void Start()
    {
        cloudRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        cloudRb.transform.Translate(Vector3.right * cloudSpeed * Time.fixedDeltaTime);

        if (transform.position.x >= rightLimit)
        {
            Destroy(gameObject);
        }
    }


}
