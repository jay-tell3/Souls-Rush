using EazyCamera.Legacy;
using UnityEngine;

public class UltGuy : MonoBehaviour
{
    public Animator animator;
    private UltStart ulttt;
    public GameObject beam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Start()
    {
        ulttt = GameObject.Find("====Random====").GetComponent<UltStart>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("throw"))
        {
           
            ulttt.Act();
            Invoke("Beam",19);
        }
    }
    void Beam()
    {
        beam.SetActive(true);
    }
}
