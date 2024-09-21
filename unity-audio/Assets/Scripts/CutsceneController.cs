using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject player;
    public GameObject timerCanvas;

    private Animator cutsceneAnimator;
    private PlayerController playerController;

    void Start()
    {
        cutsceneAnimator = GetComponent<Animator>();
        playerController = player.GetComponent<PlayerController>();

        mainCamera.SetActive(false);
        playerController.enabled = false;
        timerCanvas.SetActive(false);
    }

    void Update()
    {
        if (cutsceneAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !cutsceneAnimator.IsInTransition(0))
        {
            mainCamera.SetActive(true);
            playerController.enabled = true;
            timerCanvas.SetActive(true);
            this.enabled = false;
        }
    }
}
