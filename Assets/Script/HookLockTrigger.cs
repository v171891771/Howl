using UnityEngine;

public class HookLockTrigger : MonoBehaviour
{
    private HookLockController hookLockController;
    private bool playerInRange = false;

    void Start()
    {
        hookLockController = GetComponentInParent<HookLockController>(); // 获取钩锁的控制脚本
        Debug.Log("HookLockTrigger initialized.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered the HookLock trigger area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            hookLockController.PlayerExitHookLock();
            Debug.Log("Player exited the HookLock trigger area.");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (hookLockController.IsMoving)
            {
                hookLockController.PlayerExitHookLock();
                Debug.Log("E key pressed. Player exited HookLock and HookLock stopped moving.");
            }
            else
            {
                hookLockController.PlayerEnterHookLock(GameObject.FindGameObjectWithTag("Player"));
                hookLockController.StartMoving();
                Debug.Log("E key pressed. HookLock started moving and player entered HookLock.");
            }
        }
    }
}
