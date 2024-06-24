using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERACTABLE : MonoBehaviour
{
	[SerializeField] private GameObject HIG_LIG;

	private void Update()
	{
		if (Vector3.Distance(transform.position, MAIN.EGO_IME_EDO.transform.position)<3)      HIG_LIG.SetActive(true);

		else HIG_LIG.SetActive(false);

	}
	//private void OnTriggerStay(Collider other)
	//{
	//	if(other.tag=="MAIN") HIG_LIG.SetActive(true);

	//}
	//private void OnTriggerExit(Collider other)
	//{
	//	if (other.tag == "MAIN") HIG_LIG.SetActive(false);
	//}
}
