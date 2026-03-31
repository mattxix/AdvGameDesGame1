using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TikiManager : MonoBehaviour
{
    public int tikisPickedUp = 0;
    public int tikisToSpend = 0;
    public int totalTikisToCollect = 16;
    public TextMeshProUGUI tikiNumberText;
    public TextMeshProUGUI tikiNumberGoal;
    public TextMeshProUGUI WinText;
    public TextMeshProUGUI TimerText;
    public PowerUpsManager PowerUpsManagerScript;

    float elapsedTime = 0f;
    bool timerRunning = true;

    public AudioSource pickUpAudio;
    public AudioClip clip;

    void Start()
    {
        WinText.gameObject.SetActive(false);
        pickUpAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            TimerText.text = FormatTime(elapsedTime);
        }
    }

    public void TikiPickedUp()
    {
        tikisPickedUp++;
        tikisToSpend++;
        pickUpAudio.PlayOneShot(clip);
        tikiNumberGoal.text = tikisPickedUp.ToString() + "/" + totalTikisToCollect;
        tikiNumberText.text = tikisToSpend.ToString();
        PowerUpsManagerScript.UpdateShopVisibility();

        if (tikisPickedUp >= totalTikisToCollect)
        {
            timerRunning = false;
            WinText.gameObject.SetActive(true);
            WinText.text = "You Win!\nTime: " + FormatTime(elapsedTime);
        }
    }

    string FormatTime(float time)
    {
        int minutes = (int)(time / 60);
        int seconds = (int)(time % 60);
        int milliseconds = (int)((time % 1) * 100);
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, milliseconds);
    }
}