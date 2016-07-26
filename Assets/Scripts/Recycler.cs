using UnityEngine;
using System.Collections;

public class Recycler : MonoBehaviour
{

    public Transform startPoint; //Set startPoint on our objects
    public Transform endPoint;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < endPoint.position.x)  //If the position of the piece of grass (grass prefab. The transform.position is the position of the grass prefab) is < end points position (i.e. it has moved past endPoint maker)
        {
            float gap = endPoint.position.x - transform.position.x; //Calculate the difference between where the end point is and where the transform (grass piece) has moved to. 

            transform.position = new Vector3(startPoint.position.x - gap, transform.position.y, transform.position.z); //Then reset the grasses position to be the x position of the start point (minus the gap amount this closes up the gap between the grass finishing after end point),  and its original y and its original z 
        }


    }
}
