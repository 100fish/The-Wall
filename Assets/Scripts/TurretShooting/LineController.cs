using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    //GRIFFIN CODE

    public LineRenderer lr; //the linerendere component
    private Transform[] points = { null, null }; //matrix of points
    

    private void Awake()
    {
        lr = GetComponent<LineRenderer>(); //grabs component
    }

    public void SetUpLine(Transform[] points) //takes an array of points and passes it to the linerendere component
    {
        lr.positionCount = points.Length; //sets the amount of line positions to the amount of values in the array
        this.points = points;// sets the points variable in THIS script to the incoming points
    }

    private void Update()
    {
        //Debug.Log(points.Length);
        //if (points[0] != null || points[1] != null)
        //{
        //    for (int i = 0; i < points.Length; i++) //for every point in the line
        //    {
        //        lr.SetPosition(i, points[i].position); //set the position of each index in the line renderer to the poisiton of each point in the array
        //    }   
        //}


    }
}
