using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovingPlatform[] movingPlatforms; // 引用多个移动平台
    public int maxTriggerCount = 3; // 最大触发次数，默认为3次

    private int currentTriggerCount = 0;
    private bool playerInRange = false; // 玩家是否在触发区域内

    void Start()
    {
        if (movingPlatforms.Length == 0)
        {
            Debug.LogError("No MovingPlatform references set on PlatformTrigger.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered the trigger area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player exited the trigger area.");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && currentTriggerCount < maxTriggerCount)
        {
            foreach (var platform in movingPlatforms)
            {
                platform.StartMoving();
            }
            currentTriggerCount++;
            Debug.Log("E key pressed. Platforms started moving.");
        }
    }
}
