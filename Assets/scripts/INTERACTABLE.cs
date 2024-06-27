using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERACTABLE : MonoBehaviour
{
	[SerializeField] private GameObject HIG_LIG;
	[SerializeField] private GameObject tip,tipfather;

	private GameObject gam;

	private void Start()
	{
		if (tip != null || tip != default)
		{
			var temp = Instantiate(tip);
			temp.transform.SetParent(tipfather.transform);
			temp.gameObject.GetComponent<temptip>().fertoedo(transform);
		

		}

	}
	private void Update()
	{
		if (Vector3.Distance(transform.position, MAIN.EGO_IME_EDO.transform.position) < 3)
		{
			HIG_LIG.SetActive(true);
	
		}
		else
		{
			HIG_LIG.SetActive(false);
			
		}

	
	}
	
	//}
}
