using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetardationModifiers : MonoBehaviour{   
    enum Property{ 
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

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void UpdateGuitardationValues(Property property,float value){
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
                HalfLife = value;
                break;
                
        }
    }
}
