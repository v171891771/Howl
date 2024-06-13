using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private Vector3 respawnPoint;
    private GameObject player;

    void Start()
    {
        // 找到玩家对象并设置初始的复活点
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            respawnPoint = player.transform.position;
            Debug.Log("Initial respawn point set to: " + respawnPoint);
        }
        else
        {
            Debug.LogError("Player object not found.");
        }
    }

    void Update()
    {
        // 按下 R 键复活
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key pressed. Respawning player.");
            Respawn(player);
        }
    }

    public void SetRespawnPoint(Vector3 newRespawnPoint)
    {
        respawnPoint = newRespawnPoint;
        Debug.Log("Respawn point updated to: " + respawnPoint);
    }

    public void Respawn(GameObject player)
    {
        if (player != null)
        {
            Debug.Log("Respawning player to: " + respawnPoint);

            // 禁用 CharacterController 以避免冲突
            CharacterController characterController = player.GetComponent<CharacterController>();
            if (characterController != null)
            {
                characterController.enabled = false;
            }

            player.transform.position = respawnPoint;
            Debug.Log("Player position set to: " + player.transform.position);

            // 重置玩家的速度
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                Debug.Log("Player's Rigidbody velocity reset.");
            }

            NierAutomataCharacterController controller = player.GetComponent<NierAutomataCharacterController>();
            if (controller != null)
            {
                controller.ResetVelocity();
                Debug.Log("Player's NierAutomataCharacterController velocity reset.");
            }

            // 重新启用 CharacterController
            if (characterController != null)
            {
                characterController.enabled = true;
            }
        }
        else
        {
            Debug.LogWarning("Player object is null. Cannot respawn.");
        }
    }
}
