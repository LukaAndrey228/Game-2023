using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : MonoBehaviour
{

	// Use this for initialization
	private string _desc;
	private string[] _answers;
	private int _valide;
	private int _reward;
	private int _shtraff;
	private bool _status;


	public string desc { get { return _desc; } }
	public string[] answers { get { return _answers; } }
	public int valide { get { return _valide; } }
	public int reward { get { return _reward; } }
	public int shtraff { get { return _shtraff; } }

	public Question(string desc, string[] answers, int valide, int reward, int shtraff)
	{
		_desc = desc;
		_answers = answers;
		_valide = valide;
		_reward = reward;
		_shtraff = shtraff;
		_status = false;
	}
	public void resetStatus()
	{
		_status = false;

	}
	public bool getStatus()
	{
		return _status;

	}

	public bool checkQuestion(int answer)
	{
		_status = true;
		return answer == _valide;

	}

}