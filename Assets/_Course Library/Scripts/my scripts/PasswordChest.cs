using UnityEngine;
using UnityEngine.UI; // UI使用のため

public class PasswordChest : MonoBehaviour
{
    [SerializeField] private string correctPassword = "1234"; // 正解パスワード
    [SerializeField] private InputField passwordInput;         // UI入力欄
    [SerializeField] private GameObject chestLid;              // フタのオブジェクト（開閉用）
    [SerializeField] private AudioSource openSound;            // 開ける音（任意）

    private bool isOpened = false;

    public void TryOpenChest()
    {
        if (isOpened) return;

        if (passwordInput.text == correctPassword)
        {
            Debug.Log("宝箱が開きました！");
            OpenChest();
        }
        else
        {
            Debug.Log("パスワードが間違っています。");
        }
    }

    void OpenChest()
    {
        isOpened = true;

        // フタを回転させて開く（例：x軸に60度回転）
        if (chestLid != null)
        {
            chestLid.transform.Rotate(Vector3.right * -60f);
        }

        // 開く音がある場合
        if (openSound != null)
        {
            openSound.Play();
        }
    }
}
