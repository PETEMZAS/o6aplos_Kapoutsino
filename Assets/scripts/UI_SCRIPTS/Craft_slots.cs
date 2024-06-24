using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft_slots : MonoBehaviour
{
	[SerializeField] private int slot;
  public void PRESSED_()
	{
		maininventory.instance.CHANGE_ITEAM_OR_TAKE(slot);
	}
}
