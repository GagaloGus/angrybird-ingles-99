using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
    public float speed = 10;
    Rigidbody rb;
    Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();

        Color rndColor = Color.HSVToRGB(Random.Range(0f, 1f), 70, 50);
        render.material.SetColor("_Color", rndColor);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { Destroy(this); }
    }

    private void Movement()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = input * speed;
    }
}
