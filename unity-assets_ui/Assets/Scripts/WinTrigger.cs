using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Timer timerScript;
    public Text timerText;
    public GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.StopTimer();
            timerScript.Win();

            timerText.fontSize = 60;
            timerText.color = Color.green;

            winCanvas.SetActive(true);
        }
    }
}
