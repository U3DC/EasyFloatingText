using System.Collections;
using System.Collections.Generic;
using EasyFloatingText;
using UnityEngine;
using UnityEngine.UI;
using EasyFloatingText;

public class Demo : MonoBehaviour
{
    public List<GameObject> go;
    public Camera camera;
	void Start ()
	{
	    for (int i = 0; i < 5; i++)
	    {
	        var creator = new FloatingCreator();
	        var text = creator.Create();
	        var ft = text.GetComponent<FloatingText>();
	        ft.TextValue = i.ToString();
	        ft.Target = go[i].transform;
	        ft.Camera = camera;
        }
	}
}
