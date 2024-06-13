using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // 每个金币的值

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 获取 PlayerInventory 脚本并增加金币数量
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddCoins(coinValue);
            }

            // 销毁金币对象
            Destroy(gameObject);
        }
    }
}
