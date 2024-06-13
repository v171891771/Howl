using UnityEngine;
using System.Collections; // 确保包含此命名空间

public class SwitchWorldAbilityTrigger : MonoBehaviour
{
    private bool playerInZone = false;
    private WorldSwitcher worldSwitcher;

    public AudioSource audioSource; // 声音组件
    public ParticleSystem particleSystem; // 粒子系统组件
    private bool abilityEnabled = false; // 能力是否已经启用

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            worldSwitcher = other.GetComponent<WorldSwitcher>();
            Debug.Log("Player entered the trigger zone.");
            if (worldSwitcher != null)
            {
                Debug.Log("WorldSwitcher component found on player.");
            }
            else
            {
                Debug.LogWarning("WorldSwitcher component not found on player.");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            worldSwitcher = null;
            Debug.Log("Player exited the trigger zone.");
        }
    }

    void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.E) && !abilityEnabled)
        {
            Debug.Log("E key pressed while player is in the trigger zone.");
            if (worldSwitcher != null)
            {
                StartCoroutine(EnableSwitchWorldAbilityWithEffect(worldSwitcher));
            }
            else
            {
                Debug.LogWarning("Cannot enable switch world ability. WorldSwitcher component is null.");
            }
        }
    }

    private IEnumerator EnableSwitchWorldAbilityWithEffect(WorldSwitcher cachedWorldSwitcher)
    {
        abilityEnabled = true;

        // 播放声音和粒子效果
        PlaySoundAndEffect();

        // 等待1秒
        yield return new WaitForSeconds(1f);

        // 检查 cachedWorldSwitcher 是否为空
        if (cachedWorldSwitcher != null)
        {
            // 切换到里世界
            cachedWorldSwitcher.SwitchWorld();
            Debug.Log("Switched to Inner World for effect.");
        }
        else
        {
            Debug.LogError("cachedWorldSwitcher is null when trying to switch to Inner World.");
            yield break;
        }

        // 等待2秒
        yield return new WaitForSeconds(2f);

        // 再次检查 cachedWorldSwitcher 是否为空
        if (cachedWorldSwitcher != null)
        {
            // 切换回表世界
            cachedWorldSwitcher.SwitchWorld();
            Debug.Log("Switched back to Surface World after effect.");
        }
        else
        {
            Debug.LogError("cachedWorldSwitcher is null when trying to switch back to Surface World.");
            yield break;
        }

        // 启用切换世界的能力
        if (cachedWorldSwitcher != null)
        {
            cachedWorldSwitcher.EnableSwitchWorldAbility();
            Debug.Log("Player has gained the ability to switch worlds.");
        }
        else
        {
            Debug.LogError("cachedWorldSwitcher is null when trying to enable switch world ability.");
        }
    }

    private void PlaySoundAndEffect()
    {
        if (audioSource != null)
        {
            audioSource.Play();
            Debug.Log("Playing sound effect.");
        }
        else
        {
            Debug.LogWarning("audioSource is null.");
        }

        if (particleSystem != null)
        {
            particleSystem.Play();
            Debug.Log("Playing particle effect.");
        }
        else
        {
            Debug.LogWarning("particleSystem is null.");
        }
    }
}
