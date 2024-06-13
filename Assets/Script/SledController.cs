using UnityEngine;
using System.Collections;

public class SledController : MonoBehaviour
{
    public float speed = 10f; // 滑雪板的速度
    public float jumpForce = 5f; // 跳跃力
    private bool isMoving = false; // 滑雪板是否在移动
    private bool playerOnSled = false; // 玩家是否在滑雪板上
    private GameObject player;
    private Vector3 playerOffset;
    private Vector3 initialPosition; // 滑雪板的初始位置
    private Quaternion initialRotation; // 滑雪板的初始旋转
    private bool isRespawning = false; // 滑雪板是否在重生过程中
    private bool isJumping = false; // 是否在跳跃中

    void Start()
    {
        initialPosition = transform.position; // 记录滑雪板的初始位置
        initialRotation = transform.rotation; // 记录滑雪板的初始旋转
    }

    void Update()
    {
        if (isMoving)
        {
            MoveSled();
        }

        if (playerOnSled && player != null)
        {
            // 保持玩家和滑雪板的相对位置不变
            player.transform.position = transform.position + playerOffset;

            // 检测空格键按下进行跳跃
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                Jump();
            }
        }
    }

    public void StartMoving()
    {
        isMoving = true;
        Debug.Log("Sled started moving.");
    }

    public void StopMoving()
    {
        isMoving = false;
        Debug.Log("Sled stopped moving.");
    }

    public void PlayerEnterSled(GameObject playerObject)
    {
        playerOnSled = true;
        player = playerObject;
        playerOffset = player.transform.position - transform.position;
        Debug.Log("Player entered sled.");
    }

    public void PlayerExitSled()
    {
        playerOnSled = false;
        if (player != null)
        {
            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                // 设置玩家的速度为滑雪板的前进方向
                playerRigidbody.velocity = transform.forward * speed;
            }
            player = null;
        }
        if (!isRespawning)
        {
            StartCoroutine(RespawnSled()); // 启动滑雪板重生的协程
        }
        Debug.Log("Player exited sled.");
    }

    private void MoveSled()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Debug.Log("Sled is moving. Current position: " + transform.position);
    }

    private IEnumerator RespawnSled()
    {
        isRespawning = true; // 标记滑雪板正在重生
        yield return new WaitForSeconds(3f); // 等待三秒
        if (!playerOnSled) // 确认玩家不在滑雪板上
        {
            transform.position = initialPosition; // 将滑雪板重置到初始位置
            transform.rotation = initialRotation; // 将滑雪板重置到初始旋转
            StopMoving(); // 停止滑雪板的移动
            Debug.Log("Sled respawned at initial position and stopped moving.");
        }
        isRespawning = false; // 重置标记
    }

    private void Jump()
    {
        if (player != null)
        {
            Rigidbody sledRigidbody = GetComponent<Rigidbody>();
            if (sledRigidbody != null)
            {
                sledRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isJumping = true;
                StartCoroutine(ResetJump());
                Debug.Log("Sled jumped.");
            }
        }
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(1f); // 设置跳跃冷却时间为1秒
        isJumping = false;
        Debug.Log("Jump reset.");
    }

    // Public property to access isMoving
    public bool IsMoving
    {
        get { return isMoving; }
    }
}
