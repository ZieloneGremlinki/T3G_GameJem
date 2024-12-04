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
        private Transform _sprite;

        private void Awake()
        {
            _sprite = transform;
        }

        void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.tag == "Player"){
                Debug.Log("Cat ate you!");
                var specimen = other.gameObject;    
                StartCoroutine(Eaten());
                
        }
        IEnumerator Eaten()
        {
            int counter = 0;
            while (counter < 10000)
            {
                _sprite.Rotate(Vector3.forward, Random.Range(0f, 360f));
                counter++;
            }
            yield return new WaitForSeconds(5);
            ElSceneManeger.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
        
    }
}
