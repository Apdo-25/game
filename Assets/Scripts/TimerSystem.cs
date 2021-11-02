using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerSystem : MonoBehaviour {
    private const double V = 0.0;   
    public Text timerText;
    public float timeLeftSeconds = 3F;
    public static bool TimesUp = false;

    // This declaration allows us to use TimerSystem on any scene inside its component
    public string Scene;

    void Start()
    {
        //startTime = Time.time 
        TimesUp = false;

    }

    void Update()
    {
        float t = timeLeftSeconds -= Time.deltaTime;

        string minutes = ((int)t / 60).ToString("00");
        string seconds = (t % 60).ToString("00");
        string milliseconds = ((int)(t * 100f) % 100).ToString("00");

        timerText.text = minutes + ":" + seconds + ":" + milliseconds;

        if (timeLeftSeconds <= 0)
        {
            timeLeftSeconds = 0;
            timerText.text = minutes + ":" + seconds;
            TimesUp = true;
            Time.timeScale = (float)V;

        }

        // Once TimesUp is true the user can then select between the keys 'p' or 'm' to restart the stage or return to menu
        if (TimesUp == true && Input.GetKeyDown("p"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (TimesUp == true && Input.GetKeyDown("m"))
            SceneManager.LoadScene("MenuScene");

    }

    // Displays a rectangular box with the lose message
    void OnGUI()
    {
        if (TimesUp == true)
            GUI.Box(new Rect(0, 50, 800, 25), "You Lost! Press 'P' to play again. Otherwise press 'M' to return to the menu");
    }

}
