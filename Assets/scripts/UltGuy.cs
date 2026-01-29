using EazyCamera.Legacy;
using UnityEngine;

public class UltGuy : MonoBehaviour
{
    public Animator animator;
    private UltStart ulttt;
    public GameObject beam;
    public GameObject player;
    public CamLock lockOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Awake()
    {
        ulttt = GameObject.Find("====Random====").GetComponent<UltStart>();
        lockOn = ulttt.GetComponentInChildren<CamLock>(true);

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(lockOn.target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 99 * Time.deltaTime);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("throw"))
        {
            transform.position = new Vector3(gameObject.transform.position.x, 6, gameObject.transform.position.z);
            ulttt.Act();
            Invoke("Beam",19);
            Invoke("End",25);
        }
    }
    void Beam()
    {
        Quaternion desiredRotation = Quaternion.LookRotation(lockOn.target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 99 * Time.deltaTime);
        beam.SetActive(true);
    }
    void End()
    {
        
       gameObject.SetActive(false);
    
    }
}
