using UnityEngine;

namespace GreenGremlins
{
    public class GameHUDController : MonoBehaviour
    {
        [SerializeField]]
        private GameHUDView _view;
        
        public void Initialize()
        {
            _view.Show(new GameHUDModel
            {
                OnGameEnd = GameEnd
            });
        }

        public void GameEnd(bool state)
        {
        }
    }
}