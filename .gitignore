using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay;
	
	private Ball ball;
	private Vector3 paddlePos;
	private Vector3 ballPos;
	
	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
		
		if (autoPlay){
			RandomStart();
		}
	}
	
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
		}
		else {
			AutoPlay();
		}
	}
	
	void MoveWithMouse (){
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos = new Vector3 (8f, 0.5f, 0f);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1f, 15f);
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		float ballPosOnX = ball.transform.position.x;
		paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		paddlePos.x = Mathf.Clamp(ballPosOnX, 1f, 15f);
		this.transform.position = paddlePos;
	}
	
	void RandomStart(){
		ballPos.y = ball.transform.position.y;
		paddlePos.y = this.transform.position.y;
		float ballToPaddleVectorOnY =  ballPos.y - paddlePos.y;
		
		paddlePos = new Vector3 (Random.Range(1f, 15f), 0.5f, 0f);
		this.transform.position = paddlePos;
		ball.transform.position = paddlePos + new Vector3 (0f, ballToPaddleVectorOnY, 0f);
		
		Ball.hasGameStarted = true;
		ball.rigidbody2D.velocity = new Vector2 (2f, 10f);
	}
}
