using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public GameObject traget;
    private NavMeshAgent ai;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        ai.SetDestination(traget.transform.position);
    }
}
