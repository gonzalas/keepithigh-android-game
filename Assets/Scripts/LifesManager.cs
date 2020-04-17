using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifesManager : MonoBehaviour
{
    private BallMovement ballMovement;
    public SpriteRenderer life3;
    public SpriteRenderer life2;

    void Start()
    {
        ballMovement = GameObject.Find("Ball").GetComponent<BallMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ballMovement.lifes == 2)
        {
            life3.gameObject.SetActive(false);
        }

        if (ballMovement.lifes == 1)
        {
            life2.gameObject.SetActive(false);
        }
    }
}
