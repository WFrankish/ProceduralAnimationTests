using UnityEngine;

public class SwivelPair : MonoBehaviour
{

    private Rigidbody _self;

    public Rigidbody Other;

    public float Stiffness;

    public float RestAngleX;
    public float RestAngleZ;

    // Use this for initialization
    void Start()
    {
        _self = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = _self.transform.InverseTransformVector(Other.transform.position);
        float offsetX = Vector3.Angle(Vector3.forward, offset);
        float offsetZ = Vector3.Angle(Vector3.right, offset);

        float diffX = RestAngleX - offsetX;
        float diffZ = RestAngleZ - offsetZ;

        _self.AddForce(_self.transform.right * diffX / 2f);
        Other.AddForce(-_self.transform.right * diffX / 2f);

        _self.AddForce(_self.transform.forward * diffZ / 2f);
        Other.AddForce(-_self.transform.forward * diffZ / 2f);
    }
}
