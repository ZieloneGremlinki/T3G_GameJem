using System;
using GreenGremlins.Code;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GreenGremlins
{
public class GameHUDController : MonoBehaviour
    {
        [SerializeField]
        private GameHUDView _view;
        private GameHUDModel _data;
        
        public void Initialize()
        {
            _data = new GameHUDModel
            {
                OnToggleHUD = ToggleHUD,
                OnRespawnBall = RespawnBall,
                OnMenuBack = BackToMenu,
                OnNextLevel = NextLevel,
                OnReplayLevel = ReplayLevel
            };
            _view.Show(_data);
        }

        public void Win()
        {
          _data.OnGameEnd?.Invoke(true);
        }

        public void Lose()
        {
          _data.OnGameEnd?.Invoke(false);
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void ToggleHUD()
        {
            _view.GameHUDActive = !_view.GameHUDActive;
        }

        private void RespawnBall()
        {
            // TODO: Make ball logic
        }

        private void BackToMenu()
        {
            ElSceneManeger.LoadScene((int)ElSceneManeger.SceneIdx.Menu);
        }
        
        private void NextLevel()
        {
            ElSceneManeger.NextScene();
        }

        private void ReplayLevel()
        {
            ElSceneManeger.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}