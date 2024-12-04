using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GreenGremlins
{
    public class LoseCollider : MonoBehaviour
    {
        public GameObject hud;
        void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.tag == "Player"){
                Debug.Log("You got skill issue!");
                var specimen = other.gameObject;    
                hud.GetComponent<GameHUDController>().Lose();
                //this.GetComponent<Animator>().SetBool
        }
    }
    }
}
