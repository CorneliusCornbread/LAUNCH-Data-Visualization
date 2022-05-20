using System;
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

        private const float PositionRange = 10;

        [SerializeField]
        [Range(-.01f, .2f)]
        [Header("Scale min/max")]
        private float maxScale = .2f;
        
        [SerializeField]
        [Range(-.01f, .2f)]
        private float minScale = .01f;

        [SerializeField]
        [Range(-PositionRange, PositionRange)]
        [Header("Position min/max")]
        private float maxHoriz = 1;
        
        [SerializeField]
        [Range(-PositionRange, PositionRange)]
        private float minHoriz = -1;
        
        [SerializeField]
        [Range(-PositionRange, PositionRange)]
        private float maxVert = 1;
        
        [SerializeField]
        [Range(-PositionRange, PositionRange)]
        private float minVert = -1;
        
        private List<List<float>> _data;

        private void Start()
        {
            graphParent.SetActive(false);

            if (graph != null)
            {
                graph.InitializeGraph(_data);
            }
        }

        public void SwitchAndEnableGraph(Graph newGraph)
        {
            SwitchGraphs(newGraph);
            SetGraphsActive(true);
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
            
            if (_data == null)
                return;
            
            graph.InitializeGraph(_data);
        }

        public void SetGraphsActive(bool active)
        {
            graphParent.SetActive(active);
        }

        public void ToggleGraphsActive()
        {
            graphParent.SetActive(!graphParent.activeSelf);
        }

        public void UpdateData(List<List<float>> newData)
        {
            // Clone list
            _data = new List<List<float>>(newData.Count);

            foreach (List<float> lists in newData)
            {
                List<float> row = new List<float>(lists);
                _data.Add(row);
            }
            
            if (graph == null)
                return;
            
            graph.DeleteGraph();
            graph.InitializeGraph(_data);
        }

        public void MoveActiveGraphHorizontal(float value)
        {
            Vector3 pos = graph.transform.localPosition;

            pos.x = Mathf.Lerp(minHoriz, maxHoriz, value);

            graph.transform.localPosition = pos;
        }
        
        public void MoveActiveGraphVertical(float value)
        {
            Vector3 pos = graph.transform.localPosition;

            pos.y = Mathf.Lerp(minVert, maxVert, value);

            graph.transform.localPosition = pos;
        }

        public void OnScaleChange(float value)
        {
            float newScale = Mathf.Lerp(minScale, maxScale, value);

            graph.transform.localScale = new Vector3(newScale, newScale, newScale);
        }
    }
}
