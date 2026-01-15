using UnityEngine;

public class PlayState : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.Rotate(0, 100 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.Rotate(0, -100 * Time.deltaTime, 0);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -2 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * -2 * Time.deltaTime);
        }
    }
}
