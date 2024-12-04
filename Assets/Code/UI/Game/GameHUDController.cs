using System;
using UnityEngine;

namespace GreenGremlins
{
    public class GameHUDController : MonoBehaviour
    {
        [SerializeField]
        private GameHUDView _view;
        
        public void Initialize()
        {
            _view.Show(new GameHUDModel
            {
                OnGameEnd = GameEnd,
                OnToggleHUD = ToggleHUD,
                OnRespawnBall = RespawnBall
            });
        }

        private void OnEnable()
        {
            Initialize();
        }

        private void GameEnd(bool state)
        {
        }

        private void ToggleHUD()
        {
            _view.GameHUDActive = !_view.GameHUDActive;
        }

        private void RespawnBall()
        {
        }
    }
}