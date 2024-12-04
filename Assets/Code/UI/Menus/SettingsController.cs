using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace GreenGremlins
{
    public class SettingsController : MonoBehaviour
    {
        [SerializeField]
        private SettingsView _view;
        [SerializeField] 
        private MainMenuController _menu;
        [SerializeField]
        private LabeledRangeThing[] _musicSliders;
        [SerializeField]
        private AudioMixer _mixer;
        
        private SettingsModel _data;
        
        public void Initialize()
        {
            _data = new SettingsModel
            {
                OnTabPressed = OnTabPressed,
                OnBackPressed = OnBackPressed
            };

            for (int i = 0; i < _musicSliders.Length; i++)
            {
                int idx = i;
                _musicSliders[idx].OnValueChanged += val =>
                {
                    if (idx == 0)
                    {
                        _mixer.SetFloat("master_vol", val);
                    }

                    if (idx == 1)
                    {
                        _mixer.SetFloat("music_vol", val);
                    }

                    if (idx == 2)
                    {
                        _mixer.SetFloat("sfx_vol", val);
                    }
                };
            }
            
            _view.Show(_data);
        }

        public void SaveSettings()
        {
            float mastervol, musicvol, sfxvol;
            _mixer.GetFloat("master_vol", out mastervol);
            _mixer.GetFloat("music_vol", out musicvol);
            _mixer.GetFloat("sfx_vol", out sfxvol);
            
            PlayerPrefs.SetFloat("master_vol", mastervol);
            PlayerPrefs.SetFloat("music_vol", musicvol);
            PlayerPrefs.SetFloat("sfx_vol", sfxvol);
            PlayerPrefs.Save();
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
        
        private void OnTabPressed(int tab)
        {
            _data.OnToggleTab.Invoke(tab);
        }

        private void OnBackPressed()
        {
            _menu.ToggleMenu();
            ToggleMenu();
        }
    }
}
