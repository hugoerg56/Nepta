using UnityEngine;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;
    public Transform[] waypointsEnd;
    public Transform[] waypointsStart;
    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;
    public int waypointStart = 0;

    public bool moveAllowed = false;

	// Use this for initialization
	private void Start () {
        transform.position = waypointsStart[waypointStart].transform.position;
        
	}
	
	// Update is called once per frame
	private void Update () {
        if (moveAllowed)
            Move();
	}

    private void Move()
    {
        if(waypointStart == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex].transform.position,
            moveSpeed * Time.deltaTime);
            waypointStart = 1;
        }
        else
        {
            if (waypointIndex <= waypoints.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                waypoints[waypointIndex].transform.position,
                moveSpeed * Time.deltaTime);

                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }
            }
        }

        
    }
}
