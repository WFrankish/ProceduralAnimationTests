using UnityEngine;

public class SpringPair : MonoBehaviour {

    private Rigidbody _self;

    public Rigidbody Other;

    public float Stiffness;

    public float RestOffset;

	// Use this for initialization
	void Start () {
        _self = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = Other.transform.position -_self.transform.position;
        Vector3 difference = offset - (offset.normalized * RestOffset);
        Vector3 force = Stiffness * difference;

        _self.AddForce(force);
        Other.AddForce(-force);
    }
}
