using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	public float maxSpeed = 5, maxSprintFactor = 2, maxSprintTime = .5f;
	public Vector3 moveVector;
	public bool canSprint = true;
	private float curSprintFactor, curSprintTime;

	// Use this for initialization
	void Start () {
		curSprintFactor = 1;
	}
	
	// Update is called once per frame
	void Update () {
		trackSprint ();
		vectorMove ();
	}

	private void trackSprint(){
		if (Input.GetAxis ("Sprint") > 0) {
			if(canSprint == true){
				curSprintFactor = maxSprintFactor * Input.GetAxis ("Sprint");
				if (curSprintFactor < 1) {
					curSprintFactor = 1;
				}
			}else{
				curSprintFactor = 1;
			}
			curSprintTime -= Time.deltaTime;
			if(curSprintTime < 0){
				canSprint = false;
				curSprintTime = 0;
			}
		} else {
			curSprintFactor = 1;
			curSprintTime += Time.deltaTime;
			if(curSprintTime > maxSprintTime){
				canSprint = true;
				curSprintTime = maxSprintTime;
			}
		}
		/*
		if (maxSprintTime > 0 && canSprint == true) {
			curSprintFactor = maxSprintFactor * Input.GetAxis ("Sprint");
			if (curSprintFactor < 1) {
				curSprintFactor = 1;
			}
			curSprintTime -= Time.deltaTime;
		} else {
			curSprintFactor = 1;
			curSprintTime += Time.deltaTime;
		}

		if (curSprintTime > maxSprintTime) {
			curSprintTime = maxSprintTime;
			canSprint = true;
		}
		if (curSprintTime < 0) {
			curSprintTime = 0;
			canSprint = false;
		}
		*/
	}

	private void vectorMove(){
		moveVector.x = maxSpeed * curSprintFactor * Input.GetAxis("HorizontalWalk") * Time.deltaTime;
		moveVector.y = maxSpeed * curSprintFactor * Input.GetAxis("VerticalWalk") * Time.deltaTime;
		transform.position += moveVector;
	}
}
