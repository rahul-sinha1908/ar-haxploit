// iOS gyroscope example
//
// Create a cube with camera vector names on the faces.
// Allow the iPhone to show named faces as it is oriented.

using UnityEngine;

public class ExampleScript : MonoBehaviour
{
	private Gyroscope gyro;
	private bool gyroEnabled;

	private GameObject cameraHolder;
	private Quaternion rot;

	void Start(){
		cameraHolder=new GameObject("Camera Holder");
		cameraHolder.transform.position=transform.position;
		transform.SetParent(cameraHolder.transform);

		gyroEnabled=enableGyro();
	}

	bool enableGyro(){
		if(SystemInfo.supportsGyroscope){
			Debug.Log("Gyroscope is enabled");
			gyro=Input.gyro;
			gyro.enabled=true;

			cameraHolder.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
			rot = new Quaternion(0,0,1,0);

			return true;
		}
		Debug.Log("Gyroscope doesnt work");
		return false;
	}
	void Update(){
		if(gyroEnabled){
			transform.localRotation = gyro.attitude*rot;
			//transform.localRotation = Quaternion.LookRotation(gyro.gravity, Vector3.up);
			Debug.Log("Show Details : "+gyro.gravity+" : "+gyro.attitude+" : "+transform.localRotation);
			
		}
	}
}