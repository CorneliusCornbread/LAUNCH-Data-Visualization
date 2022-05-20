using System.Collections.Generic;
using UnityEngine;

namespace LAUNCH.Visualization
{
    public class GraphManager : MonoBehaviour
    {
        [SerializeField, SerializeReference]
        private Graph graph;

        [SerializeField]
        private GameObject graphParent;

        [SerializeField]
        private List<List<float>> data;

        private void Start()
        {
            graphParent.SetActive(false);
            graph?.InitializeGraph(data);
        }

        public void SwitchGraphs(Graph newGraph)
        {
            if (graph == null)
            {
                graph = newGraph;
                return;
            }

            graph.DeleteGraph();

            graph = newGraph;
            graph.InitializeGraph(data);
        }

        public void SetGraphsActive(bool active)
        {
            graphParent.SetActive(active);
        }
    }
}
