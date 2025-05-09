using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image deathOverlay;
    float color = 1;
    public float red = 0.78125f;
    public float blue = 0f;
    public float green = 0f;
    public bool doubleClick = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        deathOverlay.color = new Color(red, blue, green, color);
        color -= Time.deltaTime;
        if (color <= 0f && Input.GetMouseButtonDown(0))
        {
            if (!doubleClick)
            {
                SceneManager.LoadScene("TitleScreen");
            }
            else
            {
                doubleClick = false;
            }
        }
    }
}
