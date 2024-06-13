using UnityEngine;

public class LaunchTrigger : MonoBehaviour
{
    public Transform launchDirection; // ���䷽��� Transform
    public float enhancedJumpHeight = 10f; // ��ǿ����Ծ�߶�

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
