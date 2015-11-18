using UnityEngine;
using System.Collections;

public class StriderController : MonoBehaviour 
{
	Animator anim;

	//Slide
	public CircleCollider2D circC;
	
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

	//Health Variables
	public float striderHealth = 3.0f;
	public GameObject[] healthCubes;
	public bool playerHurt = false;
	public bool playerDead = false;

	void Awake()
	{
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		circC = GetComponent<CircleCollider2D> ();
	}
	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (grounded) 
		{
			doubleJumped = false;
		}
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

		if (Input.GetKeyDown (KeyCode.S) && grounded) 
		{
			StartCoroutine("sliding");
		}
		if (Input.GetKeyDown(KeyCode.A) && Time.time >= nextSlash) 
		{
			nextSlash = Time.time + slashRate;
			Instantiate (swordSlashPrefab, leftSpawner.position, leftSpawner.rotation);
		}
		if (Input.GetKeyDown(KeyCode.D) && Time.time >= nextSlash) 
		{
			nextSlash = Time.time + slashRate;
			Instantiate (swordSlashPrefab, rightSpawner.position, rightSpawner.rotation);
		}
	}
	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			StartCoroutine("hurt");
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
		anim.SetBool ("Slide", false);
		circC.enabled = true;
	}
	IEnumerator sliding()
	{
		anim.SetBool ("Slide", true);
		circC.enabled = false;
		yield return new WaitForSeconds(1.0f);
		anim.SetBool ("Slide", false);
		circC.enabled = true;
	}
	IEnumerator hurt()
	{
		anim.SetBool ("Hurt", true);
		striderHealth--;
		if (striderHealth <= 0)
		{
			Destroy (gameObject);
		}
		yield return new WaitForSeconds (1.0f);
		anim.SetBool ("Hurt", false);

	}


}
