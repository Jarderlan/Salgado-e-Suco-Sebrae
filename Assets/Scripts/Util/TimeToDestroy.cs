﻿using UnityEngine;
using System.Collections;

public class TimeToDestroy : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
        Invoke("Destroy", time);
	}
	
	// Update is called once per frame
	void Destroy () {
        Destroy(gameObject);
	}
}
