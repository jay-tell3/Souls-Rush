using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private int sound;
    public AudioClip Clip1;
    public AudioClip Clip2;
    public AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Ddestroy", 2);
        
        sound = Random.Range(1,3);

        if (sound == 1)
        {
            audioSource.clip = Clip1;
        }
        else
        {
            audioSource.clip = Clip2;
        }

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Ddestroy()
    {
        Destroy(gameObject);
    }
}
