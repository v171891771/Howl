using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void StartGame()
    {
        // 加载主游戏场景
        SceneManager.LoadScene("Tower 3"); // 确保将 "MainScene" 替换为你主游戏场景的名称
    }

    public void QuitGame()
    {
        // 退出游戏
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
