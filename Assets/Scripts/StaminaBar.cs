using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider slider;
    public PlayerMovement player;
    public Image sliderFill;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerMovement.haste)
        {
            sliderFill.color = new Color(249 / 255f, 213 / 255f, 63 / 255f);
            slider.value = PlayerMovement.haste_time;
        }
        else if (player.canSprint)
        {
            sliderFill.color = new Color(63 / 255f, 131 / 255f, 249 / 255f);
            slider.value = PlayerMovement.stamina;
        }
        else
        {
            sliderFill.color = new Color (249 / 255f, 64 / 255f, 78 / 255f);
            slider.value = PlayerMovement.stamina;
        }
    }
}
