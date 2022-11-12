using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMovement: MonoBehaviour
{
<<<<<<< Updated upstream
    public bool isPressed;
=======
    [Header("Twerks")]
    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
>>>>>>> Stashed changes

    public float groundDrag;


    Rigidbody rb;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    public float speed;

    Vector3 moveDirection;

    GameObject respawn;

    public GameObject[] monsterPrefab;


    public float radius;

    public bool isSpawned = false;

    public float spawnTime;
    public float spawnDelay;

    public int startWait;
    public float spawnWait;

    public float minTime;
    public float maxTime;

    Vector3 randomPos;
    int randMonster;

    public int spawnCount;

    public int amountOfMonster;

    public AudioSource audioCamera;
    public AudioSource audioGhost;

    public GameObject monster;

    public bool stop;

    public GameObject cameraFlash;

    
    public float flashTime;

    public GameObject[] walls;
    bushSound BushSound;

<<<<<<< Updated upstream
    public FixedJoystick joyStick;
=======
    public float _speed;
    private float rotSpeed = 90f;
    private Vector3 _moveDirection = Vector3.zero;
    [SerializeField] CharacterController controller;

    private float _initialYAngle = 0f;
    private float _appliedGyroYAngle = 0f;
    private float _calibrationYYAngle = 0f;
    private Transform _rawGyroRotation;
    private float _tempSmoothing;

    private float _smoothing = 0.1f;
>>>>>>> Stashed changes


    //MonsterMovement monsterMovement;








    // Start is called before the first frame update
    /*void Start()
    {
        
        rb = this.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        //StartCoroutine(waitSpawner());
        StartCoroutine(waitSpawnFunction());
        //BushSound.GetComponent<bushSound>();

        //monsterMovement = GetComponent<MonsterMovement>();

        //GyroManager.Instance.EnableGyro();
    }*/

    
    private void MovementInput()
    {
        //player movement
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");


    }

    // Update is called once per frame
    void Update()
    {
        //MovementInput();
        //rb.drag = groundDrag;

        respawn = GameObject.FindWithTag("Respawn");
        
        spawnWait = Random.Range(minTime, maxTime);

        /*if (Input.GetKeyDown(KeyCode.F))
        {
            audioCamera.Play();
            Debug.Log("Sounded");
            StartCoroutine(cameraFlashEffect());
        }*/

        monster = GameObject.FindWithTag("Monster");

        //transform.localRotation = GyroManager.Instance.GetGyroRotation() * baseRotation;
        //Movement
        Vector3 move = new Vector3(Input.acceleration.x * _speed * Time.deltaTime, 0, -Input.acceleration.z * speed * Time.deltaTime);
        Vector3 rotMovement = transform.TransformDirection(move);
        controller.Move(rotMovement);

        //Rotation
        ApplyGyroRotation();
        ApplyCalibration();

        transform.rotation = Quaternion.Slerp(transform.rotation, _rawGyroRotation.rotation, _smoothing);
    }

<<<<<<< Updated upstream

=======
    private IEnumerator Start()
    {
        Input.gyro.enabled = true;
        Application.targetFrameRate = 60;
        _initialYAngle = transform.eulerAngles.y;

        _rawGyroRotation = new GameObject("GyroRaw").transform;
        _rawGyroRotation.position = transform.position;
        _rawGyroRotation.rotation = transform.rotation;

        yield return new WaitForSeconds(1);

        StartCoroutine(CalibrateYAngle());
    }

    private IEnumerator CalibrateYAngle()
    {
        _tempSmoothing = _smoothing;
        _smoothing = 1;
        _calibrationYYAngle = _appliedGyroYAngle - _initialYAngle;
        yield return null;
        _smoothing = _tempSmoothing;
    }

    private void ApplyGyroRotation()
    {
        _rawGyroRotation.rotation = Input.gyro.attitude;
        _rawGyroRotation.Rotate(0f, 0f, 180f, Space.Self);
        _rawGyroRotation.Rotate(90f, 180f, 0f, Space.World);
        _appliedGyroYAngle = _rawGyroRotation.eulerAngles.y;
    }

    private void ApplyCalibration()
    {
        _rawGyroRotation.Rotate(0f, -_calibrationYYAngle, 0F, Space.World);
    }

    public void SetEnabled(bool value)
    {
        enabled = true;
        StartCoroutine(CalibrateYAngle());
    }
>>>>>>> Stashed changes
    private void FixedUpdate()
    {
        //MovePlayer();
    }

    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Monster") && Input.GetKey(KeyCode.F))
        {
            
            audioGhost.Stop();
            //monsterMovement.bushAudio.Stop();
            stop = false;
            //BushSound.bushClip.Stop();
            Destroy(other.gameObject);
            

            //amountOfMonster--;
            Debug.Log("You Stun a Monster");
            //this.GetComponent<Health>().health--;
            //StartCoroutine(waitSpawner());

            /*if (amountOfMonster <= 0)
            {
                StartCoroutine(waitSpawner());
            } */
        }


    }

    private void SpawnFunction()
    {

        randomPos = Random.insideUnitSphere * radius;
        randomPos += this.transform.position;
        randomPos.y = 0.3f;

        Vector3 direction = randomPos - this.transform.position;
        direction.Normalize();

        float dotProduct = Vector3.Dot(this.transform.forward, direction);
        float dotProductAngle = Mathf.Acos(dotProduct / this.transform.forward.magnitude * direction.magnitude);

        randomPos.x = Mathf.Cos(dotProductAngle) * radius + this.transform.position.x;
        randomPos.z = Mathf.Sin(dotProductAngle * (Random.value > 0.5 ? 1f : -1f)) * radius + this.transform.position.z;

    }


    /* public IEnumerator waitSpawner()
    {

        yield return new WaitForSeconds(startWait);
        SpawnFunction();

        for (int count = spawnCount; count > 0; count--)
        {
            GameObject monster = Instantiate(monsterPrefab[randMonster], randomPos, Quaternion.identity);
            monster.transform.position = randomPos;
            audioGhost.Play();
            StartCoroutine(SelfDestruct());
            //amountOfMonster++;
            //isSpawned = true;
            yield return new WaitForSeconds(spawnWait);
        }

    } */

    public IEnumerator waitSpawnFunction()
    {
        yield return new WaitForSeconds(startWait);
        
        while (!stop)
        {
            SpawnFunction();

            GameObject monster = Instantiate(monsterPrefab[randMonster], randomPos, Quaternion.identity);
            
            audioGhost.Play();

            stop = true;

            yield return new WaitForSeconds(spawnWait);
        }
    }

    /*IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(10f);

        //playerMovement.StartCoroutine(playerMovement.waitSpawner());

        Destroy(monster.gameObject);
        audioGhost.Stop();
        StartCoroutine(waitSpawner());
    }*/



    IEnumerator cameraFlashEffect()
    {
        cameraFlash.SetActive(true);
        yield return new WaitForSeconds(flashTime);
        cameraFlash.SetActive(false);


    }
}
