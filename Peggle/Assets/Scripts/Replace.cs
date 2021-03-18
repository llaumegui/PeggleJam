using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replace : MonoBehaviour
{
	public GameObject O;
	public List<GameObject> ObjToReplace;

	[ContextMenu("ptn")]
	public void Replacer()
	{
		for (int i = ObjToReplace.Count - 1; i >= 0; i--)
		{
			Instantiate(O, ObjToReplace[i].transform.position, Quaternion.identity);

			DestroyImmediate(ObjToReplace[i]);
		}
	}
}
