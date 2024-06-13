using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    public AudioSource audioSource; // ��ƵԴ
    public ParticleSystem particleSystem; // ����ϵͳ
    public KeyCode triggerKey = KeyCode.Space; // ������

    void Update()
    {
        // ��ⰴ������
        if (Input.GetKeyDown(triggerKey))
        {
            PlaySoundEffect();
        }
    }

    void PlaySoundEffect()
    {
        // ������Ƶ
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // ��������Ч��
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}
