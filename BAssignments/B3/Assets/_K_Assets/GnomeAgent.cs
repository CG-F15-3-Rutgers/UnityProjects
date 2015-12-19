using UnityEngine;
using System.Collections;

public class GnomeAgent : MonoBehaviour
{
    Renderer rend;
    Color[] colors = new Color[6];
    public Transform goal;
    NavMeshAgent agent;

    public int health = 4;
    public bool dead = false;
    public bool activated = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
        if (goal.transform.position.z > 112.0f)
            activated = true;

        if (activated)
        {

            if (health > 0)
            {
                agent.destination = goal.position;
            }

            if (health <= 0)
            {
                if (!dead)
                {
                    GnomeEventHandler.S.numOfGnomesAlive--;
                    this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    this.gameObject.AddComponent<Rigidbody>();
                    this.gameObject.AddComponent<BoxCollider>();
                    this.GetComponent<Rigidbody>().AddForce(0, 12.0f, 0, ForceMode.Impulse);
                    this.GetComponent<Rigidbody>().AddRelativeTorque(10, 20, -1, ForceMode.Impulse);
                    this.GetComponent<ParticleSystem>().Play();
                    //Destroy(gameObject, 6.0f);
                    dead = true;
                }
            }
        }
    }

    IEnumerator waitColorChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            rend.materials[3].SetColor("_EmissionColor", colors[Random.Range(0, colors.Length)]);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "kBullet")
        {
            health--;
        }
    }

}
