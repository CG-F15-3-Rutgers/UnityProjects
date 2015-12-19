using UnityEngine;
using System.Collections;

public class CarverMoveInteraction : MonoBehaviour {

    public float speed = 0.30f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x >= -6.83f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Translate(-speed, 0, 0);
        }
            if (transform.position.x <= 9.55f)
            {
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Translate(speed, 0, 0);
           
            }
    }
}
