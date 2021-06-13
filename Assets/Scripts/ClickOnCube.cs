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
        if(GameObject.Find("GameControls").GetComponent<GameControl>().CubeClicked == false && GameObject.Find("Dice 1").GetComponent<CubeScript>().cubeStopedRoll == true)
        {
            GameObject.Find("GameControls").GetComponent<GameControl>().CubeClicked = true;
            if (GameObject.Find("Dice 1").GetComponent<CubeScript>().cubeStopedRoll == true)
            { EnterToArray();
                this.gameObject.SetActive(false);
            }
            
        }
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
        //move cube position
        SwapingCube();
        //updateDiceinGameControl
        //UpdateDiceInGameControl();

        //CubeScript.resetToAddImageToArray();
        //GetComponent<CubeScript>().resetToAddImageToArray();
    }

    void SwapingCube()
    {
        //GameObject CubeS = GetComponentInParent<CubeArrayPosition>().ArStepNums;
        for (int i = 0; i < GetComponentInParent<CubeArrayPosition>().ArStepNums.Count; i++)
        {
            if((GetComponentInParent<CubeArrayPosition>().ArStepNums[i].GetComponent<ClickOnCube>().inumberStep == 0) && i != (GetComponentInParent<CubeArrayPosition>().ArStepNums.Count - 1))//0->1
            {
                Vector3 tempPosition = GetComponentInParent<CubeArrayPosition>().ArStepNums[i].transform.position;
                GetComponentInParent<CubeArrayPosition>().ArStepNums[i].transform.position = GetComponentInParent<CubeArrayPosition>().ArStepNums[i+1].transform.position;
                GetComponentInParent<CubeArrayPosition>().ArStepNums[i+1].transform.position = tempPosition;

                GameObject T = GetComponentInParent<CubeArrayPosition>().ArStepNums[i];
                GetComponentInParent<CubeArrayPosition>().ArStepNums.RemoveAt(i);
                GetComponentInParent<CubeArrayPosition>().ArStepNums.Insert((i+1), T);
            }
        }
    }

    
    
}
