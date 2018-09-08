using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPlacer : MonoBehaviour {

    public float spacing = .1f;
    public float resolution = 1;
    public int pointDenominator = 0; //for naming nav points

    public List<GameObject> NavPoints;

    // Use this for initialization
    void Start()
    {
        Vector2[] points = FindObjectOfType<PathCreator>().path.CalculateEvenlySpacedPoints(spacing, resolution);
        foreach (Vector2 p in points)
        {
            GameObject g = new GameObject("NavPoint" + pointDenominator); //adds game objects at points
            g.transform.SetParent(this.gameObject.transform, true);
            //GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere); //for debug
            g.transform.position = p;
            g.transform.localScale = Vector3.one * spacing * .5f;
            NavPoints.Add(g); //adds navpoints to list
            pointDenominator++; //adds one to point denominator
        }
    }
}