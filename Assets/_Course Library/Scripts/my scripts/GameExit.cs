using UnityEngine;

public class GameExit : MonoBehaviour
{
    // ボタンから呼び出す用
    public void QuitGame()
    {
        Debug.Log("ゲーム終了");
        Application.Quit();

#if UNITY_EDITOR
        // エディタ上では止まらないので、強制停止
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
