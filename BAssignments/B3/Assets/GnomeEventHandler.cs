using UnityEngine;
using System.Collections;

public class GnomeEventHandler : MonoBehaviour {

    public static GnomeEventHandler S;
    public int numOfGnomesAlive = 12;

    GameObject gnomeCrystalText;

    public bool allGnomesDeadFlag = false;
    public bool allGnomesDeadFlagForcePush = true;

    void Awake()
    {
        S = this;
    }

	// Use this for initialization
	void Start () {
        gnomeCrystalText = transform.GetChild(0).gameObject;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (numOfGnomesAlive <= 0)
            allGnomesDeadFlag = true;

        if (allGnomesDeadFlag)
        {
            if(allGnomesDeadFlagForcePush)
            {
                gnomeCrystalText.GetComponent<Rigidbody>().AddForce(0, 10.0f, 0, ForceMode.Impulse);
                allGnomesDeadFlagForcePush = false;
                WaterCrystal.S.isGrabbable = true;
            }
        }

    }

}
