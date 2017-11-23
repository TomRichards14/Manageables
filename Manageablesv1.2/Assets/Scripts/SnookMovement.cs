using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnookMovement : MonoBehaviour {

    public int DirectionOfTravel;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.W))
        {
            DirectionOfTravel = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            DirectionOfTravel = 2;
        }

        if (Input.GetKey(KeyCode.A))
        {
            DirectionOfTravel = 3;
        }

        if (Input.GetKey(KeyCode.D))
        {
            DirectionOfTravel = 4;
        }

        switch (DirectionOfTravel)
        {
            case 1:
                if (transform.position.y < 6.4f)
                    transform.Translate(Vector3.up * Time.deltaTime);
                break;
            case 2:
                if (transform.position.y > -4.4f)
                    transform.Translate(Vector3.down * Time.deltaTime);
                break;
            case 3:
                if (transform.position.x > -3.0f)
                    transform.Translate(Vector3.left * Time.deltaTime);
                break;
            case 4:
                if (transform.position.x < 3.0f)
                    transform.Translate(Vector3.right * Time.deltaTime);
                break;
        }
	}
}
