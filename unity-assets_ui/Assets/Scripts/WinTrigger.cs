using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript;
    public Text timerText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.StopTimer();
            timerText.fontSize = 60;
            timerText.color = Color.green;
        }
    }
        
    }
