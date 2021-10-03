using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    [SerializeField] GameObject xAxis;
    [SerializeField] GameObject zAxis;
    [SerializeField] float rotationSpeed;
    

    GameUI gameUI;

    Vector3 positiveRotation;
    Vector3 negativeRotation;

    private void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
        positiveRotation = new Vector3(0, 0, rotationSpeed * Time.deltaTime);
        negativeRotation = positiveRotation * -1f;
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetAxis("Vertical") != 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                
                xAxis.transform.rotation = Quaternion.Euler(xAxis.transform.rotation.eulerAngles + positiveRotation);
                //xAxis.transform.Rotate(positiveRotation);
                gameUI.UnstableXAxis(xAxis.transform.rotation.z);
            }
            else
            {
                xAxis.transform.Rotate(negativeRotation);
                gameUI.UnstableXAxis(xAxis.transform.rotation.z);
            }
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                zAxis.transform.Rotate(positiveRotation);
                gameUI.UnstableZAxis(zAxis.transform.rotation.z);
            }
            else
            {
                zAxis.transform.Rotate(negativeRotation);
                gameUI.UnstableZAxis(zAxis.transform.rotation.z);
            }
        }
    }

    
}
