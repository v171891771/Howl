using UnityEngine;
using System.Collections;

public class HookLockController : MonoBehaviour
{
    public float speed = 10f; // 钩锁的速度
    private bool isMoving = false; // 钩锁是否在移动
    private bool playerOnHookLock = false; // 玩家是否在钩锁上
    private GameObject player;
    private Vector3 playerOffset;
    private Vector3 initialPosition; // 钩锁的初始位置
    private bool isRespawning = false; // 钩锁是否在重生过程中

    void Start()
    {
        initialPosition = transform.position; // 记录钩锁的初始位置
    }

    void Update()
    {
        if (isMoving)
        {
            MoveHookLock();
        }

        if (playerOnHookLock && player != null)
        {
            // 保持玩家和钩锁的相对位置不变
            player.transform.position = transform.position + playerOffset;
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        Debug.Log("HookLock started moving.");
    }

    public void StopMoving()
    {
        isMoving = false;
        Debug.Log("HookLock stopped moving.");
    }

    public void PlayerEnterHookLock(GameObject playerObject)
    {
        playerOnHookLock = true;
        player = playerObject;
        playerOffset = player.transform.position - transform.position;
        Debug.Log("Player entered HookLock.");
    }

    public void PlayerExitHookLock()
    {
        playerOnHookLock = false;
        if (player != null)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // 设置玩家的速度为钩锁的前进方向
                playerRigidbody.velocity = transform.forward * speed;
            }
            player = null;
        }
        StopMoving(); // 玩家脱离时停止钩锁
        if (!isRespawning)
        {
            StartCoroutine(RespawnHookLock()); // 启动钩锁重生的协程
        }
        Debug.Log("Player exited HookLock.");
    }

    private void MoveHookLock()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log("HookLock is moving. Current position: " + transform.position);
    }

    private IEnumerator RespawnHookLock()
    {
        isRespawning = true; // 标记钩锁正在重生
        yield return new WaitForSeconds(3f); // 等待三秒
        if (!playerOnHookLock) // 确认玩家不在钩锁上
        {
            transform.position = initialPosition; // 将钩锁重置到初始位置
            Debug.Log("HookLock respawned at initial position.");
        }
        isRespawning = false; // 重置标记
    }

    // Public property to access isMoving
    public bool IsMoving
    {
        get { return isMoving; }
    }
}
