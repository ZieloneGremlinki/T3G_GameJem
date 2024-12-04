using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GreenGremlins
{
    public class GameHUDModel
    {
        public UnityAction<bool> OnGameEnd;
        public UnityAction OnToggleHUD;
        public UnityAction OnRespawnBall;
    }
    
    public class GameHUDView : MonoBehaviour
    {
        [Header("UI Elements")]
        [Header("GameHUD")]
        [SerializeField]
        private GameObject _gameHUD;
        [SerializeField]
        private RectTransform _gameHUDTransform;
        [SerializeField]
        private Button _gameHUDToggle;
        [SerializeField]
        private TMP_Text _gameHUDToggleText;
        [SerializeField]
        private Button _gameHUDRespawn;
        [Header("Win Screen")]
        [SerializeField]
        private GameObject _winScreen;
        [Header("Looser Screen")]
        [SerializeField]
        private GameObject _loserBabyScreen;

        private bool _gameHUDActive = false;

        public bool GameHUDActive
        {
            get { return _gameHUDActive; }
            set
            {
                _gameHUDToggleText.text = value ? "HIDE" : "SHOW";
                _gameHUDActive = value;
            }
        }

        public void Show(GameHUDModel data)
        {
            data.OnGameEnd += state =>
            {
                ShowScreen(state ? 1 : 2, true);
            };
            
            _gameHUDToggle.onClick.AddListener(data.OnToggleHUD);
            _gameHUDRespawn.onClick.AddListener(data.OnRespawnBall);
        }

        public void Hide()
        {
            _gameHUDToggle.onClick.RemoveAllListeners();
            _gameHUDRespawn.onClick.RemoveAllListeners();
        }

        // <summary>
        /// Show desired screen (hiding all others)
        /// </summary>
        /// <param name="scr">Screen index (0 - HUD, 1 - Win Screen, 2 - Loser Screen)</param>
        /// <param name="show"></param>
        private void ToggleScreen(int scr, bool show)
        {
            switch (scr)
            {
                case 0:
                    _gameHUD.SetActive(show);
                    break;
                case 1:
                    _winScreen.SetActive(show);
                    break;
                case 2:
                    _loserBabyScreen.SetActive(show);
                    break;
            }
        }
        
        /// <summary>
        /// Show desired screen
        /// </summary>
        /// <param name="scr">Screen index (0 - HUD, 1 - Win Screen, 2 - Loser Screen)</param>
        /// <param name="hide">Whether to hide remaining screens</param>
        private void ShowScreen(int scr, bool hide)
        {
            switch (scr)
            {
                default:
                case 0:
                    ToggleScreen(scr, true);
                    ToggleScreen(1, false);
                    ToggleScreen(2, false);
                    break;
                case 1:
                    ToggleScreen(scr, true);
                    ToggleScreen(0, false);
                    ToggleScreen(2, false);
                    break;
                case 2:
                    ToggleScreen(scr, true);
                    ToggleScreen(0, false);
                    ToggleScreen(1, false);
                    break;
            }
        }
        
        /// <summary>
        /// Hide desired screen
        /// </summary>
        /// <param name="scr">Screen index (0 - HUD, 1 - Win Screen, 2 - Loser Screen)</param>
        private void HideScreen(int scr)
        {
            ToggleScreen(scr, false);
        }

        private void Update()
        {
            if (_gameHUDActive)
            {
                //-750 controls movement off screen
                if (_gameHUDTransform.position.y != 0)
                {
                    _gameHUDTransform.position = Vector3.Lerp(_gameHUDTransform.position, new Vector3(_gameHUDTransform.position.x, 0, _gameHUDTransform.position.z), 15f * Time.deltaTime);
                }
            }
            else
            {
                if (_gameHUDTransform.position.y != -750)
                {
                    _gameHUDTransform.position = Vector3.Lerp(_gameHUDTransform.position, new Vector3(_gameHUDTransform.position.x, -750, _gameHUDTransform.position.z), 15f * Time.deltaTime);
                }
            }
        }
    }
}