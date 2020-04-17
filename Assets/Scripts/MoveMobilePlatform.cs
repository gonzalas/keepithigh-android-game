using UnityEngine;

public class MoveMobilePlatform : MonoBehaviour
{
    private PlatformMovement platformMovement;


    // Start is called before the first frame update
    void Start()
    {
        platformMovement = GetComponent<PlatformMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.position.x > Screen.width / 2)
            {
                platformMovement.MovePlatform(1, 15);
            }
            else if (touch.position.x < Screen.width / 2)
            {
                platformMovement.MovePlatform(-1, 15);
            }
            else
            {
                platformMovement.MovePlatform(0, 0);
            }
        }
    }
}
