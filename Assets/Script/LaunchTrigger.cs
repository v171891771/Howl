using UnityEngine;

public class LaunchTrigger : MonoBehaviour
{
    public Transform launchDirection; // 弹射方向的 Transform
    public float enhancedJumpHeight = 10f; // 增强的跳跃高度

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NierAutomataCharacterController playerController = other.GetComponent<NierAutomataCharacterController>();
            if (playerController != null)
            {
                playerController.SetEnhancedJump(enhancedJumpHeight);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            NierAutomataCharacterController playerController = other.GetComponent<NierAutomataCharacterController>();
            if (playerController != null)
            {
                playerController.ResetJumpHeight();
            }
        }
    }
}
