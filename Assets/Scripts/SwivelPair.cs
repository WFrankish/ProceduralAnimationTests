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
        Vector3 offset = _self.transform.InverseTransformPoint(Other.transform.position);
        float offsetX = Mathf.Atan2(offset.z, offset.y);
        float offsetZ = Mathf.Atan2(offset.y, offset.x);

        float diffX = (Mathf.Deg2Rad * RestAngleX) - offsetX;
        float diffZ = (Mathf.Deg2Rad * RestAngleZ) - offsetZ;

        Vector3 vectorX = new Vector3(0, offset.y, -offset.x);
        _self.AddForce(vectorX * diffX * Stiffness);
        Other.AddForce(-vectorX * diffX * Stiffness);
        _self.AddTorque(vectorX * diffX * Stiffness);

        Vector3 vectorZ = new Vector3(offset.y, -offset.x, 0);
        _self.AddForce(vectorZ * diffZ * Stiffness);
        Other.AddForce(-vectorZ * diffZ * Stiffness);
        _self.AddTorque(vectorZ * diffZ * Stiffness);
    }
}
