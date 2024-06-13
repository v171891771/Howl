using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1; // ÿ����ҵ�ֵ

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ��ȡ PlayerInventory �ű������ӽ������
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddCoins(coinValue);
            }

            // ���ٽ�Ҷ���
            Destroy(gameObject);
        }
    }
}
