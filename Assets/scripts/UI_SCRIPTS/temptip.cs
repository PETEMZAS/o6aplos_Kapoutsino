using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temptip : MonoBehaviour
{
	 private Camera cam;
		private Vector3 offset=new Vector3(0.3f,0.6f,0);
	
	private Transform tra;
	public void fertoedo(Transform t)
	{
		cam = MAIN.Instance.getc();
		transform.position = cam.WorldToScreenPoint(t.position);
		tra = t;
	}
	private void Update()
	{
		if (tra == null)
		{
			Destroy(this.gameObject);
		}
		if (cam != default)
		{
		transform.position = cam.WorldToScreenPoint(tra.position+offset);

		}


		if (Vector3.Distance(tra.transform.position, MAIN.EGO_IME_EDO.transform.position) < 3)
		{
			print(tra);
			this.GetComponent<Image>().enabled = true;

		}
		else
		{
			
			this.GetComponent<Image>().enabled = false;

		}


	}
}

