using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMove : MonoBehaviour
{

	public Transform[] waypoint;

	[SerializeField]
	private float moveSpeed = 3f;

	[HideInInspector]
	public int waypointIndex = 0;

	public bool moveAlloed = false;

	private void Start()
	{
		transform.position = waypoint[waypointIndex].transform.position;
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		if(waypointIndex <= waypoint.Length -1)
        {
			transform.position = Vector2.MoveTowards(transform.position, waypoint[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
			if(transform.position == waypoint[waypointIndex].transform.position)
            {
				waypointIndex += 1;
            }
        }
	}
}
