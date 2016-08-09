using UnityEngine;
using System.Collections;

public class FloorBehaviour : MonoBehaviour
{
    public Transform[] cameraPositions;
    public RaycastHit hit;
    public float smooth;
    private int idPos;


	void Start () 
    {
	
	}
	
    //void Update ()
    //{
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        if (idPos < 3)
    //        {
    //            idPos++;
    //        }
    //    }

    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        if (idPos > 0)
    //        {
    //            idPos--;
    //        }
    //    }

    //    //if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
    //    transform.rotation = Quaternion.Lerp(transform.rotation, cameraPositions[idPos].rotation, smooth * Time.deltaTime);
    //}

	void OnMouseDown() 
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);		
		//Physics.Raycast (ray, out hit);
	}
}
