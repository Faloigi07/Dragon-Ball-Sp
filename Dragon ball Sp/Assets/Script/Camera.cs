using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Camera : MonoBehaviour{

    Transform Giocatore;

    [SerializeField]
    float z_offset = -10f;

    [SerializeField]
    float y_offset = 3f;

    [SerializeField]
    float smooth = 0.3f;

    Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start() => Giocatore = GameObject.FindGameObjectWithTag("Giocatore").transform;

    // Update is called once per frame
    void Update()
    {
        if(Giocatore != null)
        {
            Vector3 targetPosition = new Vector3(Giocatore.position.x,Giocatore.position.y + y_offset, Giocatore.position.z + z_offset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
        }
    }
}
