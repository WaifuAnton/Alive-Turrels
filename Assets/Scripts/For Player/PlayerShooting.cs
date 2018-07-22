using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public int damage = 2;
    Camera playerCamera;
	// Use this for initialization
	void Start () {
        playerCamera = transform.GetChild(0).GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(playerCamera.pixelWidth / 2, playerCamera.pixelHeight / 2);
            Ray ray = playerCamera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                TurrelTarget turrel = hit.transform.GetComponent<TurrelTarget>();
                if (turrel != null)
                {
                    turrel.ChangeHealth(-damage);
                    Debug.Log(true);
                }
            }
        }
	}

    void OnGUI() { 
        GUI.Label(new Rect(playerCamera.pixelWidth / 2 - 3, playerCamera.pixelHeight / 2 - 8, 100, 100), "+");
    }
}
