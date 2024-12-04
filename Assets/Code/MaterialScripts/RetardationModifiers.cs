using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetardationModifiers : MonoBehaviour{   
    public enum Property{ 
        Gravity,
        Material,
        Mass,
        Friction,
        AirResistance,
        Bounciness,
        HalfLife
    }
    /*
        Gravity 
        Materiał 
        Masa
        Tarcie 
        Opór powietrza 
        Bounceiness 
        Czas połowicznego rozpadu 
    */
        [SerializeField] private CircleCollider2D coll;
        private Rigidbody2D rb;
        private float HalfLife;
        private float T,mass;
        private bool check = true;
        private bool start_halflife = false;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        SetState(false);
    }
    public void UpdateGuitardationValues(Property property,float value){
        PhysicsMaterial2D newMaterial = new PhysicsMaterial2D("Bruhh");
        switch(property){
            case Property.Gravity:
                rb.gravityScale = value;
                break;
            case Property.Mass:
                rb.mass = value;
                break;
            case Property.Friction:
                newMaterial.friction = value;
                coll.sharedMaterial = newMaterial;
                break;
            case Property.AirResistance:
                rb.drag = value;
                break;
            case Property.Bounciness:
                newMaterial.bounciness = value;
                coll.sharedMaterial = newMaterial;
                break;
            case Property.HalfLife:
                if (HalfLife != 0)
                    start_halflife = true;
                    HalfLife = value;
                break;
                
        }
        
    }

    public void SetState(bool state)
    {
        rb.bodyType = state ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
    }
    
    void Update(){
        if(start_halflife)
            CalculateHalfLifeMass(HalfLife);
    }
    void CalculateHalfLifeMass(float HalfLife){
        if(check){
           mass = rb.mass;
           check = false;
        }
        T += 1f * Time.deltaTime;
        Debug.Log(rb.mass);
        rb.mass = mass * (float)System.Math.Round((Mathf.Pow(0.5f,((float)T/(float)HalfLife))),2);
    }
}
