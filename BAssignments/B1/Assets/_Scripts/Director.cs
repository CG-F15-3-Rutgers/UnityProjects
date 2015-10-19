using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour
{
    public Transform target1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         RaycastHit hit;
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                target1.transform.position = hit.point;
            
        }

    }

}
