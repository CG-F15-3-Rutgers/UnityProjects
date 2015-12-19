using UnityEngine;
using System.Collections;

public class DangerFire : MonoBehaviour {

    ParticleSystem ps;
    public ParticleSystem ps2;
    //public GameObject bDanMouthFire;

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
            //Application.LoadLevel(1);
            print("blue entered the fire");
            other.transform.GetChild(0).GetComponent<ParticleSystem>().enableEmission = true;
            ps2.enableEmission = true;
        }

        if ((other.gameObject.tag == "gDaniel") && KeyPickup1.S.wasPickedUp)
        {
            StartCoroutine(waitAndPutOutFire());
        }
    }

    IEnumerator waitAndPutOutFire()
    {
        yield return new WaitForSeconds(1.0f);
        ps.enableEmission = false;
        this.GetComponent<Collider>().enabled = false;
    }

}
