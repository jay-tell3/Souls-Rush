using UnityEngine;

public class Ultcam : MonoBehaviour
{
    public Animator animator;
    bool bruh = true;
    public GameObject charge;
    public GameObject beam;
    public GameObject cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Charge",4);
        Invoke("Throw", 14);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void Charge()
    {
        charge.SetActive(true);
    }
    void Throw()
    {
        animator.SetTrigger("throw");
        charge.SetActive(false);
        beam.SetActive(true);
        Invoke("Cam",3);
    }
    void Cam()
    {
        cam.SetActive(true);
    }
}
