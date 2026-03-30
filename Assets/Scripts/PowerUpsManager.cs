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
    public TextMeshProUGUI StatsJump;
    public TextMeshProUGUI StatsSpeed;
    public TextMeshProUGUI StatsFalling;

    public int JumpUpgradeCount = 0;
    public int SpeedUpgradeCount = 0;
    public int FallingUpgradeCount = 0;

    void Start()
    {
        ShopCanvas.SetActive(false);
    }

    void Update()
    {
        if (TikiManager.tikisToSpend <= 0) return;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            BuyPowerUp(1);
        else if (Keyboard.current.digit2Key.wasPressedThisFrame)
            BuyPowerUp(2);
        else if (Keyboard.current.digit3Key.wasPressedThisFrame)
            BuyPowerUp(3);
    }

    private void BuyPowerUp(int choice)
    {
        TikiManager.tikisToSpend--;  

        switch (choice)
        {
            case 1:
                MovementScript.jumpStrength += 2;
                JumpUpgradeCount++;       
                break;
            case 2:
                MovementScript.speed += 2;
                SpeedUpgradeCount++;
                break;
            case 3:
                MovementScript.gravity += .75f;  
                FallingUpgradeCount++;
                break;
        }

        UpdateStatText();
        UpdateShopVisibility();
    }

    public void UpdateShopVisibility()
    {
        ShopCanvas.SetActive(TikiManager.tikisToSpend > 0);
        TikiManager.tikiNumberText.text = TikiManager.tikisToSpend.ToString();
        
    }

    public void UpdateStatText()
    {
        
        StatsJump.text = new string('+', JumpUpgradeCount) + " Jump";
        StatsSpeed.text = new string('+', SpeedUpgradeCount) + " Speed";
        StatsFalling.text = new string('+', FallingUpgradeCount) + " Falling";
    }
}