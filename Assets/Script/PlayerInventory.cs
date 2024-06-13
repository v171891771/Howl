using UnityEngine;
using TMPro; // ʹ��TextMeshPro

public class PlayerInventory : MonoBehaviour
{
    public int totalCoins = 0; // ����ռ��Ľ������
    public TextMeshProUGUI coinText; // ��ʾ���������TextMeshPro�ı�

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
