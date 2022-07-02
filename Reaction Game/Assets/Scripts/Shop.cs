using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    public Button button;
    private TMP_Text buttonText;
    private GameManager gameManager;
    private Sprite newImage; // The image/sprite associated with this shop button.
    private string newImageName;
    public static Sprite currentEquippedImage; // a variable to store the currently equipped player sprite. This is volatile, (gets deleted when game is closed), so player preferences are used to keep track of this between sessions.

    void Start()
    {
        buttonText = button.transform.Find("PriceText").GetComponent<TMP_Text>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        newImage = button.GetComponent<Image>().sprite;
        newImageName = button.GetComponent<Image>().sprite.name;
        CheckPreferencesForEquipped();
        ModifyButtonBasedOnIfOwnedOrEquipped();
    }
    public void PurchaseItem()
    {
       buttonText.text = "Equip";
       PlayerPrefs.SetString(newImageName, "Unequipped");
    }
    public void EquipItem()
    {
        if (currentEquippedImage != null)
            PlayerPrefs.SetString(currentEquippedImage.name, "Unequipped");
        currentEquippedImage = newImage;
        
        GameManager.playerImage = newImage;
        PlayerPrefs.SetString(newImageName, "Equipped");
        buttonText.text = "Equipped";
        button.interactable = false;
    }

    public void PressedButton()
    {
        if (PlayerPrefs.GetString(newImageName, "Not Purchased") == "Not Purchased") // If button pressed and item not purchased, purchase item.
            PurchaseItem();
        else if (PlayerPrefs.GetString(newImageName, "Not Purchased") == "Unequipped") // If button pressed and item is purchased but not equipped (i.e. unequipped), then equip item
            EquipItem();
            ReloadScene(); // reload the scene to update the buttons.
    }

    private void ModifyButtonBasedOnIfOwnedOrEquipped()
    {
        if (PlayerPrefs.GetString(newImageName, "Not Purchased") == "Unequipped") // If this image is marked as 'Unequipped' set button to interactable and change the button text.
        {
            button.interactable = true;
            buttonText.text = "Equip";
        }
        else if (PlayerPrefs.GetString(newImageName, "Not Purchased") == "Equipped") // If this image is marked as 'Equipped' set the button to not interactable and change the button text.
        {
            button.interactable = false;
            buttonText.text = "Equipped";
        }
    }

    private void CheckPreferencesForEquipped()
    {
        if (PlayerPrefs.GetString(newImageName, "Not Purchased") == "Equipped") // if the image associated with this button has been marked as 'Equipped' in the Player Preferences
        {
            if (currentEquippedImage != null) // If the currently equipped image is not null (meaning it has been set/defined).
            {
                if (currentEquippedImage != newImage) // If the currently equipped image is not the same as the image assiciated with this button.
                {
                    PlayerPrefs.SetString(newImageName, "Unequipped"); // Then set this preference to 'Unequipped' as this image is no longer equipped.
                }
            }
            else // If the currently equipped image is null (meaning the game has just been loaded up so it has not been set yet)
            {
                currentEquippedImage = newImage; // Assign the image associated with this button as the equipped image, as when the game loads up, there should only be 1 preference marked as 'Equipped'.
                GameManager.playerImage = newImage; // Change the player image as this will be the default every time the game is launched.
            }
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
