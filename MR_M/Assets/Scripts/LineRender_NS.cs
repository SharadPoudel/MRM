using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender_NS : MonoBehaviour
{
    public LineRenderer line;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 3;
    }

    // Update is called once per frame
    void Update()
    {
          

        line.SetPosition(0, pos1.position);
        line.SetPosition(1, pos2.position);
        line.SetPosition(2, pos3.position);
        }
}
