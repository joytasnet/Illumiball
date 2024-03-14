using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public string targetTag;
    bool isHolding;

    void OnTriggerStay(Collider other) {
        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();
        Vector3 direction = other.gameObject.transform.position - transform.position;
        direction.Normalize();
        if(other.CompareTag(targetTag)){
            r.velocity *= 0.9f;
            r.AddForce(direction * -20f,ForceMode.Acceleration);
        }else{
            r.AddForce(direction * 80f,ForceMode.Acceleration);
        }
    }

    public bool IsHolding(){
        return isHolding;
    }
    void OnTriggerEnter(Collider other) {
        if(other.CompareTag(targetTag)){
            isHolding=true;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.CompareTag(targetTag)){
            isHolding=false;
        }
    }
}
