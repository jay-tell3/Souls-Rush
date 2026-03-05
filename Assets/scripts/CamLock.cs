using System;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class CamLock : MonoBehaviour
{
    public Transform target; // Assign the target GameObject in the Inspector
    public float smoothSpeed = 5f; // Adjust for smooth camera movement
    private bool isLockedOn = true;
    public GamerManger gamerManger;
    public Transform b1;
    public Transform b2;
    public Transform b3;

    public static bool camUsed = false;
   
    void Update()
    {
        /* Check if "T" is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            isLockedOn = !isLockedOn; // Toggle lock-on state
        } */
        if (GamerManger.BossDefeats == 0)
        {
            //target = GameObject.Find("target").transform;
            target = b1;
        }
        else if (GamerManger.BossDefeats == 1)
        {
            // target = GameObject.Find("targetB2").transform;
            target = b2;
        }
        else if (GamerManger.BossDefeats == 2)
        {
            //target = GameObject.Find("targetB3").transform;
            target = b3;
        }
        // If locked on, smoothly move and rotate the camera to face the target
        if (isLockedOn && target != null)
        {
            Debug.Log("fhhhhhhhhhhhh");
            camUsed = true;

              Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
        }
    }
}

