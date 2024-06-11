using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MINI_MENU : MonoBehaviour
{
	public static MINI_MENU Instance;
	[SerializeField]private GameObject UI_BACKGROUND;
	[SerializeField] private GameObject inventorything;
	[SerializeField] private GameObject op1, op2, op3;
	private int CURRENT_SLOT;

	private void Awake()
	{
		Instance = this;
		

	}
	private void Update()
	{
		if (inventorything.gameObject.activeSelf == false)
		{
			UI_BACKGROUND.gameObject.SetActive(false);
		}
	}

	public void call_on_slot(int num,Transform t)
	{
		if(maininventory.CURRENT_ITEAMS_ON_DISPLAY.Count> num)
		{
			CURRENT_SLOT = num;
				UI_BACKGROUND.gameObject.SetActive(true);
				op1.SetActive(true);
				op2.SetActive(true);
				op3.SetActive(true);
				CHECK_AVAILABLE_ACTIONS(num);

				this.transform.position = t.position;

		}

		
	}
	public void SELECTED_ACTION(int op)
	{
		maininventory.instance.GET_CHILD_NUM_AND_OP(CURRENT_SLOT, op);
		
		CLOSE_MINI_MENU();
	}
	public void CLOSE_MINI_MENU()
	{
		UI_BACKGROUND.gameObject.SetActive(false);
		CURRENT_SLOT =default;
	}
	public void CHECK_AVAILABLE_ACTIONS(int i )
	{
		if(MAIN.consumables[maininventory.CURRENT_ITEAMS_ON_DISPLAY[i]].can_EAT==false)
		{
			op1.SetActive(false);
		}
		if (MAIN.consumables[maininventory.CURRENT_ITEAMS_ON_DISPLAY[i]].can_craft == false)
		{
			op2.SetActive(false);
		}
		if (MAIN.consumables[maininventory.CURRENT_ITEAMS_ON_DISPLAY[i]].can_deploy == false)
		{
			op3.SetActive(false);
		}
	}
}
