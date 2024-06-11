using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MINI_MENU_BUTTONS : MonoBehaviour
{
	[SerializeField] private int mytype; //1 consume 2 craft 3 deploy

	public void HOVER_OPTION_ENTER()
	{
		this.transform.localScale = new Vector3(0.95f, 0.95f, 0.95f);
	}
	public void HOVER_OPTION_EXIT()
	{
		this.transform.localScale = new Vector3(1f, 1f, 1f);
	}
	public void SECELECTED_OPTION()
	{
		MINI_MENU.Instance.SELECTED_ACTION(mytype);
	}

}
