using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paket : MonoBehaviour
{
    [SerializeField] TMP_Text jumlahPaketText;
    private GameObject[] paket;
    private int currentLvl;

    void Start()
    {
        currentLvl = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        paket = GameObject.FindGameObjectsWithTag("Paket");
        jumlahPaketText.text = paket.Length.ToString();

        if (paket.Length == 0)
        {
            Invoke("WinSequence", 0.2f);
        }
    }

    void WinSequence()
    {
        PlayerPrefs.SetInt("PrevLvl", currentLvl);
        PlayerPrefs.SetInt("NextLvl", currentLvl + 1);
        if (PlayerPrefs.GetInt("UnlockedLevel") <= currentLvl)
        {
            PlayerPrefs.SetInt("UnlockedLevel", currentLvl + 1);
        }
        PlayerPrefs.SetString("ResultString", "YOU WIN!");
        SceneManager.LoadScene(1);
    }
}