using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
    public float speedX = 7;
    public float speedY = 7;
    public float minAngle = -45;
    public float maxAngle = 45;
    public enum rotationAxis { axisX, axisY };
    public rotationAxis axis;
    float rotation = 0;
    float rotY;
	// Use this for initialization
	void Start () {
        rotY = transform.localRotation.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float rotationX = Input.GetAxis("Mouse Y") * speedX;
        float rotationY = Input.GetAxis("Mouse X") * speedY;
		switch (axis)
        {
            case rotationAxis.axisY:
                transform.Rotate(0, rotationY, 0);
                break;
            case rotationAxis.axisX:
                rotation -= rotationX;
                rotation = Mathf.Clamp(rotation, minAngle, maxAngle);
                transform.localRotation = Quaternion.Euler(rotation, rotY, 0);
                break;
        }
	}
}
