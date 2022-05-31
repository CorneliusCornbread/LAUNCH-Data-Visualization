using System.Collections.Generic;
using UnityEngine;

namespace LAUNCH.Visualization
{
    public class ScatterPlot : Graph
    {
        public override void InitializeGraph(List<List<float>> data)
        {
            base.InitializeGraph(data);

            Vector3 spawnPos = Vector3.zero;

            foreach (List<float> row in data)
            {
                spawnPos.z += spawnPrefab.transform.localScale.z * 1.5f;
                spawnPos.x = 0;
                
                foreach (float value in row)
                {
                    GameObject spawn = Instantiate(spawnPrefab, transform);
                    
                    spawnPos.y = value;
                    spawn.transform.localPosition = spawnPos;
                    
                    spawnPos.x += spawnPrefab.transform.localScale.x * 1.5f;

                }
            }
        }
    }
}
