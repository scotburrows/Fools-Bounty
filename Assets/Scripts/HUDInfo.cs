using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDInfo : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI coins;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Vitals: " + PlayerAbilities.health.ToString() + "%";
        coins.text = "Doubloons: " + PlayerAbilities.coins.ToString();
    }
}
