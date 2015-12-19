using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlueDanielTimer : MonoBehaviour
{
    public static BlueDanielTimer S;

    Text thisText;
    public float timerVal = 100.0f;
    public float timerDisplay;

    void Awake()
    {
        S = this;
        thisText = this.GetComponent<Text>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!WaterCrystal.S.savedBD)
        {

            timerVal -= Time.deltaTime;

            timerDisplay = timerVal;

            if (timerVal > 0.0f)
                thisText.text = "TIME UNTIL BLUE DANIEL DIES: " + Mathf.Round(timerDisplay);

            if (timerVal <= 0.0f)
            {
                thisText.text = "GAME OVER BLUE DANIEL DIED";
            }
        }
        else
        {
            thisText.text = "YOU WIN!!! YOU SAVED BLUE DANIEL";
        }
    }

}
