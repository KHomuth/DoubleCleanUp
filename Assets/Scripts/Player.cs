using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Player : MonoBehaviour {

	private Rigidbody2D rigidBody;

	bool movingLeft;
	bool movingRight;
	bool movingUp;
	bool movingDown;

	public float playerSpeed = 0.1f;

	private void Start (){
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	public void ButtonInput (JToken input){
        if((string)input["key"] == "right" && (bool)input["pressed"] == true){
            movingRight = true;
        } else if((string)input["key"] == "right" && (bool)input["pressed"] == false) {
            movingRight = false;
        } else if((string)input["key"] == "left" && (bool)input["pressed"] == true) {
            movingLeft = true;
        } else if((string)input["key"] == "left" && (bool)input["pressed"] == false) {
            movingLeft = false;
        } else if((string)input["key"] == "up" && (bool)input["pressed"] == true) {
            movingUp = true;
        } else if((string)input["key"] == "up" && (bool)input["pressed"] == false) {
            movingUp = false;
        } else if((string)input["key"] == "down" && (bool)input["pressed"] == true) {
            movingDown = true;
        } else if((string)input["key"] == "down" && (bool)input["pressed"] == false) {
            movingDown = false;
        }
	}

	private void FixedUpdate(){
		if(movingLeft && !movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (-playerSpeed, 0)); 
		} else if (!movingLeft && movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (playerSpeed, 0)); 
		} else if (!movingDown && movingUp) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (0, playerSpeed)); 
		} else if (movingDown && !movingUp) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (0, -playerSpeed)); 
		} else if (movingDown && movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (-playerSpeed, -playerSpeed)); 
		} else if (movingDown && movingLeft) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (playerSpeed, -playerSpeed)); 
		} else if (movingUp && movingRight) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (-playerSpeed, playerSpeed)); 
		} else if (movingUp && movingLeft) {
			rigidBody.MovePosition(rigidBody.position + new Vector2 (playerSpeed, playerSpeed)); 
		}
	}
}