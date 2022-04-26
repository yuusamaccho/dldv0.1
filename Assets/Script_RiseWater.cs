using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_RiseWater : MonoBehaviour
{
    private bool moved = false;
    //private Vector3 waterPosition;
    [SerializeField]private float rise = 0.1f;
    // base water rise é 0.1f

    [SerializeField] private GameObject water;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (moved == false)
        {
            GameStarted();
        }
    }

    private void FixedUpdate()
    {
        WaterRise();
    }

    void GameStarted()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            moved = true;
            //Debug.Log("A key or mouse click has been detected");

        }
    }

    void WaterRise()
    {
        if(moved == true)
        {
            //Debug.Log(" water rising");

            //waterPosition = water.transform.position;
            water.transform.Translate(Vector3.up * Time.deltaTime * rise);

            //Debug.Log("" + waterPosition);

        }

    }
}