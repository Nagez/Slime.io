using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coll!");

        if(this.gameObject.GetComponent<keyMove>().PlayerPosition == collision.gameObject.GetComponent<keyMove>().PlayerPosition)

        //if (this.gameObject.GetComponentInParent<PlayerScript>().DiceMoves[0] == 0)//add function
        {
            Debug.Log(this.name + "collision With" + collision.gameObject.name);
            if ((this.gameObject.GetComponent<keyMove>().PlayerPosition == collision.gameObject.GetComponent<keyMove>().PlayerPosition))
            {
                if (collision.gameObject.name == this.name)
                {
                    Debug.Log("Upgrade!");
                }
                else
                {
                    Debug.Log("Del " + collision.gameObject.name);
                }
            }
        }
       
    }
}
