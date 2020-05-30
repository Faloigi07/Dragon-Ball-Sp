using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour{

    public Transform[] bgs;

    Transform lastBG;

    float lastXBg = 0f;


    // Start is called before the first frame update
    void Start()
    {
        FindLastPoolingCoordinate(bgs);
    }

    //harray 
    void FindLastPoolingCoordinate(Transform[] objects)
    {
        for(int i =0; i <= objects.Length - 1; i++)
        {
            if(objects[i].position.x > lastXBg)
            {
                lastBG = objects[i];
                lastXBg = objects[i].position.x;
            }
        }
    }


    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Background")
        {
            float size = col.bounds.size.x;
            Vector3 newPosition = new Vector3(lastBG.transform.position.x + size, col.transform.position.y, col.transform.position.z);
            col.transform.position = newPosition;
            lastBG = col.gameObject.transform;
        }
    }
}
