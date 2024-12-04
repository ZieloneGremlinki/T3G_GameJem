using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GreenGremlins
{
    public class VialHitCheck : MonoBehaviour
    {
        [SerializeField]
        private GameObject hud;
        [SerializeField]
        private AnimationClip _breakAnim;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.tag == "Player"){
                Debug.Log("You hit the Vial!");
                var specimen = other.gameObject;    
                hud.GetComponent<GameHUDController>().Win();
                _animator.SetLayerWeight(1, 1f);
        }   
    }
    }
}
