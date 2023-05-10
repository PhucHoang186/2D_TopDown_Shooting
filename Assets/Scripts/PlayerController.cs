using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Entity
{
    [Header("References")]
    [SerializeField] Transform playerModel;
    [SerializeField] Transform rightHandPoint;
    [SerializeField] Transform leftHandPoint;
    [SerializeField] Transform gunHolder;
    [SerializeField] Gun currentGun;
    [SerializeField] Gun defaultGun;
    [SerializeField] Animator gunAnim;
    [SerializeField] ShowTimeBetweenShot showTimeBetweenShotUi;
    [SerializeField] GameObject sprintVfx;
    [Header("Params")]
    [SerializeField] float moveSpeed;
    [SerializeField] float sprintMoveSpeed;
    [SerializeField] float accelerateSpeed;
    Vector3 moveDir;
    Vector3 lookDir;
    Camera mainCam;
    Rigidbody2D rig;
    GunData gunData;
    float currentMoveSpeed;
    float desMoveSpeed;
    float timeBetweenShoot;
    float currentTimeBetweenShoot;
    bool isSprinting;

    public override void Start()
    {
        base.Start();
        Init();
    }

    void Init()
    {
        mainCam = Camera.main;
        rig = GetComponent<Rigidbody2D>();
        desMoveSpeed = currentMoveSpeed = moveSpeed;
        SetUpGun(defaultGun);
    }

    private void GetInput()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            desMoveSpeed = sprintMoveSpeed;
            sprintVfx.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            desMoveSpeed = moveSpeed;
            sprintVfx.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        // GetInput();
        Rotate();
        Move();
    }

    private void Move()
    {
        currentMoveSpeed = Mathf.Lerp(currentMoveSpeed, desMoveSpeed, Time.deltaTime * accelerateSpeed);
        rig.MovePosition(transform.position + moveDir.normalized * currentMoveSpeed * Time.deltaTime);
    }

    void Update()
    {
        GetInput();
        if (currentGun != null)
        {

            if (currentTimeBetweenShoot <= 0)
            {
                if ((Input.GetMouseButtonDown(0) && !gunData.isAuto) || (Input.GetMouseButton(0) && gunData.isAuto))
                {
                    currentTimeBetweenShoot = timeBetweenShoot;
                    currentGun.Shoot();
                    gunAnim.Play("Gun_Shoot");
                }
            }
            else
            {
                currentTimeBetweenShoot -= Time.deltaTime;
            }
            showTimeBetweenShotUi.UpdateLoadUI(currentTimeBetweenShoot);
        }
    }

    private void SetUpGun(Gun newGun)
    {
        var newGunObj = Instantiate(newGun, gunHolder);
        currentGun = newGunObj;
        gunData = currentGun.GunData;
        currentGun.SetUpHoldingGun(rightHandPoint, leftHandPoint);
        timeBetweenShoot = gunData.timeBetweenShoot;
        showTimeBetweenShotUi.SetUp(gunData.timeBetweenShoot);
    }

    private void Rotate()
    {
        lookDir = (mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        lookDir.z = 0f;
        playerModel.up = lookDir;
    }
}
