﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 targetPos;
	public float moveSpeed;
	private static bool cameraExists;
	public BoxCollider2D boundBox;
	public Vector3 minBounds;
	public Vector3 maxBounds;
	private Camera theCamera;
	private float halfHeight;
	private float halfWidth;
	
	public Animator anim;

	// Use this for initialization
	void Start () {
		
		DontDestroyOnLoad(transform.gameObject);

		if(!cameraExists)
		{
			cameraExists = true;
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy (gameObject);
		}

			if(boundBox == null)
		{
			boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
			minBounds = boundBox.bounds.min;
			maxBounds = boundBox.bounds.max;
		}

		minBounds = boundBox.bounds.min;
		maxBounds = boundBox.bounds.max;
		theCamera = GetComponent<Camera>();
		halfHeight = theCamera.orthographicSize;
		halfWidth = halfHeight * Screen.width / Screen.height;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
		targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);

		if(boundBox == null)
		{
			boundBox = FindObjectOfType<Bounds>().GetComponent<BoxCollider2D>();
			minBounds = boundBox.bounds.min;
			maxBounds = boundBox.bounds.max;
		}

		float clampedX = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
		float clampedY = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

		transform.position = new Vector3(clampedX, clampedY, transform.position.z);

	}

	public void SetBounds(BoxCollider2D newBounds)
	{
		boundBox = newBounds;
		minBounds = boundBox.bounds.min;
		maxBounds = boundBox.bounds.max;


	}

	public void BeginKick()
	{
		anim.SetBool("KickActive", true);
		StartCoroutine(KickCo());
	}

	public IEnumerator KickCo()
	{
		
		yield return null;
		anim.SetBool("KickActive", false);
	}



}
