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
    [SerializeField] private Material otherMaterial;

    [SerializeField] private GameObject cubePrefab;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            localPlayer = gameObject;
        }
        else
        {
            GetComponent<MeshRenderer>().material = otherMaterial;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(cubePrefab, transform.position, Quaternion.identity);
        }
    }

}
