using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private float timeInterval = 20.0f;
    [SerializeField] private float arrowSpeed = -1.0f;
    private float currentTime = 0f;
    private Vector3 creatorLocation;

    void Start()
    {
        this.creatorLocation = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.currentTime += Time.deltaTime;
        if (currentTime > timeInterval)
        {
            currentTime = 0f;
            var arrow = Instantiate(arrowPrefab, creatorLocation, Quaternion.identity);
            var rigidBody = arrow.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, arrowSpeed);

            }
        }
    }
}