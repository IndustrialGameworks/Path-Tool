﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : MonoBehaviour {

    public GameObject pathController;
    public Vector2[] navLocations;

    public int speed = 10;

    int currentNavDenominator = 0;

    bool initiated;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        Initiate(); //has to be run here, as the nav points dont exist yet on start!
        MoveToNav();
    }

    void Initiate()
    {
        int denominator = 0; //local denominator value

        if (initiated == false) //checks to see if has been initiated
        {

            var navList = GetComponentInParent<PathPlacer>().NavPoints; //grab the nav point location list out of path placer

            foreach (GameObject g in navList) //for each item in path placer increase the denominator, so you can get length of its generated list
            {
                denominator++;
            }

            navLocations = new Vector2[denominator]; //initiate the array of vectors that we will use to store the nav point locations

            denominator = 0; //reset denominator to 0 so we can iterate it through the list again

            foreach (GameObject g in navList) //for all the generated nav points in path placer, grab their vector, and assign it to the relevant array index
            {
                Vector2 location = g.transform.position;
                navLocations[denominator] = location;
                denominator++;
            }

            initiated = true; //set to true, so cannot be initiated again
        }
    }

    void MoveToNav()
    { 
        Vector2 currentLocation = transform.position;
        Vector2 targetLocation = navLocations[currentNavDenominator];

        if (currentLocation != targetLocation)
        {
            transform.position = (Vector2.MoveTowards(new Vector2(currentLocation.x, currentLocation.y), targetLocation, speed * Time.deltaTime));
        }

        else if (currentLocation == targetLocation)
        {
            currentNavDenominator++;
        }
    }
}