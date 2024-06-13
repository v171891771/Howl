using UnityEngine;
using TMPro; // 使用TextMeshPro

public class PlayerInventory : MonoBehaviour
{
    public int totalCoins = 0; // 玩家收集的金币总数
    public TextMeshProUGUI coinText; // 显示金币数量的TextMeshPro文本

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + totalCoins;
        }
    }
}
