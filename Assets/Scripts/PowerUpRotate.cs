using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotate : MonoBehaviour {

    public float Speed = 80f;

    void Update()
    {
        transform.Rotate(Vector3.up, Speed * Time.deltaTime);
    }
}
