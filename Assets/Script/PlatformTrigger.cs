using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    public MovingPlatform[] movingPlatforms; // ���ö���ƶ�ƽ̨
    public int maxTriggerCount = 3; // ��󴥷�������Ĭ��Ϊ3��

    private int currentTriggerCount = 0;
    private bool playerInRange = false; // ����Ƿ��ڴ���������

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
