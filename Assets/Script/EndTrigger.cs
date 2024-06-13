using UnityEngine;
using UnityEngine.SceneManagement; // ȷ�������������ռ�

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
        SceneManager.LoadScene("End"); // ȷ���� "EndScene" �滻Ϊ��Ľ������泡������
    }
}
