using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text timesUpText;
    [SerializeField] float timeAmount;

    private bool timesUp;
    private int currentLvl;

    void Start()
    {
        timesUp = false;
        timesUpText.gameObject.SetActive(false);
        currentLvl = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (timesUp == false)
        {
            RunTimer();
        }
    }

    public void RunTimer()
    {
        if (timeAmount > 0)
        {
            timeAmount -= Time.deltaTime;
            DisplayTime(timeAmount);
        }
        else
        {
            timesUp = true;
            timeAmount = 0;
            timesUpText.gameObject.SetActive(true);
            Invoke("LoseSequence", 0.5f);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void LoseSequence()
    {
        PlayerPrefs.SetInt("PrevLvl", currentLvl);
        PlayerPrefs.SetString("ResultString", "YOU LOSE!");
        SceneManager.LoadScene(1);
    }
}