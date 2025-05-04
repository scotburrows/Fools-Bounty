using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDInfo : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI coins;
    public Image ammo1;
    public Image ammo2;
    public Image ammo3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.text = PlayerAbilities.health.ToString() + "%";
        coins.text = PlayerAbilities.coins.ToString();

        if (PlayerAbilities.bullets >= 3)
        {
            ammo3.color = Color.white;
        }
        else
        {
            ammo3.color = new Color(0.5f, 0.5f, 0.5f);
        }

        if (PlayerAbilities.bullets >= 2)
        {
            ammo2.color = Color.white;
        }
        else
        {
            ammo2.color = new Color(0.5f, 0.5f, 0.5f);
        }

        if (PlayerAbilities.bullets >= 1)
        {
            ammo1.color = Color.white;
        }
        else
        {
            ammo1.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
}
