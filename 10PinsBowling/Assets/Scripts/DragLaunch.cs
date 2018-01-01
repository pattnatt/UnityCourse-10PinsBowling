﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {
    private Vector3 dragStart;
    private Vector3 dragEnd;
    private float startTime;
    private float endTime;
    private Ball ball;

	// Use this for initialization
	void Start(){
        ball = GetComponent<Ball>();
    }
	
	public void DrafStart(){
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd(){
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDutation = endTime - startTime;

        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDutation;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDutation; // Not a mistake !!

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
        ball.Launch(launchVelocity);
    }
}