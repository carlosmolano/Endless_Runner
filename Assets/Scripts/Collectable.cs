using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    
    public int collectableAmm = 0;
    public float velocity;
	public int pickUpIndex;


	private void Start()
	{
	}


	// Update is called once per frame
	void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * velocity, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
			GameManager.Instance.GetCollectable(collectableAmm,pickUpIndex);
			Destroy(gameObject);
        }
    }
}
