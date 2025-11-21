using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class CameraLockOn : MonoBehaviour
{
    public Transform target; // Assign the target GameObject in the Inspector
    public float smoothSpeed = 5f; // Adjust for smooth camera movement
    private bool isLockedOn = true;
    public GamerManger gamerManger;
    void Update()
    {
        /* Check if "T" is pressed
        if (Input.GetKeyDown(KeyCode.T))
        {
            isLockedOn = !isLockedOn; // Toggle lock-on state
        } */
        if (gamerManger.BossDefeats == 0)
        {
          //  target = GameObject.Find("target").transform;
        }
        else
        {
            target = GameObject.Find("targetB2").transform;
        }
        // If locked on, smoothly move and rotate the camera to face the target
        if (isLockedOn && target != null)
        {
            
  

              Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed * Time.deltaTime);
        }
    }
}

