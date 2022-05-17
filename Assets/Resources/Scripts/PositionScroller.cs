using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScroller : MonoBehaviour
{
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;   
    [SerializeField] private float scrollRange = 6.5f;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private Vector3 moveDirection = Vector3.left;

    public bool NextStage(bool bclear)
    {

        if (bclear)
        {
            target1.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            target2.transform.position += moveDirection * moveSpeed * Time.deltaTime;

            if (target1.transform.position.x <= -scrollRange)
            {
                target1.transform.position = target2.position + Vector3.right * scrollRange;
                bclear = false;
            }

            if (target2.transform.position.x <= -scrollRange)
            {
                target2.transform.position = target1.position + Vector3.right * scrollRange;
                bclear = false;
            }
        }

        return bclear;

    }




}
