using UnityEngine;

public class ShowPanel : MonoBehaviour
{
    public GameObject panel; // 用于在检视面板中指定要显示的Panel

    public void TogglePanel()
    {
        if (panel != null)
        {
            bool isActive = panel.activeSelf;
            panel.SetActive(!isActive);
        }
    }
}
