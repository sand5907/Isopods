using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public Text scoreText;
    public static int score = 0;

	void Start() 
	{
		UpdateScore ();
	}

	void UpdateScore() {
		scoreText.text = "You win!\nScore: " + score;
	}
}