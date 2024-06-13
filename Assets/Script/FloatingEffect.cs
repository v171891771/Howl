using UnityEngine;

public class FloatingEffect : MonoBehaviour
{
    public float floatSpeed = 1f; // �����ٶ�
    public float floatAmplitude = 0.5f; // ��������

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position; // ��¼��ʼλ��
    }

    void Update()
    {
        // �����µĸ���λ��
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        // Ӧ���µ�λ��
        transform.position = newPosition;
    }
}
