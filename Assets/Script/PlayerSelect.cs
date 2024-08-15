using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
    [SerializeField] TMP_Text coinsText;
    [SerializeField] Button nextButton, prevButton, selectButton, buyButton;

    public CharacterInfo[] charInfo;

    private int selectedChar = 0;
    private int totalCoins;
    
    private void Start() 
    {
        UpdateUI();
    }

    private void UpdateUI() 
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 100);
        coinsText.text = "Coins : " + totalCoins;

        foreach(CharacterInfo info in charInfo)
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
        
        if (charInfo[selectedChar].isUnlock == true)
        {
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            buyButton.GetComponentInChildren<TMP_Text>().text 
            = charInfo[selectedChar].price.ToString();
            if (totalCoins < charInfo[selectedChar].price)
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
        cars[selectedChar].SetActive(false);
        selectedChar = (selectedChar + 1) % cars.Length;
        cars[selectedChar].SetActive(true);
        UpdateUI();
    }

    public void PreviousCar()
    {
        cars[selectedChar].SetActive(false);
        selectedChar--;
        if (selectedChar < 0)
        {
            selectedChar += cars.Length;
        }
        cars[selectedChar].SetActive(true);
        UpdateUI();
    }

    public void BuyCar()
    {
        int price = charInfo[selectedChar].price;
        print(price);
        PlayerPrefs.SetInt("TotalCoins", totalCoins - price);
        PlayerPrefs.SetInt(charInfo[selectedChar].name, 1);
        UpdateUI();
    }

    public void Select()
    {
        PlayerPrefs.SetInt("selectedChar", selectedChar);
        SceneManager.LoadScene(0);
    }
}