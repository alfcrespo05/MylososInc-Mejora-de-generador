using JetBrains.Annotations;
using UnityEngine;

public class SpawnGildas : MonoBehaviour
{
    public GameObject food;
    public GameObject leftBorder;
    public GameObject rightBorder;
    public GameObject bottomBorder;
    public GameObject topBorder;
    float minPosX, maxPosX, minPosY, maxPosY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float foodSizeX = food.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float foodSizeY = food.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        minPosX = leftBorder.transform.position.x + leftBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 + foodSizeX / 2;
        maxPosX = rightBorder.transform.position.x - rightBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 - foodSizeX / 2;
        minPosY = bottomBorder.transform.position.y + bottomBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 + foodSizeY / 2;
        maxPosY = topBorder.transform.position.y - topBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 - foodSizeY / 2;

        food.SetActive(true);
        Spawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void Comido()
    {
        food.SetActive(false);
        Invoke("Spawn", 1f);
    }
    void Spawn()
    {
        float posX = Random.Range(minPosX, maxPosX);
        float posY = Random.Range(minPosY, maxPosY);
        Vector2 randomPos = new Vector2(posX, posY);
        Instantiate(food, randomPos, Quaternion.identity, transform);
    }
}
