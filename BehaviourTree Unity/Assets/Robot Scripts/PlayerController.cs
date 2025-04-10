using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    public float playerSpeed;

    public LayerMask laserLayerMask;
    int collidersFound;

    Collider[] collidersInsideOverlap = new Collider[1];


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));

        characterController.Move(move * Time.deltaTime * playerSpeed);


        LaserHit();
    }

    void LaserHit()
    {

        collidersFound = Physics.OverlapBoxNonAlloc(transform.position, transform.localScale, collidersInsideOverlap, Quaternion.identity, laserLayerMask);


    }
}
