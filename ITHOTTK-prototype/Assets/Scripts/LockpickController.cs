using UnityEngine;

public class LockpickController : MonoBehaviour
{
    public GameObject lockpickUI;             // Parent GameObject holding lock UI
    public LockStage[] lockStages;            // List of lock stages (columns)
    private int currentStage = 0;
    private bool isRunning = false;
    private LockableObject currentTarget;     // The thing being unlocked

    void Start()
    {
        if (lockpickUI != null)
            lockpickUI.SetActive(false);      // Hide UI at start

        HideAllStages();
    }

    void Update()
    {
        if (!isRunning) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (lockStages[currentStage].CheckLock())
            {
                currentStage++;

                if (currentStage < lockStages.Length)
                {
                    SetActiveStage(currentStage);
                }
                else
                {
                    Debug.Log("Lockpicking success!");
                    currentTarget?.OnUnlockSuccess();
                    EndMinigame();
                }
            }
            else
            {
                Debug.Log("Failed lockpick.");
                currentTarget?.OnUnlockFail();
                EndMinigame();
            }
        }
    }

    public void StartMinigame(LockableObject target)
    {
        currentTarget = target;
        currentStage = 0;
        isRunning = true;

        if (lockpickUI != null)
            lockpickUI.SetActive(true); // Show picklock UI

        for (int i = 0; i < lockStages.Length; i++)
        {
            lockStages[i].ResetStage();
            lockStages[i].gameObject.SetActive(true);
        }

        SetActiveStage(currentStage);

        // Disable player movement script 
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var movement = player.GetComponent<playerController>(); 
            if (movement != null)
                movement.enabled = false;
        }
    }

    public void EndMinigame()
    {
        isRunning = false;

        if (lockpickUI != null)
            lockpickUI.SetActive(false); // Hide picklock UI

        HideAllStages();

        // Re-enable player movement 
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var movement = player.GetComponent<playerController>();
            if (movement != null)
                movement.enabled = true;
        }
    }

    private void SetActiveStage(int index)
    {
        for (int i = 0; i < lockStages.Length; i++)
        {
            lockStages[i].SetHighlight(i == index);
        }
    }

    private void HideAllStages()
    {
        foreach (LockStage stage in lockStages)
        {
            stage.gameObject.SetActive(false);
        }
    }
}
