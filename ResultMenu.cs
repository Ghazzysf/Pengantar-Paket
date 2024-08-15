using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultMenu : MonoBehaviour
{
    [SerializeField] TMP_Text titleText;
    [SerializeField] Button nextButton;

    private string resultString;
    private int unlockedLvl, prevLvl, nextLvl, currentCoins;

    void Start()
    {
        resultString = PlayerPrefs.GetString("ResultString");
        titleText.text = resultString;

        unlockedLvl = PlayerPrefs.GetInt("UnlockedLevel");
        prevLvl = PlayerPrefs.GetInt("PrevLvl");
        nextLvl = prevLvl + 1;
        currentCoins = PlayerPrefs.GetInt("TotalCoins");

        if (resultString == "YOU LOSE!")
        {
            titleText.color = Color.red;
        }
        else
        {
            titleText.color = Color.green;
            PlayerPrefs.SetInt("TotalCoins", currentCoins + 50);
        }

        if (unlockedLvl >= nextLvl)
        {
            nextButton.interactable = true;
        }
        else{
            nextButton.gameObject.SetActive(false);
        }

        if (nextLvl > 8)
        {
            nextButton.gameObject.SetActive(false);
        }
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(prevLvl);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Next()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextLvl);
    }
}