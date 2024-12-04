using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanColliderCheck : MonoBehaviour
{
    float bounceForce = 50f;
void OnTriggerStay2D(Collider2D other) {
    if(other.gameObject.tag == "Player"){
        Debug.Log("JumpForce Added");
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * bounceForce, ForceMode2D.Impulse); //💀💀💀💀
    }
}
}
