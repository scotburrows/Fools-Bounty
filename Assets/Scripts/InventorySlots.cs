using UnityEngine;
using UnityEngine.UI;

public class InventorySlots : MonoBehaviour
{
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Image slot4;
    Sprite active;
    Sprite inactive;
    public Image item1;
    public Image item2;
    public Image item3;
    public Image item4;
    Sprite gun;
    Sprite chest;
    Sprite potion;
    Sprite fish;
    public PlayerAbilities player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        active = slot1.sprite;
        inactive = slot2.sprite;
        gun = item1.sprite;
        chest = item2.sprite;
        potion = item3.sprite;
        fish = item4.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAbilities.playerSlot == 1)
        {
            slot1.sprite = active;
        }
        else
        {
            slot1.sprite = inactive;
        }

        if (PlayerAbilities.playerSlot == 2)
        {
            slot2.sprite = active;
        }
        else
        {
            slot2.sprite = inactive;
        }

        if (PlayerAbilities.playerSlot == 3)
        {
            slot3.sprite = active;
        }
        else
        {
            slot3.sprite = inactive;
        }

        if (PlayerAbilities.playerSlot == 4)
        {
            slot4.sprite = active;
        }
        else
        {
            slot4.sprite = inactive;
        }

        if (PlayerAbilities.bullets > 0)
        {
            item1.color = Color.white;
        }
        else
        {
            item1.color = new Color(0.5f, 0.5f, 0.5f);
        }

        if (!PlayerAbilities.slot2)
        {
            item2.sprite = null;
            item2.color = new Color(1f, 1f, 1f, 0f);
        }
        else if (PlayerAbilities.slot2.GetComponent<Rigidbody>())
        {
            item2.sprite = chest;
            item2.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            item2.sprite = potion;
            item2.color = new Color(1f, 1f, 1f, 1f);
        }

        if (!PlayerAbilities.slot3)
        {
            item3.sprite = null;
            item3.color = new Color(1f, 1f, 1f, 0f);
        }
        else if (PlayerAbilities.slot3.GetComponent<Rigidbody>())
        {
            item3.sprite = chest;
            item3.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            item3.sprite = potion;
            item3.color = new Color(1f, 1f, 1f, 1f);
        }

        if (!PlayerAbilities.slot4)
        {
            item4.sprite = null;
            item4.color = new Color(1f, 1f, 1f, 0f);
        }
        else if (PlayerAbilities.slot4.GetComponent<Rigidbody>())
        {
            item4.sprite = chest;
            item4.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            item4.sprite = potion;
            item4.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
