using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GreenGremlins
{
    public class CatHandler : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D other) {
            if(other.gameObject.tag == "Player"){
                Debug.Log("Cat ate you!");
                var specimen = other.gameObject;    
                StartCoroutine(Eaten());
                
        }
        IEnumerator Eaten(){
            yield return new WaitForSeconds(5);
            Application.LoadLevel(Application.loadedLevel);
        }
    }
        
    }
}
