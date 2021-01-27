using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class PedAI : MonoBehaviour
{
    
    private PedDestinationManager manager;
    private NavMeshAgent agent;
    private SpriteRenderer childSprite;
    [SerializeField]
    public List<Sprite> Sprites = new List<Sprite>();

    public int DestinationIndex;
    private float weight;
    public Transform CurrentDestinationTransform;

    // Start is called before the first frame update
    private void Awake()
    {
        manager = FindObjectOfType<PedDestinationManager>();
        agent = transform.GetComponent<NavMeshAgent>();
        childSprite = gameObject.GetComponentInChildren<SpriteRenderer>();


        childSprite.sprite = Sprites[Random.Range(0, Sprites.Count - 1)];

        foreach(Transform child in transform)
        {
            float random = Random.Range(1.5f, 3.5f);
            child.localScale = new Vector3(random, random);
        }


        // Update is called once per frame
    }

    private void Update()
    {
        
        if(CurrentDestinationTransform == null)
        {
            agent.stoppingDistance = Random.Range(.3f, 1f);
            agent.speed = Random.Range(2, 4);
            var index = GenerateNewIndex();
            CurrentDestinationTransform = manager.Destinations[index];
            agent.SetDestination(CurrentDestinationTransform.position);
            
        }

        //Debug.Log("Destination 0: " + manager.Destinations[0]);
        //("Destinations Count" + manager.Destinations.Count);

        if(Vector3.Distance(transform.position, manager.Destinations[DestinationIndex].position) <= agent.stoppingDistance)
        {
            var index = GenerateNewIndex();
            CurrentDestinationTransform = manager.Destinations[index];
            agent.SetDestination(manager.Destinations[index].position);
            agent.stoppingDistance = Random.Range(.3f, 1f);

        }
        
    }

    private int GenerateNewIndex()
    {
        if (manager.Destinations.Count != 0)
        {
            DestinationIndex = Random.Range(0, manager.Destinations.Count - 1);
            //Debug.Log("random number - " + DestinationIndex);
        }

        return DestinationIndex;
    }
}