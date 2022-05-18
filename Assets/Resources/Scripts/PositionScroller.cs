using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PositionScroller : MonoBehaviour
{
    public Transform target1;
    public Transform target2;   
    private float scrollRange = 6.5f;
    private float moveSpeed = 2.0f;
    private Vector3 moveDirection = Vector3.left;

    public UnityEvent StageChangeEvent;


    public void NextStage(bool bclear)
    {
        if (bclear)
        {
            target1.transform.position += moveDirection * moveSpeed * Time.deltaTime;
            target2.transform.position += moveDirection * moveSpeed * Time.deltaTime;

            if (target1.transform.position.x <= -scrollRange)
            {
                target1.transform.position = target2.position + Vector3.right * scrollRange;
                StageSet();
            }

            if (target2.transform.position.x <= -scrollRange)
            {
                target2.transform.position = target1.position + Vector3.right * scrollRange;
                StageSet();
            }
        }

    }

    private void StageSet()
    {
        StageChangeEvent.Invoke();
    }




}
