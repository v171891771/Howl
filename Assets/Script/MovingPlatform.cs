using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward; // �ƶ�����Ĭ��Ϊ��ǰ
    public float moveDistance = 10f; // �ƶ����룬Ĭ��Ϊ10��λ
    public float moveSpeed = 1f; // �ƶ��ٶȣ�Ĭ��Ϊ1��λ/��
    public bool resetAfterMove = true; // �ƶ����յ���Ƿ�λ

    private Vector3 initialPosition; // ���ӵĳ�ʼλ��
    private Vector3 targetPosition; // ���ӵ�Ŀ��λ��
    private bool isMoving = false; // �����Ƿ����ƶ�

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
                transform.position = initialPosition; // ���õ���ʼλ���Ա�����һ���ƶ�
            }
            isMoving = false;
        }
    }
}
