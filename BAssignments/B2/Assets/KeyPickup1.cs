using UnityEngine;
using System.Collections;

public class KeyPickup1 : MonoBehaviour
{
    public static KeyPickup1 S;
    public bool wasPickedUp = false;
    public GameObject toFollow;

    void Awake()
    {
        S = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (wasPickedUp)
        {
            transform.position = toFollow.transform.position + (Vector3.up * 2.75f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "gDaniel")
        {
            toFollow = other.gameObject;
            wasPickedUp = true;
        }
    }

}
