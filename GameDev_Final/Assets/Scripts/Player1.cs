﻿ using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {
	
	Rigidbody rb;

	public GameObject opponet;
	
	public Bullet bullet;
	public float maxHealth;
	public float currentHealth;
	public float walkSpeed;

	public int score = 0;
	public bool dead = false;
	public bool gotItem = false;

	private Bullet[] spread;
	private Vector3 s;

	public Player1WeaponControl weapCtrl;


	bool grounded = false;
	
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody>();
	
	}

	// Update is called once per frame
	void Update () {
		//if the player's health is zero, deactivate the player
		if (currentHealth <= 0)
		{
			dead = true;
			gameObject.SetActive(false);
		}

		if (gameObject.tag == "Player1") {
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.S))
			{
				FixedUpdate();
			}
			if (Input.GetKey (KeyCode.A))
			{
				transform.RotateAround(transform.position, transform.up, -1.5f);
				//transform.position -= transform.right * 8 * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.D))
			{
				transform.RotateAround(transform.position, transform.up, 1.5f);
				//transform.position += transform.right * 8 * Time.deltaTime;
			}
		}

		if(Input.GetKeyDown(KeyCode.C)){ //&& weapCtrl.hasGun){
			Shoot();

			//Spread();
		}

		//if (Input.GetKeyDown (KeyCode.C) && weapCtrl.hasSword) {
		//	Swing();
		//}
	}

	void OnCollisionEnter(Collision col)
	{
		//decrease the health if the collider's tag tells us it's an 'enemy'. We set the tag in the inspector underneath the object name.
		if (col.collider.tag == "Enemy")
		{
			currentHealth -= 0.5f;
		}
		
	}
	void OnCollisionStay(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			grounded = true;
		}
		if (col.collider.tag == "Enemy")
		{
			currentHealth -= 0.5f;
		}
	}
	
	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "Ground")
		{
			grounded = false;
		}
	}
	

	void FixedUpdate()
	{
//		float moveHorizontal = Input.GetAxis ("Horizontal");
//		float moveVertical = Input.GetAxis ("Vertical");
//
//		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//		rb.velocity = movement * walkSpeed;
//
//		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x);

		if (Input.GetKey(KeyCode.W))
		{
			rb.AddForce(transform.forward * walkSpeed, ForceMode.Acceleration);
			//transform.position += transform.forward * walkSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			rb.AddForce(-transform.forward * walkSpeed, ForceMode.Acceleration);
			//transform.position -= transform.forward * walkSpeed * Time.deltaTime;
		}
	}

	void Shoot(){
		//Instantiate a bullet and set it to a newBullet

		Bullet newBullet =  (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet.direction = transform.forward;

		//if (weapCtrl.hasGun) {
//			Bullet newBullet = (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
//			newBullet.direction = transform.forward;
		//}
		

	}
	//void Swing(){
	//	if (weapCtrl.currentWeapon == 0) {
	//		weapCtrl.sword.transform.RotateAround(
	//
	//	}
	//}

	void Spread () {
		//Instantiate a bullet and set it to a newBullet
		Bullet newBullet1 =  (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet1.direction = transform.forward;
		Bullet newBullet2 =  (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet2.direction = new Vector3 (-.2f, 0f, .2f);
		Bullet newBullet3 =  (Bullet)Instantiate (bullet, transform.position + transform.forward, Quaternion.identity);
		newBullet3.direction = new Vector3 (.2f, 0f, .2f);
	}
}
