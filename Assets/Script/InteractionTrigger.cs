using UnityEngine;
using UnityEngine.UI; // ���ʹ��Text

public class InteractionTrigger : MonoBehaviour
{
    public GameObject pressEText; // UI��ʾԪ��

    private bool playerInZone = false;

    void Start()
    {
        // ȷ����ʾ��Ϣ�ʼ�����ص�
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
                pressEText.SetActive(true); // ��ʾ��ʾ
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
                pressEText.SetActive(false); // ������ʾ
            }
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            if (pressEText != null)
            {
                pressEText.SetActive(false); // ����E����������ʾ
            }
            // ��������Ӱ���E����������߼�
            Debug.Log("E key pressed.");
        }
    }
}
