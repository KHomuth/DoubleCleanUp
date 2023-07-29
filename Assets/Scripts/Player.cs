using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Player : MonoBehaviour {
	private bool movingLeft;
	private bool movingRight;
	private bool movingUp;
	private bool movingDown;
	private bool movingUpLeft;
	private bool movingUpRight;
	private bool movingDownLeft;
	private bool movingDownRight;
	private bool specialAbility;
	private bool ability;
	private bool attack;

	private bool isDashing;
	private bool isAttacking;
	private bool canDash = true;
	private bool canAttack = true;

	private float currentNextFire;
	private float dashPower = 15f;
	private float dashingTime = .3f;
	private float dashingCooldown = 1f;
	private float attackTime = .5f;
	private float attackCooldown = .5f;
	public float playerSpeed = 0.1f;
	public float currentFireRate;

	[SerializeField] private Rigidbody2D rigidBody;
	[SerializeField] private TrailRenderer tr;
	[SerializeField] private ProjectileBehaviour projectile;
	[SerializeField] private Transform launchOffset;

	private void Start (){
		rigidBody = GetComponent<Rigidbody2D> ();
	}

	public void ButtonInput (JToken input){

		if(input["dpad"] != null){
			if((string)input["dpad"]["directionchange"]["key"] == "right" && (bool)input["dpad"]["directionchange"]["pressed"] == true){
				movingRight = true;
			} else if((string)input["dpad"]["directionchange"]["key"] == "right" && (bool)input["dpad"]["directionchange"]["pressed"] == false) {
				movingRight = false;
			} else if((string)input["dpad"]["directionchange"]["key"] == "left" && (bool)input["dpad"]["directionchange"]["pressed"] == true) {
				movingLeft = true;
			} else if((string)input["dpad"]["directionchange"]["key"] == "left" && (bool)input["dpad"]["directionchange"]["pressed"] == false) {
				movingLeft = false;
			} else if((string)input["dpad"]["directionchange"]["key"] == "up" && (bool)input["dpad"]["directionchange"]["pressed"] == true) {
				movingUp = true;
			} else if((string)input["dpad"]["directionchange"]["key"] == "up" && (bool)input["dpad"]["directionchange"]["pressed"] == false) {
				movingUp = false;
			} else if((string)input["dpad"]["directionchange"]["key"] == "down" && (bool)input["dpad"]["directionchange"]["pressed"] == true) {
				movingDown = true;
			} else if((string)input["dpad"]["directionchange"]["key"] == "down" && (bool)input["dpad"]["directionchange"]["pressed"] == false) {
				movingDown = false;
			} else if((string)input["dpad"]["directionchange"]["key"] == "up" && (bool)input["dpad"]["directionchange"]["pressed"] == true && (string)input["dpad"]["directionchange"]["key"] == "left" && (bool)input["dpad"]["directionchange"]["pressed"] == true) {
				movingUpLeft = true;
			} else if((string)input["dpad"]["directionchange"]["key"] == "up" && (bool)input["dpad"]["directionchange"]["pressed"] == false && (string)input["dpad"]["directionchange"]["key"] == "left" && (bool)input["dpad"]["directionchange"]["pressed"] == false) {
				movingUpLeft = false;
			}
		}

		if(input["a"] != null) {
			if((string)input["a"] == "down"){
				ability = true;
			} else if((string)input["a"] == "up") {
				ability = false;
			}
		}

		if(input["b"] != null) {
			if((string)input["b"] == "down"){
				specialAbility = true;
			} else if((string)input["b"] == "up") {
				specialAbility = false;
			}
		}

		if(input["c"] != null) {
			if((string)input["c"] == "down"){
				attack = true;
			} else if((string)input["c"] == "up") {
				attack = false;
			}
		}
	}


	private void Update(){
		if(isDashing){
			return;
		}

		if(specialAbility && canDash) {
			if(movingLeft && !movingRight) {
				StartCoroutine(Dash(-1, 0));
			} else if (!movingLeft && movingRight) {
				StartCoroutine(Dash(1, 0));
			} else if (!movingDown && movingUp) {
				StartCoroutine(Dash(0, 1));
			} else if (movingDown && !movingUp) {
				StartCoroutine(Dash(0, -1));
			} 
		}

		if(attack && Time.time > currentNextFire){
			currentNextFire = Time.time + currentFireRate;
			Instantiate(projectile, launchOffset.position, transform.rotation);
		}
	}

	private void FixedUpdate(){
		if(isDashing){
			return;
		}

		if(movingLeft && !movingRight) {
			rigidBody.velocity = new Vector2(-1 * playerSpeed, 0 * playerSpeed);
			transform.rotation = Quaternion.Euler(0, 0, 90);
		} else if (!movingLeft && movingRight) {
			rigidBody.velocity = new Vector2(1 * playerSpeed, 0 * playerSpeed);
			transform.rotation = Quaternion.Euler(0, 0, -90);
		} else if (!movingDown && movingUp) {
			rigidBody.velocity = new Vector2(0 * playerSpeed, 1 * playerSpeed);
			transform.rotation = Quaternion.Euler(0, 0, 0);
		} else if (movingDown && !movingUp) {
			rigidBody.velocity = new Vector2(0 * playerSpeed, -1 * playerSpeed);
			transform.rotation = Quaternion.Euler(0, 0, 180);
		} else if (movingUpLeft){
			rigidBody.velocity = new Vector2(-1 * playerSpeed, 1 * playerSpeed);
		} else {
			rigidBody.velocity = new Vector2(0, 0);
		}
	}

	private IEnumerator Dash(int xVel, int yVel){
		canDash = false;
		isDashing = true;
		float originalGravity = rigidBody.gravityScale;
		rigidBody.gravityScale = 0f;
		rigidBody.velocity = new Vector2(xVel * dashPower, yVel * dashPower);
		tr.emitting = true;
		yield return new WaitForSeconds(dashingTime);
		tr.emitting = false;
		rigidBody.gravityScale = originalGravity;
		isDashing = false;
		yield return new WaitForSeconds(dashingCooldown);
		canDash = true;
	}
}