using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public Button button;
    private TMP_Text buttonText;
    private GameManager gameManager;
    private Sprite newImage;

    void Start()
    {
        buttonText = button.transform.Find("PriceText").GetComponent<TMP_Text>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void PurchaseItem()
    {
       buttonText.text = "Equip";
    }
    public void EquipItem()
    {
        newImage = button.GetComponent<Image>().sprite;
        GameManager.playerImage = newImage;
        buttonText.text = "Equipped";
        button.interactable = false;
    }

    public void PressedButton()
    {
        if (buttonText.text == "Free")
            PurchaseItem();
        else if (buttonText.text == "Equip")
            EquipItem();
    }
}
