using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace GreenGremlins
{
    public class LoadingModel
    {
        
    }
    
    public class LoadingView : MonoBehaviour
    {
        [Header("Loading UI")]
        [SerializeField]
        private Slider _loadingSlider;

        /// <summary>
        /// Update slider & spin the spinner
        /// </summary>
        /// <param name="value"></param>
        public void UpdateProgress(float value)
        {
            _loadingSlider.value = value;
        }
    }
}
