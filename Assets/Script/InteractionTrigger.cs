using UnityEngine;
using UnityEngine.UI; // 如果使用Text

public class InteractionTrigger : MonoBehaviour
{
    public GameObject pressEText; // UI提示元素

    private bool playerInZone = false;

    void Start()
    {
        // 确保提示信息最开始是隐藏的
        if (pressEText != null)
        {
            pressEText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            if (pressEText != null)
            {
                pressEText.SetActive(true); // 显示提示
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            if (pressEText != null)
            {
                pressEText.SetActive(false); // 隐藏提示
            }
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (pressEText != null)
            {
                pressEText.SetActive(false); // 按下E键后隐藏提示
            }
            // 在这里添加按下E键后的其他逻辑
            Debug.Log("E key pressed.");
        }
    }
}
