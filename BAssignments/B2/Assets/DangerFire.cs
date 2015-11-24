using UnityEngine;
using System.Collections;

public class DangerFire : MonoBehaviour {

    ParticleSystem ps;

    void Awake()
    {
        ps = this.GetComponent<ParticleSystem>();
    }

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bDaniel")
        {
            //other.gameObject.SetActive(false);
            Application.LoadLevel(1);
        }

        if (other.gameObject.tag == "gDaniel" && KeyPickup1.S.wasPickedUp)
        {
            ps.IsAlive(false);
            this.GetComponent<Collider>().enabled = false;
        }
    }

}
