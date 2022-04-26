using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PlayerMovement : MonoBehaviour
{
    public bool jumpKey;
    public bool lessStamina = false;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;

    [SerializeField] private int velocidade = 8;
    [SerializeField] private int pulo = 8;
    [SerializeField] private Vector3 movement;
    [SerializeField] private float fallMulti = 2.5f;
    [SerializeField] private float lowFallMulti = 2f;

    [SerializeField] private Transform groundCheck = null;
    [SerializeField] private LayerMask playerMask;
    private Rigidbody rigidbodyComponent;

    [SerializeField] private Script_GameOver scriptGO;
    [SerializeField] private PlayerAnimation scriptPA;


    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKey = true;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        movement = new Vector3(horizontalInput, 0, verticalInput);

        CheckTouchGround();


    }

    private void FixedUpdate()
    {
        //CheckTouchGround();
        PMovement();
        BetterJump();

    }

    void CheckTouchGround()
    {
        if (Physics.OverlapSphere(groundCheck.position, 0.1f, playerMask).Length == 0)
        //verifica se o empty (que tá no "pé" do player) ta fazendo colisao com algo
        {
            scriptPA.onAir = true;
            Debug.Log("entrou overlap");
            return;
        }

        scriptPA.onAir = false;
        IsJumpOk();
        
    }

    void IsJumpOk()
    {
        if (jumpKey == true)
        {
            //scriptPA.JumpAnima();
            scriptGO.StaminaJump();
            rigidbodyComponent.AddForce(Vector3.up * pulo, ForceMode.VelocityChange);
            jumpKey = false;
            
            
        }
    }

    void PMovement()
    {
        rigidbodyComponent.MovePosition(rigidbodyComponent.position + movement.normalized * velocidade * Time.fixedDeltaTime);
    }

    void BetterJump()
    {
        if (rigidbodyComponent.velocity.y < 0)
        {
            rigidbodyComponent.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;

        }
        else
            if (rigidbodyComponent.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rigidbodyComponent.velocity += Vector3.up * Physics.gravity.y * (lowFallMulti - 1) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "End")
        {
            scriptGO.YouWin();
        }
    }

}