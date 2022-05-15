using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField] private Transform target;   
    [SerializeField] private float scrollRange = 6.5f;
    //[SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private Vector3 moveDirection = Vector3.left;
    void Update()
    {
        //if(nextStage == true)
        //transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if(transform.position.x <= -scrollRange)
        {
            transform.position = target.position + Vector3.right * scrollRange;
        }

    }
}
