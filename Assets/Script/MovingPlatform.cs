using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward; // 移动方向，默认为向前
    public float moveDistance = 10f; // 移动距离，默认为10单位
    public float moveSpeed = 1f; // 移动速度，默认为1单位/秒
    public bool resetAfterMove = true; // 移动到终点后是否复位

    private Vector3 initialPosition; // 板子的初始位置
    private Vector3 targetPosition; // 板子的目标位置
    private bool isMoving = false; // 板子是否在移动

    void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + moveDirection.normalized * moveDistance;
    }

    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }

    public void StartMoving()
    {
        if (!isMoving)
        {
            isMoving = true;
            initialPosition = transform.position;
            targetPosition = initialPosition + moveDirection.normalized * moveDistance;
        }
    }

    private void MovePlatform()
    {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
        {
            if (resetAfterMove)
            {
                transform.position = initialPosition; // 重置到初始位置以便于下一次移动
            }
            isMoving = false;
        }
    }
}
