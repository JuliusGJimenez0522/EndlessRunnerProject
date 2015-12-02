using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public int scoreValue;
	private GameManager gameManager;
	// Use this for initialization
	void Start () 
	{
		GameObject gameManagerObject = GameObject.FindWithTag("GameController");
		if (gameManagerObject != null) 
		{
			gameManager = gameManagerObject.GetComponent<GameManager>();
		}
		if (gameManager == null)
		{
			Debug.Log ("Cannot find GameManager Script");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}
		print (gameObject.name);
		gameManager.AddScore (scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
