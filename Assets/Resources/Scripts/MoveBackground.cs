using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MoveBackground : MonoBehaviour
{
    public Transform target1;
    public Transform target2;
    private bool bClear;

    private float scrollRange = 6.5f;
    private float moveSpeed = 3.0f;
    private Vector3 moveDirection = Vector3.left;

    public UnityEvent StageChangeEvent;

    private void Awake()
    {
        bClear = false;
    }

    private void FixedUpdate()
    {
        if (bClear)
        {
            NextStage();
        }
    }

    public void ClearStage()
    {
        bClear = true;
    }


    private void NextStage()
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

    private void StageSet()
    {
        bClear = false;
        StageChangeEvent.Invoke();
    }
}
