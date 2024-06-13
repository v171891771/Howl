using UnityEngine;
using System.Collections; // ȷ�������������ռ�

public class SwitchWorldAbilityTrigger : MonoBehaviour
{
    private bool playerInZone = false;
    private WorldSwitcher worldSwitcher;

    public AudioSource audioSource; // �������
    public ParticleSystem particleSystem; // ����ϵͳ���
    private bool abilityEnabled = false; // �����Ƿ��Ѿ�����

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

        // ��������������Ч��
        PlaySoundAndEffect();

        // �ȴ�1��
        yield return new WaitForSeconds(1f);

        // ��� cachedWorldSwitcher �Ƿ�Ϊ��
        if (cachedWorldSwitcher != null)
        {
            // �л���������
            cachedWorldSwitcher.SwitchWorld();
            Debug.Log("Switched to Inner World for effect.");
        }
        else
        {
            Debug.LogError("cachedWorldSwitcher is null when trying to switch to Inner World.");
            yield break;
        }

        // �ȴ�2��
        yield return new WaitForSeconds(2f);

        // �ٴμ�� cachedWorldSwitcher �Ƿ�Ϊ��
        if (cachedWorldSwitcher != null)
        {
            // �л��ر�����
            cachedWorldSwitcher.SwitchWorld();
            Debug.Log("Switched back to Surface World after effect.");
        }
        else
        {
            Debug.LogError("cachedWorldSwitcher is null when trying to switch back to Surface World.");
            yield break;
        }

        // �����л����������
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
