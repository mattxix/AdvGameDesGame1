using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUpsManager : MonoBehaviour
{
    public GameObject ShopCanvas;
    public TikiManager TikiManager;
    public TextMeshProUGUI JumpText;
    public TextMeshProUGUI SpeedText;
    public TextMeshProUGUI FallText;
    public FPMovement MovementScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShopCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (TikiManager.tikisToSpend > 0)
        {
            if (Keyboard.current.digit1Key.wasPressedThisFrame)
            {
                BuyPowerUp(1);
                UpdateShopVisibility();
            }
            else if (Keyboard.current.digit2Key.wasPressedThisFrame)
            {
                BuyPowerUp(2);
                UpdateShopVisibility();
            }
            else if (Keyboard.current.digit3Key.wasPressedThisFrame)
            {
                BuyPowerUp(3);
                UpdateShopVisibility();
            }
                
            
        }
    }
    private void BuyPowerUp(int choice)
    {
        TikiManager.tikisToSpend--;

        switch (choice)
        {
            case 1:
                MovementScript.jumpStrength += 3;
                break;
            case 2:
                MovementScript.speed += 3;
                break;
            case 3:
                MovementScript.gravity -= -1;
                break;
        }
    }

    public void UpdateShopVisibility()
    {
        bool isOpen = TikiManager.tikisToSpend > 0;
        ShopCanvas.SetActive(isOpen);
    }

    

}
