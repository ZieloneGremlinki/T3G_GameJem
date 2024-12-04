using UnityEngine.SceneManagement;

namespace GreenGremlins.Code
{
    public static class ElSceneManeger
    {
        public static void NextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        public static void PrevScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}