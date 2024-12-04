using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanColliderCheck : MonoBehaviour
{
    enum Direction{
        Up,
        Down,
        Left,
        Right
    }
    [SerializeField] private Direction dir;
    float bounceForce = 0.400f;
void OnTriggerStay2D(Collider2D other) {
    if(other.gameObject.tag == "Player" || other.gameObject.tag == "Rubbish"){
        Debug.Log("Fan used! Direction: " + dir);
        var specimen = other.gameObject.GetComponent<Rigidbody2D>();
        switch(dir){
            case Direction.Up:
                specimen.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse); //💀💀💀💀
                break;
            case Direction.Down:
                specimen.AddForce(Vector2.down * bounceForce, ForceMode2D.Impulse); //💀💀💀
                break;

            case Direction.Left:
                specimen.AddForce(Vector2.left* bounceForce, ForceMode2D.Impulse); //💀💀
                break;

            case Direction.Right:
                specimen.AddForce(Vector2.right * bounceForce, ForceMode2D.Impulse); //💀
                break;
            default:
                return;
            }
        
        }
    }
}
