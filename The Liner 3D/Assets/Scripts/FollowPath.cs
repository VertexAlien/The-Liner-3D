using UnityEngine;
using UnityEngine.UI;
using PathCreation;

public class FollowPath : MonoBehaviour
{
    public GameObject[] ShatteredPlayer;
    public PathCreator pathCreator;
    public EndOfPathInstruction end;
    public float speed = 5;
    public float radius = 5f;
    public float force = 100f;
    public Material[] materials;
    public int ColorNo;
    


    Material S_material;
    float distanceTravelled;
    Renderer rend;
    


    void Start()
    {
        rend = GetComponent<Renderer>();
        transform.position = pathCreator.path.GetPoint(0);
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

            foreach(Collider nearByObject in colliders)
            {
                Rigidbody rb = nearByObject.GetComponent<Rigidbody>();
                if(rb != null)
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
            Instantiate(ShatteredPlayer[0], transform.position, transform.rotation);
        }
        else if (this.tag == "Blue")
        {
            Instantiate(ShatteredPlayer[1], transform.position, transform.rotation);
        }
        else if (this.tag == "Yellow")
        {
            Instantiate(ShatteredPlayer[2], transform.position, transform.rotation);
        }
    }

    
}
