using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{
    public GameObject surfaceWorld; // 表世界父对象
    public GameObject innerWorld; // 里世界父对象
    private bool isInnerWorldActive = false; // 当前世界状态
    private bool canSwitchWorlds = false; // 是否能切换世界

    void Start()
    {
        // 初始化为表世界
        surfaceWorld.SetActive(true);
        innerWorld.SetActive(false);
        Debug.Log("Initialized in Surface World.");
    }

    void Update()
    {
        // 按下 F 键切换世界
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
