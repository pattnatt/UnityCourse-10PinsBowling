﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {
    public bool isDebug = true;
    private Vector3 dragStart;
    private Vector3 dragEnd;
    private float startTime;
    private float endTime;
    private Ball ball;

	// Use this for initialization
	void Start(){
        ball = GetComponent<Ball>();
    }
	

    public void MoveStart(float amount) {
        if(!ball.inPlay) {
            ball.transform.Translate(new Vector3(amount, 0, 0));
        }
    }

	public void DrafStart(){
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd(){
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDutation = endTime - startTime;
        if(dragDutation > 0f) {
            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDutation;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDutation; // Not a mistake !!

            if(launchSpeedX != 0 || launchSpeedZ != 0) {
                Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
                if (isDebug || !ball.inPlay) {
                    ball.Launch(launchVelocity);
                }
            }
        } 
    }
}
