

using System.Collections.Generic;

using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;
    [SerializeField] private Node _nodePrefab;
    public List<Walker> walkers;
    public int maxWalkers = 10;
   
    public NPC_Controller npc;
    private bool canDrawGizmos;

    [SerializeField] private Transform _cam;

    private Dictionary<Vector2, Tile> _tiles;
    private Dictionary<Vector2, Node> _nodes;

   // public GameObject preuba;

    
    
    void Start()
    {
        GenerateGrid();
        CreateConnections();
        SpawnAI();
    }

    void GenerateGrid()
    {
        _tiles = new Dictionary<Vector2, Tile>();
        _nodes = new Dictionary<Vector2, Node>();
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                var spawnedNode = Instantiate(_nodePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedNode.name = $"Node {x} {y}";

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                var isOffsetN = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedNode.Init(isOffsetN);


                _tiles[new Vector2(x, y)] = spawnedTile;
                _nodes[new Vector2(x, y)] = spawnedNode;
            }
        }

        _cam.transform.position = new Vector3((float)_width / 2 - 0.5f, (float)_height / 2 - 0.5f, -10);

    }

    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        
        return null;
       
    }
    public Node GetNodeAtPosition(Vector2 pos)
    {
        
        if (_nodes.TryGetValue(pos, out var node)) return node;
        return null;

    }
    void CreateConnections()
    {
        float maxDistanceSquared = 1.0f * 1.0f; // Max distance squared (1.0f * 1.0f = 1.0f)

        // Loop over each node and connect with neighbors to the right and top
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                Vector2 position = new Vector2(x, y);

                // Get current node
                if (!_nodes.ContainsKey(position)) continue;
                Node nodeA = _nodes[position];

                // Connect with neighbor to the right
                Vector2 right = new Vector2(x + 1, y);
                if (_nodes.ContainsKey(right) && (right - position).sqrMagnitude <= maxDistanceSquared)
                {
                    Node nodeB = _nodes[right];
                    ConnectNodes(nodeA, nodeB);
                    ConnectNodes(nodeB, nodeA);
                }

                // Connect with neighbor above
                Vector2 up = new Vector2(x, y + 1);
                if (_nodes.ContainsKey(up) && (up - position).sqrMagnitude <= maxDistanceSquared)
                {
                    Node nodeB = _nodes[up];
                    ConnectNodes(nodeA, nodeB);
                    ConnectNodes(nodeB, nodeA);
                }
            }
        }

        canDrawGizmos = true;
    }



    void ConnectNodes(Node from, Node to)
    {
        if (from == to) { return; }

        from.connections.Add(to);
    }
    void OnDrawGizmos()
    {
        if (canDrawGizmos)
        {
            Gizmos.color = Color.green;
            foreach (var node in _nodes.Values)
            {
                Gizmos.DrawWireSphere(node.transform.position, 0.2f);
                foreach (var connection in node.connections)
                {
                    Gizmos.DrawLine(node.transform.position, connection.transform.position);
                }
            }
        }
    }
    void SpawnAI()
    {
        List<Node> nodeList = new List<Node>(_nodes.Values);

        Node randNode = nodeList[UnityEngine.Random.Range(0, nodeList.Count)];
        NPC_Controller newNPC = Instantiate(npc, randNode.transform.position, Quaternion.identity);

        newNPC.currentNode = randNode;
        //newNPC.destino = preuba;
    }
   




}

