using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    [SerializeField] float chaseDistance;
    public Mover mover;
    private GameObject player;
    // Start is called before the first frame update
    public void Start()
    {
        mover = GetComponent<Mover>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public void Update()
    {
        if (DistanceToPlayer() <= chaseDistance)
        {
            mover.MoveTo(player.transform.position);
        }
    }

    private float DistanceToPlayer()
    {
        return Vector3.Distance(player.transform.position, transform.position);
    }
}