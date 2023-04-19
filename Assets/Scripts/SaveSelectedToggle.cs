using UnityEngine.UI;
using UnityEngine;


public class SaveSelectedToggle : MonoBehaviour 
{
	[SerializeField]private UnityEngine.UI.Toggle toggle1, toggle2, toggle3, toggle4;
	
	void Awake()
    {
		GameObject PlayerObj = GameObject.Find("Player");
		Player PlayerClass = PlayerObj.GetComponent<Player>();
		int selectedToggle = PlayerClass.selectedToggle;


	}

    void setTogglePlayer(int selectedToggle)
    {
		GameObject PlayerObj = GameObject.Find("Player");
		Player PlayerClass = PlayerObj.GetComponent<Player>();
		PlayerClass.selectedToggle = selectedToggle;


	}
	void updateTogglePlayer(int selectedToggle)
	{
		if (selectedToggle == 0)
		{
			toggle2.isOn = false;
			toggle3.isOn = false;
			toggle4.isOn = false;
		}
		else if (selectedToggle == 1)
		{
			toggle1.isOn = false;
			toggle3.isOn = false;
			toggle4.isOn = false;
		}
		else if (selectedToggle == 2)
		{
			toggle1.isOn = false;
			toggle2.isOn = false;
			toggle4.isOn = false;
		}
		else if (selectedToggle == 3)

		{
			toggle1.isOn = false;
			toggle2.isOn = false;
			toggle3.isOn = false;
		}
	}

		public void Toggle1Selected()
    {
		if (toggle1.isOn) {
			setTogglePlayer(0);
			updateTogglePlayer(0);
		}

	}
	public void Toggle2Selected()
	{
		if (toggle2.isOn)
		{
			setTogglePlayer(1);
			updateTogglePlayer(1);
		}
	}
	public void Toggle3Selected()
	{
		if (toggle3.isOn)
		{
			setTogglePlayer(2);
			updateTogglePlayer(2);
		}
	}
	public void Toggle4Selected()
	{
		if (toggle4.isOn)
		{
			setTogglePlayer(3);
			updateTogglePlayer(3);
		}
	}









}
