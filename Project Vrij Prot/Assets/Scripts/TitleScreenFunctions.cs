using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Menu/Title")]
public class TitleScreenFunctions : ScriptableObject
{
    public static void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void QuitApplication()
    {
        Application.Quit();
    }
}