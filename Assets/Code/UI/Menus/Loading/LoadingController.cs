using System;
using System.Collections;
using System.Collections.Generic;
using GreenGremlins.Code;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GreenGremlins
{
    public class LoadingController : MonoBehaviour
    {
        [SerializeField]
        private LoadingView _view;

        public void Initialize()
        {
        }

        private void Start()
        {
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            AsyncOperation load = SceneManager.LoadSceneAsync(ElSceneManeger.ParseScene(ElSceneManeger.SceneToLoad));

            while (!load.isDone)
            {
                float progress = Mathf.Clamp01(load.progress / 0.9f);
                _view.UpdateProgress(progress);
                yield return null;
            }
        }
    }
}
