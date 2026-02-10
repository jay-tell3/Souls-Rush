using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioManger : MonoBehaviour
{

    private static AudioManger instance;

    public static AudioManger Instance { get { return instance; } }

    public AudioMixer masterMixer;

    public Slider musicSlider, masterSlider;
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        masterMixer.SetFloat("MasterVol", PreferencesManager.GetMasterVolume());
        masterMixer.SetFloat("MusicVol", PreferencesManager.GetMusicVolume());

        if (masterSlider != null)
            PreferencesManager.GetMasterVolume();
        if(musicSlider != null)
            PreferencesManager.GetMusicVolume();
    }

    public void ChangeSoundVolume(float soundLevel)
    {
        masterMixer.SetFloat("MasterVol", soundLevel);
        PreferencesManager.SetMasterVolume(soundLevel);
    }

    public void ChangemusicVolume(float soundLevel)
    {
        masterMixer.SetFloat("MusicVol", soundLevel);
        PreferencesManager.SetMusicVolume(soundLevel);
    }

    // Assign these in the Unity Inspector
    public AudioSource audioSource;
    
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public AudioClip audioClip4;
    public AudioClip audioClip5;

    // Example function to change the clip
    public void PlayNewClip()
    {
        // Stop any currently playing sound
        audioSource.Stop();

       
         

        // Play the new clip
        audioSource.Play();
    }
}
