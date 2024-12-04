using System;
using System.Collections;
using UnityEngine.SceneManagement;

namespace GreenGremlins.Code
{
    public static class ElSceneManeger
    {
        public static int SceneToLoad = -1;
        
        public enum SceneIdx : int
        {
            Menu = -1,
            Loader = -2
        }
        
        public static void NextScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        public static void PrevScene()
        {
            LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public static int ParseScene(int scene)
        {
            if (scene == (int)SceneIdx.Menu) return 0;
            if (scene == (int)SceneIdx.Loader) return 1;
            if (scene >= 1 && scene <= Variables.MAX_LEVELS) return scene + 1;
            return 0; // Fallback to menu
        }
        
        /// <summary>
        /// Load Scene (loads "Loader" scene and that scene handles the load
        /// </summary>
        /// <param name="scene">Scene Index</param>
        /// <returns></returns>
        public static void LoadScene(int scene)
        {
            SceneToLoad = scene;
            SceneManager.LoadScene(ParseScene((int)SceneIdx.Loader));
        }
    }
}