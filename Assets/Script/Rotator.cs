using UnityEngine;

public class Rotator : MonoBehaviour
{
    // ��ת�ٶȣ�������Unity�༭�����Զ���ÿ������ٶ�
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);

    void Update()
    {
        // ����ʱ����趨���ٶ���ת����
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
