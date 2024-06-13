using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 旋转速度，可以在Unity编辑器中自定义每个轴的速度
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);

    void Update()
    {
        // 根据时间和设定的速度旋转物体
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
