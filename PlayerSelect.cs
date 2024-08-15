using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] Button nextButton, prevButton, selectButton, buyButton;

    public CarInfo[] carInfo;

    private int selectedCar = 0;
    private int totalCoins;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 100);
        coinsText.text = "Coins : " + totalCoins;
        foreach(CarInfo info in carInfo)
        {
            if (info.price == 0 )
            {
                info.isUnlock = true;
            }
            else
            {
                info.isUnlock = PlayerPrefs.GetInt
                (info.name, 0) == 0 ? false : true;
            }
        }

        if (carInfo[selectedCar].isUnlock == true)
        {
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            buyButton.GetComponentInChildren<TMP_Text>().text
            = carInfo[selectedCar].price.ToString();
            if (totalCoins < carInfo[selectedCar].price)
            {
                selectButton.gameObject.SetActive(false);
                buyButton.gameObject.SetActive(true);
                buyButton.interactable = false;
            }
            else
            {
                selectButton.gameObject.SetActive(false);
                buyButton.gameObject.SetActive(true);
                buyButton.interactable = true;
            }
        }
    }

    public void NextCar()
    {
        cars[selectedCar].SetActive(false);
        selectedCar = (selectedCar + 1) % cars.Length;
        cars[selectedCar].SetActive(true);
        UpdateUI();
    }

    public void PreviousCar()
    {
        cars[selectedCar].SetActive(false);
        selectedCar--;
        if (selectedCar < 0)
        {
            selectedCar += cars.Length;
        }
        cars[selectedCar].SetActive(true);
        UpdateUI();
    }

    public void BuyCar()
    {
        int price = carInfo[selectedCar].price;
        print(price);
        PlayerPrefs.SetInt("TotalCoins", totalCoins - price);
        PlayerPrefs.SetInt(carInfo[selectedCar].name, 1);
        UpdateUI();
    }

    public void Select()
    {
        PlayerPrefs.SetInt("selectedCar", selectedCar);
        SceneManager.LoadScene(0);
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
}