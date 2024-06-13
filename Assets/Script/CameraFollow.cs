using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 主角的 Transform
    private Vector3 offset; // 相机相对于主角的偏移

    void Start()
    {
        // 记录初始的相对位置
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // 更新相机的位置以保持相对位置
        transform.position = target.position + offset;
    }
}