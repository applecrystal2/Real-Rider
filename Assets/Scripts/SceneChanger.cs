using UnityEngine;
using UnityEngine.SceneManagement; // �� ��ȯ�� ���� �ʿ�

public class SceneChanger : MonoBehaviour
{
    // Play ��ư���� ȣ���� �޼���
    public void ChangeToMainScene()
    {
        SceneManager.LoadScene("Main");
    }

}
