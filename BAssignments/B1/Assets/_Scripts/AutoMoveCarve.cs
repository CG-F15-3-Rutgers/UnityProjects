using UnityEngine;
using System.Collections;

public class AutoMoveCarve : MonoBehaviour
{

    public GameObject wp;
    public Vector3 op;

    bool movetowp = false;
    bool movetoop = false;

    // Use this for initialization
    void Start()
    {
        op = transform.position;
        StartCoroutine(automove());
    }

    // Update is called once per frame
    void Update()
    {
        float step = 10.0f * Time.deltaTime;

        if (movetowp)
            transform.position = Vector3.MoveTowards(transform.position, wp.transform.position, step);

        if (movetoop)
            transform.position = Vector3.MoveTowards(transform.position, op, step);

    }

    IEnumerator automove()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.0f);
            movetowp = true;
            movetoop = false;
            yield return new WaitForSeconds(3.0f);
            movetowp = false;
            movetoop = true;
        }
    }

}
