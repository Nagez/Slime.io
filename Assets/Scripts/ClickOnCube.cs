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
        inumberStep = 0;
        this.GetComponent<SpriteRenderer>().sprite = null;
    }
}
