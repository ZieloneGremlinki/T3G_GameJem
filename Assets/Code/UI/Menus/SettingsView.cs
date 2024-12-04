using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GreenGremlins
{
    public class SettingsModel
    {
        public UnityAction<int> OnTabPressed;
        public UnityAction<int> OnToggleTab;
        public UnityAction OnBackPressed;
    }
    public class SettingsView : MonoBehaviour
    {
        [SerializeField]
        private Button[] _tabButtons;
        [SerializeField]
        private GameObject[] _tabs;
        [SerializeField]
        private Button _back;
        
        private int _currentTab = 0;
        
        public void Show(SettingsModel data)
        {
            _back.onClick.AddListener(data.OnBackPressed);
            for (int i = 0; i < _tabButtons.Length; i++)
            {
                int idx = i;
                _tabButtons[idx].onClick.AddListener(() =>
                {
                    data.OnTabPressed.Invoke(idx);
                });
            }

            data.OnToggleTab += idx =>
            {
                for (int i = 0; i < _tabs.Length; i++)
                {
                    _tabs[i].SetActive(false);
                }

                _tabs[idx].SetActive(true);
                _currentTab = idx;
            };
            
            _tabs[_currentTab].SetActive(true);
        }
        
        public void Hide()
        {
            _back.onClick.RemoveAllListeners();
            for (int i = 0; i < _tabButtons.Length; i++)
            {
                _tabButtons[i].onClick.RemoveAllListeners();
            }

            for (int i = 0; i < _tabs.Length; i++)
            {
                _tabs[i].SetActive(false);
            }
        }
    }
}
