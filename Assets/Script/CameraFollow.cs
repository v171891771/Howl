using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ���ǵ� Transform
    private Vector3 offset; // �����������ǵ�ƫ��

    void Start()
    {
        // ��¼��ʼ�����λ��
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // ���������λ���Ա������λ��
        transform.position = target.position + offset;
    }
}