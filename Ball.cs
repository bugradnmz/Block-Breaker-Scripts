using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public static bool hasGameStarted = false;
	
	private Paddle paddle;
	private float actualVelocity;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasGameStarted){
			//Lock the ball relative to paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			//Wait for mouse click to launch.
			if (Input.GetMouseButtonDown(0)){
				print ("Left mouse button clicked and ball launched");
				hasGameStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f, 10f);
			}
		}
		else {
			BallSpeedGuard();
		} 
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if(hasGameStarted){
			audio.Play();
			Tweak();
		} 
	}
	
	void Tweak(){
		Vector2 tweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range (-0.2f, 0.2f));
		rigidbody2D.velocity += tweak;
	}
	
	void BallSpeedGuard (){
		//Topun hızını bul.
		actualVelocity = Mathf.Sqrt(Mathf.Pow(rigidbody2D.velocity.x, 2) + Mathf.Pow(rigidbody2D.velocity.y, 2));
		//Top hızlı ise yavaşlat.
		if (actualVelocity > 10){
			Vector2 decreaseVelocity = rigidbody2D.velocity;
			
			//Top negatif yönde gidiyorsa pozitif yönde, pozitif yönde gidiyorsa negatif yönde hız ekle ki yavaşlasın.
			decreaseVelocity.x += (-0.01f * Mathf.Sign(decreaseVelocity.x));
			decreaseVelocity.y += (-0.01f * Mathf.Sign(decreaseVelocity.y));
			rigidbody2D.velocity = decreaseVelocity;
		}
		//Top yavaş ise hızlandır.
		else if (actualVelocity < 9.9){			
			Vector2 decreaseVelocity = rigidbody2D.velocity;
			
			//Top negatif yönde gidiyorsa negatif yönde, pozitif yönde gidiyorsa pozitif yönde hız ekle ki hızlansın.
			decreaseVelocity.x += (0.01f * Mathf.Sign(decreaseVelocity.x));
			decreaseVelocity.y += (0.01f * Mathf.Sign(decreaseVelocity.y));
			rigidbody2D.velocity = decreaseVelocity;
		}
	}
}
