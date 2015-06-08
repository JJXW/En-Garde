using UnityEngine;
using System.Collections;

public class FencerControllerScript : MonoBehaviour {


	public float maxSpeed = 20f; 
	bool facingRight = false;
	bool lunge = false;
	bool advance = false;

	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent <Animator> (); 

	}
	
	// Update is called once per frame
	void Update () 
	{
		Lunge ();
		Movement ();
	}

	void Movement()
	{
//		float move = Input.GetAxis ("Horizontal");
//		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		KeyCode lastKey = KeyCode.None;

		if (!this.anim.GetCurrentAnimatorStateInfo (0).IsName ("fencer_lunge")) {
			if (Input.GetKeyDown (KeyCode.LeftArrow)) {
				if (Input.GetKeyDown (KeyCode.LeftArrow) && lastKey != KeyCode.LeftArrow) {
					transform.Translate (Vector2.right * -maxSpeed * Time.deltaTime);
					advance = true;
				}
				lastKey = KeyCode.LeftArrow;
			} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
				if (Input.GetKeyDown (KeyCode.RightArrow) && lastKey != KeyCode.RightArrow) {
					transform.Translate (Vector2.right * maxSpeed * Time.deltaTime);
				}
				lastKey = KeyCode.RightArrow;
			} else {
				advance = false;
			}
		}

		anim.SetBool ("AdvanceButton", advance);
	}





	void Lunge()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			lunge = true;
		} else {
			lunge = false;
		}


		anim.SetBool ("LungeButton", lunge);


	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}