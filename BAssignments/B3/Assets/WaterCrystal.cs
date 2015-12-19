using UnityEngine;
using System.Collections;

public class WaterCrystal : MonoBehaviour {

    public static WaterCrystal S;

    public bool isGrabbable = false;
    public bool Grabbed = false;

    public GameObject bd;
    public GameObject bdPS1;
    public GameObject bdPS2;

    public bool savedBD = false;

    public float distToBD;

    void Awake()
    {
        S = this;
    }
	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown()
    {
        if (isGrabbable)
            Grabbed = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (Grabbed)
            transform.position = Camera.main.transform.GetChild(1).transform.position;

        distToBD = Vector3.Distance(transform.position, bd.transform.position);

        if (distToBD < 10.0f)
        {
            bdPS1.GetComponent<ParticleSystem>().Stop();
            bdPS2.GetComponent<ParticleSystem>().Stop();
            savedBD = true;
        }
	
	}
}
