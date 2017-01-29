using UnityEngine;
using System.Collections;

public class ControlObject : MonoBehaviour {

    protected int m_currentGlobalState;
    public StateObject.GAMESTATE m_myState;
    GameObject controler;


    public void Start()
    {
        findControl();
        initalSet();
      
    }

    public void setState(StateObject.GAMESTATE _inState)
    {
        m_myState = _inState;
    }

    public void findControl()
    {
        controler = GameObject.Find("GameControler");
    }

    public void updateState()
    {

        if(controler == null)
        {
            findControl();
        }
        
        if(m_myState == controler.GetComponent<StateObject>().gameState)
        {
            setAlive(true);
        }
        else
        {
            setAlive(false);
        }
    }
    




    public void setAlive(bool _in)
    {
        gameObject.SetActive(_in);
    }
    public void initalSet()
    {
        setAlive(true);
    }


}
