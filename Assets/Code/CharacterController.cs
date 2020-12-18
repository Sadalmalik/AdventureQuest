using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera camera;
    public LineRenderer lineRenderer;
    
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            MoveCommand();
        }
        
        if (lineRenderer!=null && agent.path !=null)
        {
            var points = agent.path.corners.ToList();
            points.Add(agent.pathEndPosition);
            lineRenderer.SetPositions(points.ToArray());
        }
    }
    
    public void MoveCommand()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}
