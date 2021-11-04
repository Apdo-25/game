using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // GameManager deals with the state type of the game, in this case for "Win" and "Reset"
    public static GameManager instance = null;
    public GameObject youWinText;
    public float resetDelay;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

    }
    public void Win()
    {
        // Shows the win text once you collide with the trophy and delays time for dramatic effect
        youWinText.SetActive(true);
        Time.timeScale = .2f;
        Invoke("Reset", resetDelay);
    }

    void Reset()
    {
        // Loads the next scene, previously would reset
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}