using UnityEngine;

public class Boss3 : MonoBehaviour
{
    private bool tp =true;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (tp)
        {
            tp = false;
            Invoke("Tp", 0.5f);
        }

    }

    void Tp()
    {
        
        transform.position = new Vector3(Random.Range(-10, 11), -0.8177662f, Random.Range(-10, 11));
        Vector3 direction = target.position - transform.position;

        // Zero out the Y component to constrain rotation to the Y-axis
        direction.y = 0;

        // Check if the direction is valid (non-zero)
        if (direction != Vector3.zero)
        {
            //  Apply LookRotation constrained to the Y-axis
            transform.rotation = Quaternion.LookRotation(direction);
        }
        tp = true;
    }
}
