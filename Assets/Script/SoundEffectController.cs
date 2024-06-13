using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    public AudioSource audioSource; // 音频源
    public ParticleSystem particleSystem; // 粒子系统
    public KeyCode triggerKey = KeyCode.Space; // 触发键

    void Update()
    {
        // 检测按键输入
        if (Input.GetKeyDown(triggerKey))
        {
            PlaySoundEffect();
        }
    }

    void PlaySoundEffect()
    {
        // 播放音频
        if (audioSource != null)
        {
            audioSource.Play();
        }

        // 播放粒子效果
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}
