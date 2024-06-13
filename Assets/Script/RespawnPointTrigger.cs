using UnityEngine;

public class RespawnPointTrigger : MonoBehaviour
{
    public Transform respawnPoint;
    private RespawnManager respawnManager;

    void Start()
    {
        respawnManager = FindObjectOfType<RespawnManager>();
        if (respawnManager == null)
        {
            Debug.LogError("RespawnManager not found in the scene.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            respawnManager.SetRespawnPoint(respawnPoint.position);
            Debug.Log("Player entered respawn point trigger. Respawn point set to: " + respawnPoint.position);
        }
    }
}
