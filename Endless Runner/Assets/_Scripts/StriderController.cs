using UnityEngine;
using System.Collections;

public class StriderController : MonoBehaviour 
{
	Animator anim;

	//Jump Variables
	bool grounded = false;

	float groundRadius = 0.2f;
	public Transform groundCheck;
	public Rigidbody2D rb;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	private bool doubleJumped;
	
	//SwordSlash Variables
	public GameObject swordSlashPrefab = null;
	public Transform leftSpawner = null;
	public Transform rightSpawner = null;
	
	public float slashRate;
	public float nextSlash;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (grounded)
			doubleJumped = false;
		if (Input.GetKeyDown (KeyCode.Space) && grounded) 
		{
			anim.SetBool ("Ground", false);
			Jump();
		}
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) 
		{
			Jump();
			doubleJumped = true;
		}

		/*if (Input.GetKeyDown (KeyCode.S)) 
		{
			gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
		}*/
		if (Input.GetKeyDown(KeyCode.A) && Time.time >= nextSlash) 
		{
			anim.SetTrigger ("AttackLeftGround");
			nextSlash = Time.time + slashRate;
			Instantiate (swordSlashPrefab, leftSpawner.position, leftSpawner.rotation);
		}
		if (Input.GetKeyDown(KeyCode.D) && Time.time >= nextSlash) 
		{
			nextSlash = Time.time + slashRate;
			Instantiate (swordSlashPrefab, rightSpawner.position, rightSpawner.rotation);
		}

	}
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rb.velocity.y);
	}
	public void Jump()
	{
		rb.velocity = new Vector2 (0, jumpForce);
	}
}
