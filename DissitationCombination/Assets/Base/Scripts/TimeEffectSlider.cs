using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimeEffectSlider : MonoBehaviour {

    public int maxTime;
    public bool playing;
    public enum PLAYTYPE
    {
        NOT,
        LOOP,
        PINGPONG
    }
    public PLAYTYPE playType;
    private short vertVal;

	// Use this for initialization
	void Start ()
    {
        playing = false;
        vertVal = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (playing)
        {
            if (((GetComponent<Slider>().value += (0.01f* vertVal)) >= 1f)|| (GetComponent<Slider>().value += (0.01f * vertVal)) <= 0f)
            {
                switch (playType)
                {
                    case PLAYTYPE.LOOP:
                        GetComponent<Slider>().value = 0;
                        break;
                    case PLAYTYPE.PINGPONG:
                        if(vertVal == 1)
                        {
                            vertVal = -1;
                        }
                        else
                        {
                            vertVal = 1;
                        }
                        break;
                }

               
            }
        }

	
	}
}
