using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Rigidbody platformRb;

    void Start()
    {
        platformRb = GetComponent<Rigidbody>();
        platformRb.transform.position = new Vector3(0, -2.1f, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float horizontalMove = Input.GetAxisRaw("Horizontal");

        transform.Translate(horizontalMove * speed * Time.deltaTime, 0, 0, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Rotate(0, 0, 45);
        }*/
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * forceRebound, ForceMode.Impulse);
        }
    }*/

    public void MovePlatform(int direction, int speedMove)
    {
        transform.Translate(direction * speedMove * Time.deltaTime, 0, 0, Space.World);
    }

}
