using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NavObstacleMove : MonoBehaviour
{

    public bool iHaveBeenClicked = false;
    public Rainbower rab;

    // Use this for initialization
    void Start()
    {
        rab = this.GetComponent<Rainbower>();
    }

    public void OnMouseDown()
    {
        iHaveBeenClicked = !iHaveBeenClicked; // For simple toggline everytime they click.
        if (iHaveBeenClicked)
            InfoTextSing.s.GetComponent<Text>().text = "You selected: " + gameObject.name;
        
        if (!iHaveBeenClicked)
            InfoTextSing.s.GetComponent<Text>().text = "You unselected: " + gameObject.name;
 
    }

    // Update is called once per frame
    void Update()
    {
        if(iHaveBeenClicked)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                transform.Translate(0, 0, 0.45f);

             if (Input.GetKeyDown(KeyCode.DownArrow))
                transform.Translate(0, 0, -0.45f);

            if (Input.GetKeyDown(KeyCode.RightArrow))
                transform.Translate(0.45f, 0, 0);

             if (Input.GetKeyDown(KeyCode.LeftArrow))
                transform.Translate(-0.45f, 0, 0);
        }
    }

}
