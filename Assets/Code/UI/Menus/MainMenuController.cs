using System;
using System.Collections;
using System.Collections.Generic;
using GreenGremlins.Code;
using UnityEngine;

namespace GreenGremlins
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private MainMenuView _view;

        public void Initialize()
        {
            _view.Show(new MainMenuModel
            {
                OnPlayPressed = PlayPressed,
                OnSettingsPressed = SettingsPressed,
                OnQuitPressed = QuitPressed
            });
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void PlayPressed()
        {
            Debug.Log("Play the game", this);
            ElSceneManeger.LoadScene(1);
        }
        
        private void SettingsPressed()
        {
            Debug.Log("TODO: Open settings", this);
        }
        private void QuitPressed()
        {
            Debug.Log("Application Quit", this);
        }
        
    }
}
