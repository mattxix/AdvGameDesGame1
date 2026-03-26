using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TikiManager : MonoBehaviour
{
    public int tikisPickedUp = 0;
    public int tikisToSpend = 0;
    public int totalTikisToCollect = 10;
    public TextMeshProUGUI tikiNumberText;
    public PowerUpsManager PowerUpsManagerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tikisPickedUp >= totalTikisToCollect)
        {
            //call win condition
        }
        

    }

    public void TikiPickedUp()
    {
        tikisPickedUp++;
        tikisToSpend++;
        tikiNumberText.text = tikisToSpend.ToString();
        PowerUpsManagerScript.UpdateShopVisibility();
        
    }
    
}
