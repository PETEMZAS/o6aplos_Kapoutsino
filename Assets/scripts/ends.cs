using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ends : MonoBehaviour
{



	private void Update()
	{
		if (Input.anyKeyDown)
		{
			SceneManager.LoadScene("MAINGAME");
		}
	}

}
