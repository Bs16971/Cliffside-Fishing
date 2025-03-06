using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FishingLineController : MonoBehaviour
{

     public Transform whatTheRopeIsConnectedTo;
     public Transform whatisHangingFromRope;

    private LineRenderer _lineRenderer;

    public List<Vector3> allRopeSections = new List<Vector3>();

    private float _ropeLength = 1f;
    private float _minRopeLength = 1f;
    private float _maxRopeLength = 20f;
    private float _loadMass = 100f;
    private float _winchSpeed = 2f;
    
    private SpringJoint _springJoint;
    
    // Start is called before the first frame update
    void Start()
    {
        _springJoint = whatTheRopeIsConnectedTo.GetComponent<SpringJoint>();

        _lineRenderer = GetComponent<LineRenderer>();

        UpdateSpring();

        whatisHangingFromRope.GetComponent<Rigidbody>().mass = _loadMass;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWinch();

        DisplayRope();
        
    }

    private void UpdateSpring()
    {
        float density = 7750f;
        float radius = 0.02f;

        float volume = Mathf.PI * radius * radius * _ropeLength;
        float ropeMass = volume * density;

        ropeMass += _loadMass;

        float ropeForce = ropeMass * 1.0f;
        float kRope = ropeForce / 0.01f;

        _springJoint.spring = kRope * 1.0f;
        _springJoint.damper = kRope * .05f;

        _springJoint.maxDistance = _ropeLength;
    }

    private void DisplayRope()
    {
        float ropeWidth = .2f;

        _lineRenderer.startWidth = ropeWidth;
        _lineRenderer.endWidth = ropeWidth;

        Vector3 A = whatTheRopeIsConnectedTo.position;
        Vector3 D = whatisHangingFromRope.position;

        Vector3 B = A + whatTheRopeIsConnectedTo.up * (-(A - D).magnitude * .1f);
        Vector3 C = D + whatisHangingFromRope.up * ((A - D).magnitude * .5f);

        BezierCurve.GetBezierCurve(A, B, C, D, allRopeSections);

        Vector3[] positions = new Vector3[allRopeSections.Count];

        for (int i = 0; i < allRopeSections.Count; i++)
        {
            positions[i] = allRopeSections[i];
        }

        _lineRenderer.positionCount = positions.Length;
        _lineRenderer.SetPositions(positions);
    }

    private void UpdateWinch()
    {
        bool hasChangedRope = false;

        if (Input.GetKey(KeyCode.I) && _ropeLength > _maxRopeLength)
        {
            _ropeLength += _winchSpeed * Time.deltaTime;
            hasChangedRope = true;
        }else if (Input.GetKey(KeyCode.I) && _ropeLength > _minRopeLength)
        {
            _ropeLength -= _winchSpeed * Time.deltaTime;
            hasChangedRope = true;
        }

        if (hasChangedRope)
        {
            _ropeLength = Mathf.Clamp(_ropeLength, _minRopeLength, _maxRopeLength);
            
            UpdateSpring();
        }
    }
}

