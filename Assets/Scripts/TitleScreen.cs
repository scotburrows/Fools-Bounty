using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public AudioSource sound;
    public AudioClip title1;
    public AudioClip title2;
    //Button
    public Image button1;
    public Image button2;
    Sprite inactive;
    Sprite active;
    AudioSource startSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Play title screen music
        startSound = GetComponent<AudioSource>();
        if (UnityEngine.Random.Range(0f, 2f) >= 1f) sound.clip = title1;
        else sound.clip = title2;
        sound.Play();

        inactive = button1.sprite;
        active = button2.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
        //Debug.Log(name + " Game Object Clicked!");
        startSound.Play();
        SceneManager.LoadScene("TheWorld");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button1.sprite = active;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button1.sprite = inactive;
    }

}
