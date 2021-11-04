using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerSystem : MonoBehaviour
{
    public Text timerText;
    public float timeLeftSeconds = 3F;
    public static bool TimesUp = false;
    public string SceneName;


    // Start is called before the first frame update
    void Start()
    {
        TimesUp = false;
    }

    // Update is called once per frame
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

        }

        if (TimesUp == true && Input.GetKeyDown("p"))
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);

        if (TimesUp == true && Input.GetKeyDown("m"))
            SceneManager.LoadScene("MenuScene");
    }

    void OnGUI()
    {
        if (TimesUp == true)
            GUI.Box(new Rect(0, 50, 800, 25), "You Lost! Press 'P' to play again. Otherwise press 'M' to return to the menu");
    }

}