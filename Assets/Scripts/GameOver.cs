using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image deathOverlay;
    float color = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        deathOverlay.color = new Color(0.78125f, 0f, 0f, color);
        color -= Time.deltaTime;
        if (color <= 0f && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }
}
