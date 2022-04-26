using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_CameraLock : MonoBehaviour
{
    public GameObject target;
    private Vector3 targetPos;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.position = target.GetComponent<Transform>().position;
        //transform.position = target.GetComponent<Transform>().position + distance;
        //transform.LookAt(target.GetComponent<Transform>().position);
    }
}
