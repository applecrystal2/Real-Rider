using UnityEngine;

public class Coin : MonoBehaviour
{
    private ParticleSystem particleSystem;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ���� ���� ������Ʈ�� �ִ� Particle System, Audio Source ������Ʈ ��������
        particleSystem = GetComponent<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    // Ʈ���ſ� ������ ��ƼŬ �ý��۰� ����� �ҽ� ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        particleSystem.Play();
        audioSource.Play();

        Destroy(gameObject, 0.5f);
    }
}
