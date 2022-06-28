using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 0.1f;
    public Rigidbody2D playerRb;

    private bool verticalOnly;
    private bool horizontalOnly;
    public bool atPole;
    public bool atPoleTop;
    public bool atGate;
    public bool onGate;
    public bool atPipe;
    public bool atPipeSide;
    public bool atBread;
    public bool atBird;
    public bool atKey;
    public bool atDoor;

    public bool hasBread;
    public bool hasKey;
    public bool openDoor;

    public int cheeseCount;
    public GameObject cheeseText;

    private Vector2 _movement;

    //boundaries
    public float limitLeft, limitRight, limitBottom, limitTop;

    //animator
    // public Animator playerAnimator;
    private Vector2 _previousPosition;

    GameObject _breadSlice;
    GameObject _door;

    // Start is called before the first frame update
    private void Start()
    {
        cheeseCount = 0;
        verticalOnly = false;
        horizontalOnly = false;
        _previousPosition = playerRb.position;
        onGate = false;
        hasBread = false;
        hasKey = false;
        openDoor = false;

        GameObject _player = GameObject.FindGameObjectWithTag("Player");
        _breadSlice = GameObject.FindGameObjectWithTag("breadSlice");
        _breadSlice.SetActive(false);

        _door = GameObject.FindGameObjectWithTag("door");
        _door.SetActive(false);

        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("birdCollision").GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());
        GameObject[] _poleColliders = GameObject.FindGameObjectsWithTag("poleCollision");
        foreach (GameObject _poleCollider in _poleColliders)
            Physics2D.IgnoreCollision(_poleCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());

        GameObject[] _gateColliders = GameObject.FindGameObjectsWithTag("gateCollision");
        foreach (GameObject _gateCollider in _gateColliders)
            Physics2D.IgnoreCollision(_gateCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());

        GameObject[] _pipeColliders = GameObject.FindGameObjectsWithTag("pipeCollision");
        foreach (GameObject _pipeCollider in _pipeColliders)
            Physics2D.IgnoreCollision(_pipeCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());

    }

    // Update is called once per frame
    private void Update()
    {
        cheeseText.GetComponent<TextMeshProUGUI>().text = cheeseCount + "/10";
        GameObject _player = GameObject.FindGameObjectWithTag("Player");

        if (!verticalOnly)
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            _movement.x = 0;
        }

        if (!horizontalOnly)
        {
            _movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            _movement.y = 0;
        }

        //pole climb
        if (atPole && Input.GetKeyDown(KeyCode.Space) && !verticalOnly)
        {
            verticalOnly = true;
            GameObject _pole = GameObject.FindGameObjectWithTag("poleBase");
            Renderer renderer = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>();
            renderer.sortingLayerName = "post";
            Vector2 newPosition = new Vector2(-2.2f, _pole.gameObject.transform.position.y - 3);
            playerRb.position = newPosition;
            Physics2D.IgnoreCollision(_pole.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());

            GameObject[] _poleColliders = GameObject.FindGameObjectsWithTag("poleCollision");
            foreach (GameObject _poleCollider in _poleColliders)
                Physics2D.IgnoreCollision(_poleCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), false);


            //bird
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("birdCollision").GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), false);

        }
        else if (atPole && Input.GetKeyDown(KeyCode.Space) && verticalOnly)
        {
            verticalOnly = false;
            GameObject _pole = GameObject.FindGameObjectWithTag("poleBase");
            Renderer renderer = GameObject.FindGameObjectWithTag("Player").GetComponent<Renderer>();
            renderer.sortingLayerName = "Default";
            Vector2 newPosition = new Vector2(-2.2f, _pole.gameObject.transform.position.y + 1);
            playerRb.position = newPosition;
            Physics2D.IgnoreCollision(_pole.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), false);

            GameObject[] _poleColliders = GameObject.FindGameObjectsWithTag("poleCollision");
            foreach (GameObject _poleCollider in _poleColliders)
                Physics2D.IgnoreCollision(_poleCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());
            //bird
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("birdCollision").GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());

        }


        //top of pole
        if (atPoleTop && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && verticalOnly)
        {
            verticalOnly = false;
            horizontalOnly = true;
            Vector2 newPosition = new Vector2(-2.2f, 3f);
            playerRb.position = newPosition;
        }
        else if (atPoleTop && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && horizontalOnly)
        {
            verticalOnly = true;
            horizontalOnly = false;
            Vector2 newPosition = new Vector2(-2.2f, 3f);
            playerRb.position = newPosition;
        }

        //at gate
        if (atGate && Input.GetKeyDown(KeyCode.Space) && !onGate)
        {
            // verticalOnly = true;
            onGate = true;
            GameObject _gate = GameObject.FindGameObjectWithTag("gateBase");
            Vector2 newPosition = new Vector2(_player.transform.position.x, _player.transform.position.y + 0.5f);
            playerRb.position = newPosition;
            Physics2D.IgnoreCollision(_gate.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());

            GameObject[] _gateColliders = GameObject.FindGameObjectsWithTag("gateCollision");
            foreach (GameObject _gateCollider in _gateColliders)
                Physics2D.IgnoreCollision(_gateCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), false);

        }
        else if (atGate && Input.GetKeyDown(KeyCode.Space) && onGate)
        {
            // verticalOnly = false;
            onGate = false;
            GameObject _gate = GameObject.FindGameObjectWithTag("gateBase");
            Vector2 newPosition = new Vector2(_player.transform.position.x, _player.transform.position.y - 0.7f);
            playerRb.position = newPosition;
            Physics2D.IgnoreCollision(_gate.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), false);

            GameObject[] _gateColliders = GameObject.FindGameObjectsWithTag("gateCollision");
            foreach (GameObject _gateCollider in _gateColliders)
                Physics2D.IgnoreCollision(_gateCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>());
        }

        if (atPipe && Input.GetKeyDown(KeyCode.Space) && !verticalOnly)
        {

            _player.GetComponent<SpriteRenderer>().sortingOrder = 5;
            verticalOnly = true;
            Vector2 newPosition = new Vector2(7.3f, _player.transform.position.y + 0.5f);
            playerRb.position = newPosition;

            GameObject[] _gateColliders = GameObject.FindGameObjectsWithTag("gateCollision");
            foreach (GameObject _gateCollider in _gateColliders)
                Physics2D.IgnoreCollision(_gateCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), true);

            GameObject[] _pipeColliders = GameObject.FindGameObjectsWithTag("pipeCollision");
            foreach (GameObject _pipeCollider in _pipeColliders)
                Physics2D.IgnoreCollision(_pipeCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), false);

        }
        else if (atPipe && Input.GetKeyDown(KeyCode.Space) && verticalOnly)
        {
            _player.GetComponent<SpriteRenderer>().sortingOrder = 100;
            verticalOnly = false;
            // onGate = false;
            GameObject _gate = GameObject.FindGameObjectWithTag("gateBase");
            Vector2 newPosition = new Vector2(7.3f, _player.transform.position.y - 0.5f);
            playerRb.position = newPosition;

            GameObject[] _gateColliders = GameObject.FindGameObjectsWithTag("gateCollision");
            foreach (GameObject _gateCollider in _gateColliders)
                Physics2D.IgnoreCollision(_gateCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), false);

            GameObject[] _pipeColliders = GameObject.FindGameObjectsWithTag("pipeCollision");
            foreach (GameObject _pipeCollider in _pipeColliders)
                Physics2D.IgnoreCollision(_pipeCollider.GetComponent<Collider2D>(), _player.GetComponent<Collider2D>(), true);
        }


        if (atPipeSide && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && verticalOnly)
        {
            verticalOnly = false;
            horizontalOnly = true;
            Vector2 newPosition = new Vector2(6.51f, 0f);
            playerRb.position = newPosition;
        }
        else if (atPipeSide && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && horizontalOnly)
        {
            verticalOnly = true;
            horizontalOnly = false;
            Vector2 newPosition = new Vector2(7.3f, 0f);
            playerRb.position = newPosition;
        }

        if (atBread && Input.GetKeyDown(KeyCode.Space))
        {
            hasBread = true;
            GameObject bread = GameObject.FindGameObjectWithTag("bread");
            Destroy(bread);
        }

        if (hasBread && Input.GetKeyDown(KeyCode.Space) && atBird)
        {
            // GameObject _breadSlice = GameObject.FindGameObjectWithTag("breadSlice");
            _breadSlice.SetActive(true);

            GameObject[] _birdColliders = GameObject.FindGameObjectsWithTag("birdCollision");
            foreach (GameObject _birdCollider in _birdColliders)
                Destroy(_birdCollider);
        }

        if (atKey && Input.GetKeyDown(KeyCode.Space))
        {
            hasKey = true;
            GameObject key = GameObject.FindGameObjectWithTag("key");
            Destroy(key);
        }

        if (hasKey && Input.GetKeyDown(KeyCode.Space) && atDoor)
        {
            _door.SetActive(true);
            openDoor = true;
            hasKey = false;
        }
        else if (openDoor && Input.GetKeyDown(KeyCode.Space) && atDoor)
        {
            SceneManager.LoadScene(2);
        }

    }

    private void FixedUpdate()
    {
        //borders
        Vector2 newPosition = playerRb.position + _movement * playerSpeed;
        Vector2 position = new Vector2(Mathf.Clamp(newPosition.x, limitLeft, limitRight), Mathf.Clamp(newPosition.y, limitBottom, limitTop));
        playerRb.MovePosition(position);

        _previousPosition = playerRb.position;
    }
}
