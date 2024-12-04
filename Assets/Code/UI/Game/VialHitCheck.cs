using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GreenGremlins
{
    public class VialHitCheck : MonoBehaviour
    {
        public GameObject hud;
        void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.tag == "Player"){
                Debug.Log("You hit the Vial!");
                var specimen = other.gameObject;    
                hud.GetComponent<GameHUDController>().Win();
                //tutaj kod do animacji vial
        }   
    }
    }
}
