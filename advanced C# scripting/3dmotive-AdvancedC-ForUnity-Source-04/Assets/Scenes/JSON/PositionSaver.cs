using UnityEngine;
using System.Collections;
using System.IO;
//----------------------------------------------
public class PositionSaver : MonoBehaviour
{
	//----------------------------------------------
	//Last position and rotation of object
	public Vector3 LastPosition = Vector3.up;
	public Quaternion LastRotation = Quaternion.identity;
	private Transform ThisTransform = null;
	//----------------------------------------------
	void SaveObject()
	{
		//Get position and rotation data

		//Create output path
		string OutputPath = Application.persistentDataPath + @"\ObjectPosition.json";
		LastPosition = ThisTransform.position;
		LastRotation = ThisTransform.rotation;

		//Generate Writer Object
		StreamWriter Writer = new StreamWriter(OutputPath);
		Writer.WriteLine(JsonUtility.ToJson(this));
		Writer.Close();
		Debug.Log("Outputting to: " + OutputPath);
	}
	//----------------------------------------------
	void LoadObject()
	{
		//Create input path
		string InputPath = Application.persistentDataPath + @"\ObjectPosition.json";

		StreamReader Reader = new StreamReader(InputPath);
		string JSONString = Reader.ReadToEnd();
		Debug.Log("Reading: " + JSONString);
		JsonUtility.FromJsonOverwrite(JSONString, this);
		Reader.Close();

		ThisTransform.position = LastPosition;
		ThisTransform.rotation = LastRotation;
	}
	//----------------------------------------------
	void OnDestroy()
	{
		SaveObject();
	}
	//----------------------------------------------
	void Start()
	{
		LoadObject();
	}
	//----------------------------------------------
	void Awake()
	{
		ThisTransform = GetComponent<Transform>();
	}
	//----------------------------------------------
}
//----------------------------------------------