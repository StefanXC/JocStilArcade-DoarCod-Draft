using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody),typeof (BoxCollider))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator[] animator;
    private ManagerJoystick managerJoystick;

    [SerializeField] public float viteza;

    public bool isAttacking = false;
    public bool seMisca;

    public int deAnimat;

    private float inputX;
    private float inputZ;

    void Start()
    {
        deAnimat = PlayerPrefs.GetInt("PersonajActiv", 0);

        managerJoystick = GameObject.Find("JoystickBGIMG").GetComponent<ManagerJoystick>();
    }



    void Update()
    {
        inputX = managerJoystick.inputHorizontal();
        inputZ = managerJoystick.inputVertical();
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            _rigidbody.velocity = new Vector3(_joystick.Horizontal * viteza, _rigidbody.velocity.y, _joystick.Vertical * viteza);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
                animator[deAnimat].SetBool("Merge", true);
                //_animator.SetFloat("Speed", viteza);
                seMisca = true;
            }
            else
            {
                seMisca = false;
                animator[deAnimat].SetBool("Merge", false);
            }
        }

    }
}
