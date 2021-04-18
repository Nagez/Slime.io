using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject SlimePrefab;
    public GameObject position0;

    //spawn a slimeprefab on position 0 location when clicking
    private void OnMouseDown()
    {
        // this object was clicked 
        Instantiate(SlimePrefab, position0.transform.position, position0.transform.rotation);
        Debug.Log("spawned2");        
    }
    //does nothing
    private void OnMouseEnter()
    {
        Debug.Log("hover");

    }
}
