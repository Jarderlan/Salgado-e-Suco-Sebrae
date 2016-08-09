using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
    public float dayTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(dayTime * Time.deltaTime, 0, 0);
	}
}
