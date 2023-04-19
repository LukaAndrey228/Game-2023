using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MovingObject {

	public int wallDamage = 1;
	public int pointsPerFood = 10;
	public int pointsPerSoda = 20;
	public float restartLevelDelay = 1f;
	public Text foodText;

	public int horizontal = 0;
	public int vertical = 0;

	private Animator animator;
	private int food;
	private QuestionList questList = new QuestionList();

	public int damageStep = 10;
	public GameObject currentPacket = null;
	public Question currentQuestion = null;
	public int selectedToggle = -1;


	protected override void Start()
    {
		animator = GetComponent<Animator>();

		food = GameManager.instance.playerFoodPoints;

		foodText.text = "Food:" + food;

		base.Start();
    }
	
	private void OnDisable()
    {
		GameManager.instance.playerFoodPoints = food;
		questList.clearHistory();
	}


	void Update ()
	{
		if (!GameManager.instance.playersTurn) return;

		//horizontal = (int) Input.GetAxisRaw("Horizontal");
		//vertical = (int) Input.GetAxisRaw("Vertical");
		if (horizontal != 0)
			vertical = 0;

		if (horizontal != 0 || vertical != 0)
			AttemptMove<Wall>(horizontal, vertical);
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
    {
		food-= damageStep;
		foodText.text = "Food:" + food;
		foodText.text = "Food:" + food;
		base.AttemptMove <T> (xDir, yDir);

		RaycastHit2D hit;
		CheckIfGameOver();
		GameManager.instance.playersTurn = false;
		horizontal = 0;
		vertical = 0;
	}


	private void OnTriggerEnter2D (Collider2D other)
    {
		if (other.tag == "Exit")
        {
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			Invoke("Restart", restartLevelDelay);
			enabled = false;
        }
		else if (other.tag == "Food")
        {
			food+= pointsPerFood;
			foodText.text = "+" +pointsPerFood + "Food:" + food;
			other.gameObject.SetActive(false);
        }
		else if (other.tag == "Soda")
         {
			food += pointsPerSoda;
			foodText.text = "+" + pointsPerSoda + "Food:" + food;
			other.gameObject.SetActive(false);
         }
		
    }

	protected override void OnCantMove <T> (T component)
    {
		Wall hitWall = component as Wall;
		Debug.Log(hitWall);
		//hitWall.DamageWall(wallDamage);
		//animator.SetTrigger("playerChop");

    }
	
	private void Restart()
    {
		
		Application.LoadLevel(Application.loadedLevel);
	}

	public void LoseFood(int loss)
    {
		animator.SetTrigger("playerHit");
		food -= loss;
		foodText.text = "-" + loss + "Food" + food;
		CheckIfGameOver();
    }
	public void WinFood(int win)
	{
		food += win;
		foodText.text = "+" + win + "Food " + food;
	}
	private void CheckIfGameOver()
    {
		if (food <= 0)
			GameManager.instance.GameOver();
    }

	public void generateQuestion()
    {
		currentQuestion = questList.getRandomQuestion();

		string descr = currentQuestion.desc;

		Text objDesc = GameObject.Find("Text (1)").GetComponent<Text>();
		objDesc.text = descr;
        for (int i = 0; i < currentQuestion.answers.Length; i++)
        {
			Text objAnsw = GameObject.Find("Ответ_"+i+"_Label").GetComponent<Text>();

			GameObject.Find("Ответ_" + i).GetComponent<Toggle>().isOn = false;
			objAnsw.text = currentQuestion.answers[i];
		}

	}


	public GameObject findNearObject(string search, double radius)
	{
		GameObject PlayerObj = GameObject.Find("Player");
		GameObject packet = null;
		GameObject[] children = (GameObject[])FindObjectsOfType(typeof(GameObject));

		foreach (GameObject child in children)
		{
			string name = child.name;

			if (name.StartsWith(search))
			{

				Vector2 posPlayer = PlayerObj.transform.position;
				Vector2 posChild = child.transform.position;
				float dist = Vector2.Distance(posPlayer, posChild);
				if (dist < radius)
				{
					packet = child;
					break;
				}

			}
		}

		return packet;
	}
}
