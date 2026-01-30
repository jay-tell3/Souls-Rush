using UnityEngine;

public class BobSword : MonoBehaviour
{
    private Vector3 lastPosition;
    public float currentSpeed;

    void Start()
    {
        // Initialize last position to the object's starting position
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the distance moved since the last frame
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        // Divide by the time elapsed between frames (Time.deltaTime) to get speed
        currentSpeed = distanceMoved / Time.deltaTime;

        // Update lastPosition for the next frame's calculation
        lastPosition = transform.position;

        // You can log the speed
        if(currentSpeed > 50)
        {
 Debug.Log("Speed: " + currentSpeed);
        }
       
    }
}
