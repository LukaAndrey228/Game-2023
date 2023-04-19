using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonQuestions : MonoBehaviour {
	
	public void onClick()
	{
		GameObject QuestionsForm = GameObject.FindWithTag("Questions");

		Vector3 positionForm = QuestionsForm.transform.position;

		GameObject PlayerObj = GameObject.Find("Player");
		Player PlayerClass = PlayerObj.GetComponent<Player>();
		GameObject packet = PlayerClass.currentPacket;

		QuestionsForm.transform.position = new Vector3(positionForm.x, positionForm.y, -300);
		Question quest = PlayerClass.currentQuestion;
		int answer = PlayerClass.selectedToggle;

		//if is correct answer on question
		Debug.Log(answer);
		if (quest.checkQuestion(answer))
        {
			packet.SetActive(false);
			PlayerClass.WinFood(quest.reward);
		}
        else
		{
			PlayerClass.LoseFood(quest.shtraff);
		}


		
		PlayerClass.currentPacket = null;
		PlayerClass.selectedToggle =-1;


	}
	public void onEnter()
	{
		
	}
}
