using UnityEngine;
using System.Collections;

public class DungeonCamera : MonoBehaviour {
    public Transform target;
    public int zoomRate = 40;
	public float zoomDampening = 5.0f;
	public float xSpeed = 200.0f;
    public float ySpeed = 200.0f;
    public int yMinLimit = 0;
    public int yMaxLimit = 0;
	public float maxDistance = 0;
    public float minDistance = 0f;
	
	private float xDeg = 0.0f;
    private float yDeg = 0.0f;
	private Quaternion currentRotation;
    private Quaternion desiredRotation;
	private Quaternion rotation;
	private Vector3 vitualTornadoPos;
	private Vector3 desiredPosition;
	private float currentDistance;	
	private float desiredDistance;	
    private Vector3 offset;
	
    void Start() {       
		currentDistance = (transform.position - target.position).magnitude;	
		desiredDistance = currentDistance;
		rotation = transform.rotation;		
		currentRotation = transform.rotation;
		offset = rotation * (-Vector3.forward) * currentDistance;
		
		xDeg = Vector3.Angle(Vector3.right, transform.right );
        yDeg = Vector3.Angle(Vector3.up, transform.up );
    }
	
    void LateUpdate() {
        desiredPosition = target.position + offset;
		transform.position = desiredPosition;
		vitualTornadoPos =  transform.position - offset;
		
		if (Input.GetMouseButton(2))
        {
            xDeg += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            yDeg -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
 			
            //Clamp the vertical axis for the orbit
            yDeg = ClampAngle(yDeg, yMinLimit, yMaxLimit);
            // set camera rotation 
            desiredRotation = Quaternion.Euler(yDeg, xDeg, 0);
            currentRotation = transform.rotation;
 
            rotation = Quaternion.Lerp(currentRotation, desiredRotation, Time.deltaTime * zoomDampening);
            transform.rotation = rotation;
        }
		desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomRate * Mathf.Abs(desiredDistance);
		desiredDistance = Mathf.Clamp(desiredDistance, minDistance, maxDistance);
        // For smoothing of the zoom, lerp distance
        currentDistance = Mathf.Lerp(currentDistance, desiredDistance, Time.deltaTime * zoomDampening);
		Vector3 position = vitualTornadoPos - rotation * Vector3.forward * currentDistance;
		transform.position = position;
//        transform.LookAt(target.position);
    }
	
	private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
