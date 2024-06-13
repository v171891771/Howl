using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // 玩家对象
    public Transform[] triggerPositions; // 触发位置数组
    public Transform[] cameraTargetPositions; // 摄像机目标位置数组
    public float moveSpeed = 2f; // 摄像机移动速度
    public float rotateSpeed = 2f; // 摄像机旋转速度
    public float triggerDistance = 1f; // 触发摄像机移动的距离

    private Vector3 offset; // 相机相对于玩家的偏移量
    private int currentTriggerIndex = -1; // 当前触发位置索引
    private bool isMovingToTarget = false; // 摄像机是否在移动到目标位置

    void Start()
    {
        // 记录初始的相对位置
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (isMovingToTarget)
        {
            // 移动摄像机到目标位置
            Transform targetPosition = cameraTargetPositions[currentTriggerIndex];
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetPosition.rotation, rotateSpeed * Time.deltaTime);

            // 检查摄像机是否到达目标位置
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f && Quaternion.Angle(transform.rotation, targetPosition.rotation) < 1f)
            {
                isMovingToTarget = false;
                // 更新 offset 为新的相对位置
                offset = transform.position - player.position;
                Debug.Log("Camera reached target position. New offset: " + offset);
            }
        }
        else
        {
            // 继续追随玩家
            Vector3 desiredPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.deltaTime);
        }

        // 检查玩家是否到达触发位置
        for (int i = 0; i < triggerPositions.Length; i++)
        {
            if (Vector3.Distance(player.position, triggerPositions[i].position) < triggerDistance)
            {
                if (i != currentTriggerIndex)
                {
                    currentTriggerIndex = i;
                    isMovingToTarget = true;
                    Debug.Log("Trigger position reached: " + triggerPositions[i].position + ", moving camera to: " + cameraTargetPositions[currentTriggerIndex].position);
                    break;
                }
            }
        }
    }
}
