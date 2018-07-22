using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrelTarget : MonoBehaviour {
    public float health = 5;
    float curHealth;
	// Use this for initialization
	void Start () {
        curHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeHealth(int value)
    {
        curHealth += value;
        if (curHealth > health)
            curHealth = health;
        if (curHealth <= 0)
        {
            curHealth = 0;
            //transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 90);
            Destroy(gameObject);
        }
    }
}
