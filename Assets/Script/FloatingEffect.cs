using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatSpeed = 1f; // 浮动速度
    public float floatAmplitude = 0.5f; // 浮动幅度

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // 记录初始位置
    }

    void Update()
    {
        // 计算新的浮动位置
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // 应用新的位置
        transform.position = newPosition;
    }
}
