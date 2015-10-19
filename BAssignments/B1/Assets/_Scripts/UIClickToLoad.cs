using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIClickToLoad : MonoBehaviour
{

    public string str;
    public int levelIndexToLoad;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RunOnPointerEnter()
    {
        this.GetComponent<Text>().CrossFadeAlpha(0.5f, 0.5f, true);
    }

    public void RunOnPointerExit()
    {
        this.GetComponent<Text>().CrossFadeAlpha(1.0f, 0.25f, true);
    }

    public void RunOnPointerDown()
    {
        Application.LoadLevel(levelIndexToLoad);
        print(str);
    }
}
