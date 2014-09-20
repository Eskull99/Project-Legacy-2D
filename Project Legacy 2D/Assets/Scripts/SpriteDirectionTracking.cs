using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SpriteDirectionTracking : MonoBehaviour {

	public List<Texture2D> upMap, downMap, leftMap, rightMap;
	private List<Texture2D> vertMap, horMap, finalMap;

	public float distanceX, distanceY;
	public int activeSprite = 0;
	public Vector3 lastPosition, curPosition;

	public Animator anim;

	void Start(){
		anim = GetComponent <Animator>();
	}

	// Update is called once per frame
	void Update () {
		FindDirectionTraveled ();
		DetermineMap ();
		SendToAnimator ();
	}

	private void SendToAnimator(){
		anim.SetFloat ("distanceX", distanceX);
		anim.SetFloat ("distanceY", distanceY);
	}

	private void FindDirectionTraveled(){
		curPosition = transform.position;
		distanceX = curPosition.x - lastPosition.x;
		distanceY = curPosition.y - lastPosition.y;
		lastPosition = transform.position;
	}

	private void DetermineMap(){
		if (distanceX > 0) {
			horMap = rightMap;
		}
		if (distanceX < 0) {
			horMap = leftMap;
		}
		if (distanceY > 0) {
			vertMap = upMap;
		}
		if (distanceY < 0) {
			vertMap = downMap;
		}

		if (Math.Abs (distanceY) > Math.Abs (distanceX)) {
			finalMap = vertMap;
		}
		if (Math.Abs (distanceY) < Math.Abs (distanceX)) {
			finalMap = horMap;
		}
	}
}
