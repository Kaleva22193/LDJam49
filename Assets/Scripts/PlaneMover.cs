using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlaneMover : MonoBehaviour
{
    [SerializeField] Transform pointOne;
    [SerializeField] Transform boardPointOne;
    [SerializeField] Transform pointTwo;
    [SerializeField] Transform boardPointTwo;
    [SerializeField] Transform pointThree;
    [SerializeField] Transform boardPointThree;
    [SerializeField] Transform boardCenterPoint;

    [SerializeField] float movementAmount = .1f;
    [SerializeField] float maxHeight;

    [SerializeField] float pointTimerMultiplier;
    [SerializeField] float minTimerValue;
    [SerializeField] float maxTimerValue;

    float pointATimer;
    float pointBTimer;
    float pointCTimer;

    private void Start()
    {
        pointATimer = Random.Range(minTimerValue, maxTimerValue) * pointTimerMultiplier;
        pointBTimer = Random.Range(minTimerValue, maxTimerValue) * pointTimerMultiplier;
        pointCTimer = Random.Range(minTimerValue, maxTimerValue) * pointTimerMultiplier;

    }
    private void Update()
    {
        MoveThePlane();
        OutputTriangleCentroid();
    }
    void MoveThePlane()
    {
        Vector3 firstPoint = new Vector3(pointOne.position.x, pointOne.position.y, pointOne.position.z);
        Vector3 secondPoint = new Vector3(pointTwo.position.x, pointTwo.position.y, pointTwo.position.z);
        Vector3 thirdPoint = new Vector3(pointThree.position.x, pointThree.position.y, pointThree.position.z);

        if (pointATimer > minTimerValue)
        {
            firstPoint.y += movementAmount;
            pointATimer -= Time.deltaTime;
        }
        else
        {
            firstPoint.y -= movementAmount;
            StartCoroutine(RestartPointATimer());
        }
        if (pointBTimer > minTimerValue)
        {
            secondPoint.y += movementAmount;
            pointBTimer -= Time.deltaTime;
        }
        else
        {
            secondPoint.y -= movementAmount;
            StartCoroutine(RestartPointBTimer());
        }
        if (pointCTimer > minTimerValue)
        {
            thirdPoint.y += movementAmount;
            pointCTimer -= Time.deltaTime;
        }
        else
        {
            thirdPoint.y -= movementAmount;
            StartCoroutine(RestartPointCTimer());
        }

        firstPoint.y = Mathf.Clamp(firstPoint.y, 0, maxHeight);
        pointOne.transform.position = firstPoint;

        secondPoint.y = Mathf.Clamp(secondPoint.y, 0, maxHeight);
        pointTwo.transform.position = secondPoint;

        thirdPoint.y = Mathf.Clamp(thirdPoint.y, 0, maxHeight);
        pointThree.transform.position = thirdPoint;

    }
    IEnumerator RestartPointATimer()
    {
        yield return new WaitForSeconds(3);
        pointATimer = Random.Range(minTimerValue, maxTimerValue) * pointTimerMultiplier;
    }
    IEnumerator RestartPointBTimer()
    {
        yield return new WaitForSeconds(3);
        pointBTimer = Random.Range(minTimerValue, maxTimerValue) * pointTimerMultiplier;
    }
    IEnumerator RestartPointCTimer()
    {
        yield return new WaitForSeconds(3);
        pointCTimer = Random.Range(minTimerValue, maxTimerValue) * pointTimerMultiplier;
    }
    void MoveThePlaneManually()
    {
        Vector3 firstPoint = new Vector3(pointOne.position.x, pointOne.position.y, pointOne.position.z);
        Vector3 secondPoint = new Vector3(pointTwo.position.x, pointTwo.position.y, pointTwo.position.z);
        Vector3 thirdPoint = new Vector3(pointThree.position.x, pointThree.position.y, pointThree.position.z);

        if (Input.GetKey(KeyCode.A))
        {
            firstPoint.y += movementAmount;
        }
        else
        {
            firstPoint.y -= movementAmount;
        }        
        if (Input.GetKey(KeyCode.B))
        {
            secondPoint.y += movementAmount;
        }
        else
        {
            secondPoint.y -= movementAmount;
        }
        if (Input.GetKey(KeyCode.C))
        {
            thirdPoint.y += movementAmount;
          
        }
        else
        {
            thirdPoint.y -= movementAmount;
        }

        firstPoint.y = Mathf.Clamp(firstPoint.y, 0, maxHeight);
        pointOne.transform.position = firstPoint;

        secondPoint.y = Mathf.Clamp(secondPoint.y, 0, maxHeight);
        pointTwo.transform.position = secondPoint;
        
        thirdPoint.y = Mathf.Clamp(thirdPoint.y, 0, maxHeight);
        pointThree.transform.position = thirdPoint;
    }
    void OutputTriangleCentroid()
    {
        Vector3 firstPoint = new Vector3(pointOne.position.x, pointOne.position.y, pointOne.position.z);
        Vector3 secondPoint = new Vector3(pointTwo.position.x, pointTwo.position.y, pointTwo.position.z);
        Vector3 thirdPoint = new Vector3(pointThree.position.x, pointThree.position.y, pointThree.position.z);

        Vector3 triangleCentroid = new Vector3();

        triangleCentroid.x = (firstPoint.x + secondPoint.x + thirdPoint.x) / 3f;
        triangleCentroid.y = (firstPoint.y + secondPoint.y + thirdPoint.y) / 3f;
        triangleCentroid.z = (firstPoint.z + secondPoint.z + thirdPoint.z) / 3f;

        Debug.Log(triangleCentroid);
        //boardCenterPoint.transform.position = triangleCentroid;
    }
    

}
