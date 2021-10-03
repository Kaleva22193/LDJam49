using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float speed;
    [SerializeField] GameObject[] playerSpheres;
    [SerializeField] Material activeSphereMaterial;
    [SerializeField] Material baseSphereMaterial;
    GameObject currentPlayer;
    Rigidbody playerRigidBody;

    [SerializeField] float turnStrength = 180;
    float turnInput;
    float playerSwitchWait;

    // Start is called before the first frame update
    void Start()
    {
        playerSwitchWait = Random.Range(0, 200);

        SelectPlayerSphere();
    }

    // Update is called once per frame
    void Update()
    {
        
        turnInput = Input.GetAxis("Horizontal");
        
        if (Input.GetAxis("Vertical") != 0)
        {
            speed = Input.GetAxis("Vertical") * acceleration * Time.deltaTime * 100f;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));
        }

        playerSwitchWait -= Time.deltaTime;
        if (playerSwitchWait <= 0)
        {
            SelectPlayerSphere();
            playerSwitchWait = Random.Range(0, 100);
        }
        transform.position = playerRigidBody.position;
    }
    void FixedUpdate()
    {
        playerRigidBody.AddForce(transform.forward * speed);
    }
    void SelectPlayerSphere()
    {
        for (int i = 0; i < playerSpheres.Length; i++)
        {
            MeshRenderer resetSphereColor = playerSpheres[i].GetComponent<MeshRenderer>();
            resetSphereColor.material = baseSphereMaterial;
        }
        int index = Random.Range(0, playerSpheres.Length);
        currentPlayer = playerSpheres[index];
        playerRigidBody = playerSpheres[index].GetComponent<Rigidbody>();
        MeshRenderer sphereColor = playerSpheres[index].GetComponent<MeshRenderer>();
        sphereColor.material = activeSphereMaterial;
    }

}
