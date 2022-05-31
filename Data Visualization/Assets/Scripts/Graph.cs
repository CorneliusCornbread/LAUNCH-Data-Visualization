using System.Collections.Generic;
using UnityEngine;

namespace LAUNCH.Visualization
{
    public abstract class Graph : MonoBehaviour
    {
        [SerializeField]
        protected GameObject spawnPrefab;

        public bool IsInitialized { get; protected set; }

        public virtual void InitializeGraph(List<List<float>> data)
        {
            IsInitialized = true;
        }

        public virtual void UpdateGraphValues(List<List<float>> data)
        {
            DeleteGraph();

            InitializeGraph(data);
        }

        public virtual void DeleteGraph()
        {
            IsInitialized = false;

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public virtual bool RequiresRedrawOnMove()
        {
            return false;
        }
        
#if UNITY_EDITOR
        [ContextMenu("Make Graph Active")]
        public void MakeMeActive()
        {
            GraphManager manager = FindObjectOfType<GraphManager>();
            
            manager.SwitchAndEnableGraph(this);
        }
#endif
    }
}
