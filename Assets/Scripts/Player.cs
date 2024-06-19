using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private static GameObject localPlayer;

    public static GameObject LocalPlayer { get { return localPlayer; } }

    private Rigidbody rb;
    [SerializeField] private float speed;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            localPlayer = gameObject;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!photonView.IsMine|| !PhotonNetwork.IsConnected)
        {
            return;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity=new Vector3(horizontal*speed, rb.velocity.y, vertical*speed);
    }

}
