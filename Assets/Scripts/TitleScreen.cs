using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    AudioSource sound;
    public AudioClip title1;
    public AudioClip title2;
    //Button

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Play title screen music
        sound = GetComponent<AudioSource>();
        if (UnityEngine.Random.Range(0f, 2f) >= 1f) sound.clip = title1;
        else sound.clip = title2;
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // Pirate 2 or Pirate 5
    }
}
