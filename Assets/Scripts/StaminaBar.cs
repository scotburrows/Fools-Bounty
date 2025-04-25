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
        slider.value = player.stamina;
        if (player.canSprint)
        {
            sliderFill.color = new Color(63 / 255f, 131 / 255f, 249 / 255f);
        }
        else
        {
            sliderFill.color = new Color (249 / 255f, 64 / 255f, 78 / 255f);
        }
    }
}
