using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // ��������Ϸ����
        SceneManager.LoadScene("Tower 3"); // ȷ���� "MainScene" �滻Ϊ������Ϸ����������
    }

    public void QuitGame()
    {
        // �˳���Ϸ
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
