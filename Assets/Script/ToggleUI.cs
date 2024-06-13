using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject panel; // 指向你的UI界面的引用
    private bool isPlayerInRange = false; // 检查玩家是否在触发区内

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            panel.SetActive(!panel.activeSelf); // 切换面板的显示状态
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保是玩家进入触发区
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // 玩家离开触发区
        {
            isPlayerInRange = false;
            panel.SetActive(false); // 离开触发区时隐藏面板
        }
    }
}
