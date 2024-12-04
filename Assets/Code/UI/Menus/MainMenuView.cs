using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GreenGremlins
{
    public class MainMenuModel
    {
        public UnityAction OnPlayPressed;
        public UnityAction OnSettingsPressed;
        public UnityAction OnQuitPressed;
    }
    
    public class MainMenuView : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField]
        private Button _playButton;
        [SerializeField]
        private Button _settingsButton;
        [SerializeField]
        private Button _quitButton;

        public void Show(MainMenuModel data)
        {
            _playButton.onClick.AddListener(data.OnPlayPressed);
            _settingsButton.onClick.AddListener(data.OnSettingsPressed);
            _quitButton.onClick.AddListener(data.OnQuitPressed);
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            _playButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _quitButton.onClick.RemoveAllListeners();
        }
    }
}
