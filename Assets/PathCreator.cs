using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour {

    [HideInInspector]
    public Path path;

    public Color anchorCol = Color.red;
    public Color controlCol = Color.white;
    public Color segmentCol = Color.green;
    public Color selectedSegmentCol = Color.yellow;
    public float anchorDiameter = .1f; //visual width of anchor points
    public float controlDiameter = .075f; //visual width of control points
    public bool displayControlPoints = true; 

    public void CreatePath()
    {
        path = new Path(transform.position);
    }

    void Reset() //called when script is reset
    {
        CreatePath();
    }
}
