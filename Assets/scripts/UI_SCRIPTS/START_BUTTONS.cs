using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class START_BUTTONS : MonoBehaviour
{
	[SerializeField] private int myfuc;
public void FUC()
	{
		GAME_MECANICS.Instance.START_CYCLE(myfuc);
	}
}
