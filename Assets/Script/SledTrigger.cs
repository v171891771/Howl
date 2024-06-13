using UnityEngine;

public class SledTrigger : MonoBehaviour
{
    private SledController sledController;
    private bool playerInRange = false;

    void Start()
    {
        sledController = GetComponentInParent<SledController>(); // 获取滑雪板的控制脚本
        Debug.Log("SledTrigger initialized.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered the sled trigger area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            sledController.PlayerExitSled();
            Debug.Log("Player exited the sled trigger area.");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (sledController.IsMoving)
            {
                sledController.PlayerExitSled();
                Debug.Log("E key pressed. Player exited sled but sled keeps moving.");
            }
            else
            {
                sledController.PlayerEnterSled(GameObject.FindGameObjectWithTag("Player"));
                sledController.StartMoving();
                Debug.Log("E key pressed. Sled started moving and player entered sled.");
            }
        }
    }
}
