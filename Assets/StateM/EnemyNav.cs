using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public GameObject target;
    public GameObject patorl;
    private NavMeshAgent ai;
    private float distance;
    public Animator animator;
    public enum EnemyState { idle, walk, run, attack };
    public EnemyState state;
    Coroutine toPartol = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        state = EnemyState.idle;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Mathf.Abs(Vector3.Distance(target.transform.position, transform.position));
        switch (state)
        {
            case EnemyState.idle:
                ai.SetDestination(gameObject.transform.position);
                animator.SetTrigger("ideal");
                if(toPartol == null)
                {
                    toPartol = StartCoroutine(SwitchToPatrol());
                }
                break;
            case EnemyState.walk:
                float disToP = Mathf.Abs(Vector3.Distance(patorl.transform.position, transform.position));

                if (disToP > 2)
                {
                    animator.SetTrigger("walk");
                    ai.SetDestination(patorl.transform.position);
                }
                else
                {
                    animator.SetTrigger("ideal");
                }

                if (distance <= 15)
                {
                    state = EnemyState.run;
                }
                break;
            case EnemyState.run:

                animator.SetTrigger("run");
                ai.SetDestination(target.transform.position);
                if (distance <= 3)
                {
                    state = EnemyState.attack;
                }
                if (distance >= 15)
                {
                    state = EnemyState.walk;
                }
                break;
            case EnemyState.attack:
                animator.SetTrigger("attack");

                if (distance >= 3 && distance < 15)
                {
                    state = EnemyState.run;
                }
                if (distance >= 15)
                {
                    state = EnemyState.idle;
                }
                break;
        }

    }

    IEnumerator SwitchToPatrol()
    {
        yield return new WaitForSeconds(5);
        state = EnemyState.walk;
        toPartol = null;
    }


}
