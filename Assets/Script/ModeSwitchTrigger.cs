using UnityEngine;

public class ModeSwitchTrigger : MonoBehaviour
{
    public GameObject player; // ��Ҷ���
    public MonoBehaviour currentController; // ��ǰ���ƽű�
    public MonoBehaviour thirdPersonController; // �����˳�ƽ̨��Ծ���ƽű�
    public Transform targetObject; // ָ�����Ƶ�Ŀ�����

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // ���õ�ǰ���ƽű�
            currentController.enabled = false;

            // ���õ����˳�ƽ̨��Ծ���ƽű���Ŀ�����
            ThirdPersonController tpc = thirdPersonController as ThirdPersonController;
            if (tpc != null)
            {
                tpc.target = targetObject;
            }

            // ���õ����˳�ƽ̨��Ծ���ƽű�
            thirdPersonController.enabled = true;
            Debug.Log("Switched to third-person platformer mode.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            // ���õ�ǰ���ƽű�
            currentController.enabled = true;

            // ���õ����˳�ƽ̨��Ծ���ƽű�
            thirdPersonController.enabled = false;
            Debug.Log("Switched back to current control mode.");
        }
    }
}
