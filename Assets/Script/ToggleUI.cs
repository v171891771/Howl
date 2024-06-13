using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject panel; // ָ�����UI���������
    private bool isPlayerInRange = false; // �������Ƿ��ڴ�������

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            panel.SetActive(!panel.activeSelf); // �л�������ʾ״̬
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ȷ������ҽ��봥����
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // ����뿪������
        {
            isPlayerInRange = false;
            panel.SetActive(false); // �뿪������ʱ�������
        }
    }
}
