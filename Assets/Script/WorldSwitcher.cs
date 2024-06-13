using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject surfaceWorld; // �����縸����
    public GameObject innerWorld; // �����縸����
    private bool isInnerWorldActive = false; // ��ǰ����״̬
    private bool canSwitchWorlds = false; // �Ƿ����л�����

    void Start()
    {
        // ��ʼ��Ϊ������
        surfaceWorld.SetActive(true);
        innerWorld.SetActive(false);
        Debug.Log("Initialized in Surface World.");
    }

    void Update()
    {
        // ���� F ���л�����
        if (canSwitchWorlds && Input.GetKeyDown(KeyCode.F))
        {
            SwitchWorld();
        }
    }

    public void SwitchWorld()
    {
        isInnerWorldActive = !isInnerWorldActive;

        surfaceWorld.SetActive(!isInnerWorldActive);
        innerWorld.SetActive(isInnerWorldActive);

        Debug.Log("Switched to " + (isInnerWorldActive ? "Inner World" : "Surface World"));
    }

    public void EnableSwitchWorldAbility()
    {
        canSwitchWorlds = true;
        Debug.Log("Switch world ability enabled.");
    }
}
