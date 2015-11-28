using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject[] enemys;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	private int score;
	// Use this for initialization
	void Awake()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
	}
	void Start () 
	{
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++) 
			{
				GameObject enemy = enemys[Random.Range(0,enemys.Length)];
				Vector3 spawnPosition = new Vector3 (spawnValues.x, Random.Range (-3.9f, 9.0f), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (enemy, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds(waveWait);

			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
}
