using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERACTABLE : MonoBehaviour
{
	[SerializeField] private GameObject HIG_LIG;


	private void OnTriggerStay(Collider other)
	{
		if(other.tag=="MAIN") HIG_LIG.SetActive(true);

	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "MAIN") HIG_LIG.SetActive(false);
	}
}
