using System;
using System.Collections;
using System.Collections.Generic;
using GreenGremlins.Code;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GreenGremlins
{
    public class CatHandler : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        void OnTriggerStay2D(Collider2D other) {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log("Cat ate you!");
                RetardationModifiers obj = other.gameObject.GetComponent<RetardationModifiers>();
                StartCoroutine(Eaten(obj));
            }
        }
        IEnumerator Eaten(RetardationModifiers obj)
        {
            _animator.SetBool(Animator.StringToHash("eating"), true);
            obj.SetState(false);
            obj.SetInvis(true);
            yield return new WaitForSeconds(5);
            ElSceneManeger.LoadScene(Variables.CurrentLevel);
        }
    }
}
