using System;
using System.Collections;
using System.Collections.Generic;
using GreenGremlins.Code;
using UnityEngine;
using UnityEngine.Events;

namespace GreenGremlins
{
    public class MainMenuController : MonoBehaviour
    {
        [SerializeField]
        private MainMenuView _view;
        [SerializeField] 
        private SettingsController _settings;

        public void Initialize()
        {
            _view.Show(new MainMenuModel
            {
                OnPlayPressed = PlayPressed,
                OnSettingsPressed = SettingsPressed,
                OnQuitPressed = QuitPressed
            });
        }
        
        public void ToggleMenu()
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void OnDisable()
        {
            _view.Hide();
        }
        
        private void PlayPressed()
        {
            Debug.Log("Play the game", this);
            ElSceneManeger.NextScene();
        }
        
        private void SettingsPressed()
        {
            ToggleMenu();
            _settings.ToggleMenu();
        }
        private void QuitPressed()
        {
            Debug.Log("Application Quit", this);
            Application.Quit();
        }
        
    }
}
