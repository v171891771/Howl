using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // ��Ҷ���
    public Transform[] triggerPositions; // ����λ������
    public Transform[] cameraTargetPositions; // �����Ŀ��λ������
    public float moveSpeed = 2f; // ������ƶ��ٶ�
    public float rotateSpeed = 2f; // �������ת�ٶ�
    public float triggerDistance = 1f; // ����������ƶ��ľ���

    private Vector3 offset; // ����������ҵ�ƫ����
    private int currentTriggerIndex = -1; // ��ǰ����λ������
    private bool isMovingToTarget = false; // ������Ƿ����ƶ���Ŀ��λ��

    void Start()
    {
        // ��¼��ʼ�����λ��
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (isMovingToTarget)
        {
            // �ƶ��������Ŀ��λ��
            Transform targetPosition = cameraTargetPositions[currentTriggerIndex];
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetPosition.rotation, rotateSpeed * Time.deltaTime);

            // ���������Ƿ񵽴�Ŀ��λ��
            if (Vector3.Distance(transform.position, targetPosition.position) < 0.1f && Quaternion.Angle(transform.rotation, targetPosition.rotation) < 1f)
            {
                isMovingToTarget = false;
                // ���� offset Ϊ�µ����λ��
                offset = transform.position - player.position;
                Debug.Log("Camera reached target position. New offset: " + offset);
            }
        }
        else
        {
            // ����׷�����
            Vector3 desiredPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, moveSpeed * Time.deltaTime);
        }

        // �������Ƿ񵽴ﴥ��λ��
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
