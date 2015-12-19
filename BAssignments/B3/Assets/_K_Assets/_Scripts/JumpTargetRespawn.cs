using UnityEngine;
using System.Collections;

public class JumpTargetRespawn : MonoBehaviour
{

    public static JumpTargetRespawn S;
    public GameObject kTarget;

    void Awake()
    {
        S = this;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void respawn(Vector3 pos, float respawnTime)
    {
        StartCoroutine(respawnWait(pos, respawnTime));
    }

    IEnumerator respawnWait(Vector3 pos, float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(kTarget, pos, Quaternion.identity);
    }

}
