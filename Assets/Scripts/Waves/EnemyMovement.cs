using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemigoPrueba))]
public class EnemyMovement : MonoBehaviour {


    private Transform target;
	private int wavepointIndex = 0;

	private EnemigoPrueba enemy;

	void Start()
	{
		enemy = GetComponent<EnemigoPrueba>();

		target = WaypoinPrueba.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.Vel * Time.deltaTime, Space.World);
		transform.LookAt(target);

		if (Vector3.Distance(transform.position, target.position) <= 0.4f)
		{
			GetNextWaypoint();
		}

		enemy.Vel = enemy.startVel;
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= WaypoinPrueba.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = WaypoinPrueba.points[wavepointIndex];
	}

	void EndPath()
	{
		Destroy(gameObject);
	}

}