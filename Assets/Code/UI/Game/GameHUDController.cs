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
        
        public void Initialize()
        {
            GameHUDModel model = new GameHUDModel
            {
                OnToggleHUD = ToggleHUD,
                OnRespawnBall = RespawnBall,
                OnMenuBack = BackToMenu,
                OnNextLevel = NextLevel,
                OnReplayLevel = ReplayLevel
            };
            _view.Show(model);
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
            if (_view.FirstTime)
            {
                RetardationModifiers plr = GameObject.FindWithTag("Player").GetComponent<RetardationModifiers>();
                if (plr == null)
                {
                    Debug.LogError("Player not found");
                    return;
                }
                
                plr.SetState(true);
                _view.FirstTime = false;
            }
            else
            {
                ReplayLevel();
            }
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
            ElSceneManeger.LoadScene(Variables.CurrentLevel);
        }
    }
}