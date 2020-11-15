using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    private float speed = 0.01f;
    
    public Transform target;
    
    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    void FixedUpdate() {
        var targetposition = target.position;
        targetposition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, targetposition, speed);
    }
}
