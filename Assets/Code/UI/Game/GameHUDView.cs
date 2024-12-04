using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GreenGremlins
{
    public class GameHUDModel
    {
        public UnityAction<bool> OnGameEnd;
    }
    
    public class GameHUDView : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField]
        private GameObject _gameHUD;
        [SerializeField]
        private GameObject _winScreen;
        [SerializeField]
        private GameObject _loserBabyScreen;

        public void Show(GameHUDModel data)
        {
            data.OnGameEnd += state =>
            {
                ShowScreen(state ? 1 : 2, true);
            };
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
    }
}