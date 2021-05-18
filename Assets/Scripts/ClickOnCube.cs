using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCube : MonoBehaviour
{
    public int inumberStep = 0;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        EnterToArray();
    }

    //function to check array place
    private void EnterToArray()
    {
      for(int i=0;i< GetComponentInParent<CubeArrayPosition>().ArStepNums.Count; i++)
        if(this.name == GetComponentInParent<CubeArrayPosition>().ArStepNums[i].name)
            {
                GameObject.Find("GameControls").GetComponent<GameControl>().DicePICKEDArr = i;
            }

        GameObject.Find("GameControls").GetComponent<GameControl>().DicePICKED = inumberStep;
        inumberStep = 0;
        this.GetComponent<SpriteRenderer>().sprite = null;
        //CubeScript.resetToAddImageToArray();
        //GetComponent<CubeScript>().resetToAddImageToArray();
    }
}
