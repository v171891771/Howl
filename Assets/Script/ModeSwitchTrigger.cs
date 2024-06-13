using UnityEngine;

public class ModeSwitchTrigger : MonoBehaviour
{
    public GameObject player; // 玩家对象
    public MonoBehaviour currentController; // 当前控制脚本
    public MonoBehaviour thirdPersonController; // 第三人称平台跳跃控制脚本
    public Transform targetObject; // 指定控制的目标对象

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // 禁用当前控制脚本
            currentController.enabled = false;

            // 设置第三人称平台跳跃控制脚本的目标对象
            ThirdPersonController tpc = thirdPersonController as ThirdPersonController;
            if (tpc != null)
            {
                tpc.target = targetObject;
            }

            // 启用第三人称平台跳跃控制脚本
            thirdPersonController.enabled = true;
            Debug.Log("Switched to third-person platformer mode.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            // 启用当前控制脚本
            currentController.enabled = true;

            // 禁用第三人称平台跳跃控制脚本
            thirdPersonController.enabled = false;
            Debug.Log("Switched back to current control mode.");
        }
    }
}
