using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    public GameObject panel; // �����ڼ��������ָ��Ҫ��ʾ��Panel

    public void TogglePanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }
}
