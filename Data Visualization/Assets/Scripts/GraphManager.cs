using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    [SerializeField]
    private IGraph graph;

    [SerializeField]
    private GameObject graphParent;

    [SerializeField]
    private List<List<float>> data;

    private void Start()
    {
        graphParent.SetActive(false);
        graph?.InitializeGraph(data);
    }

    public void SwitchGraphs(IGraph newGraph)
    {
        if (graph == null)
        {
            graph = newGraph;
            return;
        }
        
        graph.DeleteGraph();
        newGraph.InitializeGraph(data);
    }

    public void SetGraphsActive(bool active)
    {
        graphParent.SetActive(active);
    }
}
