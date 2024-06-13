using UnityEngine;
using UnityEngine.SceneManagement; // 确保包含此命名空间

public class EndTrigger : MonoBehaviour
{
    private bool playerInZone = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            Debug.Log("Player entered the trigger zone.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            Debug.Log("Player exited the trigger zone.");
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed. Loading end scene.");
            LoadEndScene();
        }
    }

    void LoadEndScene()
    {
        SceneManager.LoadScene("End"); // 确保将 "EndScene" 替换为你的结束界面场景名称
    }
}
