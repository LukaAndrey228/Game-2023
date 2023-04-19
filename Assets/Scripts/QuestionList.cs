using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionList : MonoBehaviour {

	// Use this for initialization
	private List<Question> _questions=new List<Question>() { };


	public List<Question> questions { get { return _questions; } }
	public QuestionList()
	{

		_questions.Add(new Question("Какой тип данных рационально использовать для объявления восьмиразрядных целых  чисел?", new string[] { "long", "uint", "byte", "int" }, 2, 15, 30)); //6
		_questions.Add(new Question("Укажите, какой тип данных используется для описания целых чисел в C#",
			new string[] { "int", "double", "string", "char" }, 0, 15, 30)); //8
		_questions.Add(new Question("Укажите, какой тип данных используется для описания вещественных чисел в C#",
			new string[] { "int", "double", "string", "char" }, 1, 15, 30)); //9
		_questions.Add(new Question("Укажите, какой тип данных используется для описания строк в C#",
			new string[] { "int", "double", "string", "char" }, 2, 15, 30)); //10
		_questions.Add(new Question("Укажите, какой тип данных используется для описания символов в C#",
			new string[] { "int", "double", "string", "char" }, 3, 15, 30)); //11
	//	_questions.Add(new Question("Для решения какой задачи используется метод Console.Write()?",
		//	new string[] { "", "", "", "" }, 0, 15, 30)); //14
		_questions.Add(new Question("Для решения какой задачи используется метод Console.Read()?", new string[] { "Для ввода строковых данных с консоли", "Для вывода числовых и строковых данных в консоль", "Для ввода числовых и строковых данных с консоли", "Для вывода строковых данных в консоль" }, 0, 15, 30));//15
		_questions.Add(new Question("Укажите правильный ввод с консоли целого числа x ", new string[] { "int a=int.Parse(Console.Write());", " int a=Console.Write();", "int a = int.Parse(Console.Read());", "int a = Console.Read();" }, 2, 15, 30)); //16
		_questions.Add(new Question("Укажите правильное использование оператора Console.ReadLine() для ввода строковой переменной a ", new string[] { " string a=int.Parse(Console.ReadLine())", "Console.ReadLine(a)", "Console.ReadLine(\"{ 0 }\", a)", "string a=Console.ReadLine()" }, 3, 15, 30));//20
		_questions.Add(new Question("Укажите оператор ветвления", new string[] { "if () ; else", " for () ;", "While ();", "do ; While" }, 0, 15, 30)); 

	}
	private int getCountToAnswered()
    {
		int result = 0;
        for (int i = 0; i < _questions.Count; i++)
        {
			if (!_questions[i].getStatus())
            {
				result++;

			}
        }
		return result;
    }

	public Question getRandomQuestion()
    {
		Random randomDirection = new Random();
		Question result = null;
		bool status = true;
		if (getCountToAnswered() == 0) {
			clearHistory();
		}

        while (status)
        {
			int index=Random.Range(0, _questions.Count);
			result = _questions[index];
			status = result.getStatus();

		}

		return result;

	}
	public void clearHistory()
    {
		foreach (Question question in _questions)
		{
			question.resetStatus();
		}

	}
}


