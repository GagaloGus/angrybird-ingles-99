using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : NetworkBehaviour
{
    public float speed = 1;
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
        rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed));
    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { Destroy(this); }
    }
}
