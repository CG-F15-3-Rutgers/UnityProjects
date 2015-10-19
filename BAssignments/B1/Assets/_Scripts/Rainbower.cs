using UnityEngine;
using System.Collections;

public class Rainbower : MonoBehaviour
{

    Renderer rend;
    Color[] colors = new Color[6];
    public bool shine = true;


    void Awake()
    {
        rend = GetComponent<Renderer>();
        colors[0] = Color.cyan;
        colors[1] = Color.red;
        colors[2] = Color.green;
        colors[3] = new Color(255, 165, 0);
        colors[4] = Color.yellow;
        colors[5] = Color.magenta;
    }

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        StartCoroutine(waitColorChange());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void starcor()
    {
        StartCoroutine(waitColorChange());
    }

    public void stopcor()
    {
        StopCoroutine(waitColorChange());
    }


    private IEnumerator waitColorChange()
    {
            while (shine)
            {
                yield return new WaitForSeconds(0.005f);
                rend.materials[0].SetColor("_EmissionColor", colors[Random.Range(0, colors.Length)]);
            }
    }




}
