using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGameText : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(alphaFX());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Application.LoadLevel(1);
    }

    IEnumerator alphaFX()
    {
        while (true)
        {
            this.GetComponent<Text>().CrossFadeAlpha(0.0f, 0.5f, true);
            yield return new WaitForSeconds(0.5f);
            this.GetComponent<Text>().CrossFadeAlpha(1.0f, 0.5f, true);
            yield return new WaitForSeconds(0.5f);
        }
    }

}
