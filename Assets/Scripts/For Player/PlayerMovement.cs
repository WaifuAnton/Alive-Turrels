using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 6;
    public int health = 10;
    float curHealth;
    CharacterController character;
	// Use this for initialization
	void Start () {
        character = GetComponent<CharacterController>();
        curHealth = health;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveX *= speed;
        moveZ *= speed;
        Vector3 movement = new Vector3(moveX, 0, moveZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        character.Move(movement);
	}

    public void ChangeHealth(int value)
    {
        curHealth += value;
        if (curHealth > health)
            curHealth = health;
        if (curHealth <= 0)
        {
            curHealth = 0;
            transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 90);
        }
    }
}
