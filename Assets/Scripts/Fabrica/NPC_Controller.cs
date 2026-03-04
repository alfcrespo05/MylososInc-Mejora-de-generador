
using System.Collections.Generic;

using UnityEngine;



public class NPC_Controller : MonoBehaviour
{
    public float maxEmotion = 100;
    public float curEmotion;
    public float panicMultiplier = 1;


    public Node currentNode;
    public List<Node> path = new List<Node>();

    public enum StateMachine
    {
        Patrol,
        Engage,
        Evade
    }

    public StateMachine currentState;

    //public PlayerController player;
    [SerializeField] public GameObject destino;
    public float speed = 3f;

    private void Start()
    {
        curEmotion = maxEmotion;
    }

    private void Update()
    {
        switch (currentState)
        {
            case StateMachine.Patrol:
                Patrol();
                break;
            case StateMachine.Engage:
                Engage();
                break;
            case StateMachine.Evade:
                Evade();
                break;
        }
        curEmotion -= Time.deltaTime;
        bool playerSeen = Vector2.Distance(transform.position, destino.transform.position) < 5.0f;

        if (!playerSeen && currentState != StateMachine.Patrol && curEmotion > (maxEmotion * 40) / 100)
        {
            currentState = StateMachine.Patrol;
            path.Clear();
        }
        else if (playerSeen && currentState != StateMachine.Engage && curEmotion > (maxEmotion * 40) / 100)
        {
            currentState = StateMachine.Engage;
            path.Clear();
        }
        else if (playerSeen && currentState != StateMachine.Evade && curEmotion <= (maxEmotion * 40) / 100)
        {
            panicMultiplier = 1;
            currentState = StateMachine.Evade;
            path.Clear();
        }
        else if (currentState != StateMachine.Evade && curEmotion <= (maxEmotion * 10) / 100)
        {
            panicMultiplier = 2;
            currentState = StateMachine.Evade;
            path.Clear();
        }

        CreatePath();
    }

    void Patrol()
    {
        if (path.Count == 0 && currentNode != null)
        {
            Node target = AStarManager.instance.AllNodes()[Random.Range(0, AStarManager.instance.AllNodes().Length)];
            if (target != currentNode)
                path = AStarManager.instance.GeneratePath(currentNode, target);
        }
    }


    void Engage()
    {
        if (path.Count == 0)
        {
            path = AStarManager.instance.GeneratePath(currentNode, AStarManager.instance.FindNearestNode(destino.transform.position));
        }
    }

    void Evade()
    {
        if (path.Count == 0)
        {
            path = AStarManager.instance.GeneratePath(currentNode, AStarManager.instance.FindFurthestNode(destino.transform.position));
        }
    }

    public void CreatePath()
    {
        if (path.Count == 0) return;

        Node target = path[0];

        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(target.transform.position.x, target.transform.position.y, -2),
            (speed * panicMultiplier) * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target.transform.position) < 0.1f)
        {
            currentNode = target;
            path.RemoveAt(0);
        }
    }

}
