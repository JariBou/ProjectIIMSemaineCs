using UnityEngine;

// Cartoon FX  - (c) 2015, Jean Moreno

public class CFX_Demo_Translate : MonoBehaviour
{
	public float speed = 30.0f;
	public Vector3 rotation = Vector3.forward;
	public Vector3 axis = Vector3.forward;
	public bool gravity;
	private Vector3 dir;

	private void Start ()
	{
		dir = new Vector3(Random.Range(0.0f,360.0f),Random.Range(0.0f,360.0f),Random.Range(0.0f,360.0f));
		dir.Scale(rotation);
		this.transform.localEulerAngles = dir;
	}

	private void Update ()
	{
		this.transform.Translate(axis * speed * Time.deltaTime, Space.Self);
	}
}
