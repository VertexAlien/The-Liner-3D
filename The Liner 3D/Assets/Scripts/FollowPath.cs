using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    [SerializeField] GameObject[] ShatteredPlayer;
    [SerializeField] Animator FlashEffectAnim;
    [SerializeField] PathCreator pathCreator;
    [SerializeField] EndOfPathInstruction end;
    [SerializeField] float speed = 5;
    [SerializeField] float radius = 5f;
    [SerializeField] float force = 100f;
    [SerializeField] Material[] materials;
    [SerializeField] int ColorNo;
    
    


    private Material S_material;
    private float distanceTravelled;
    private Renderer rend;
    private Vector3 cubeSize;


    void Start()
    {
        rend = GetComponent<Renderer>();
        transform.position = pathCreator.path.GetPoint(0);
        cubeSize = transform.localScale;
    }

    

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Movement();
        }
    }

    void Movement()
    {
        distanceTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, end);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Color Change"))
        {
            FlashEffectAnim.Play("FlashEffect");
            SetColor();
            Destroy(other.gameObject);
        }

        else if(other.tag == "Finish")
        {
            FindObjectOfType<GameManager>().LevelEnd();
        }

        
        else if (other.tag != this.tag)
        {
            ChooseBrokenCube();

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider nearByObject in colliders)
            {
                Rigidbody rb = nearByObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force, transform.position, radius);
                }
            }

            gameObject.SetActive(false);
            FindObjectOfType<GameManager>().EndGame();
        }
    
    }


    void SetColor()
    {
        int index = Random.Range(0, 3);

        while(ColorNo == index)
        {
            index = Random.Range(0, 3);
        }

        switch(index)
        {
            case 0:
                this.tag = "Red";
                rend.sharedMaterial = materials[0];
                ColorNo = 0;
                break;
            case 1:
                this.tag = "Blue";
                rend.sharedMaterial = materials[1];
                ColorNo = 1;
                break;
            case 2:
                this.tag = "Yellow";
                rend.sharedMaterial = materials[2];
                ColorNo = 2;
                break;
                
        }

    }

    void ChooseBrokenCube()
    {
        if(this.tag == "Red")
        {
            GameObject brokenCube = Instantiate(ShatteredPlayer[0], transform.position, transform.rotation)as GameObject;
            brokenCube.transform.localScale = cubeSize/2;

        }
        else if (this.tag == "Blue")
        {
            GameObject brokenCube = Instantiate(ShatteredPlayer[1], transform.position, transform.rotation)as GameObject;
            brokenCube.transform.localScale = cubeSize/2;

        }
        else if (this.tag == "Yellow")
        {
            GameObject brokenCube = Instantiate(ShatteredPlayer[2], transform.position, transform.rotation)as GameObject;
            brokenCube.transform.localScale = cubeSize/2;
        }
    }

    
}
