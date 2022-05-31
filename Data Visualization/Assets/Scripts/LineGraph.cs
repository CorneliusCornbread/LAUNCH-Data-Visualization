using System.Collections.Generic;
using UnityEngine;

namespace LAUNCH.Visualization
{
    public class LineGraph : Graph
    {
        public override void InitializeGraph(List<List<float>> data)
        {
            base.InitializeGraph(data);
            
            Vector3 newPos = Vector3.zero;

            List<LineRenderer> previousLines = null;

            for (int i = 0; i < data.Count; i++)
            {
                List<LineRenderer> lines = new List<LineRenderer>(data.Count);

                GameObject previousSpawn = null;

                newPos.z += spawnPrefab.transform.localScale.x * 1.5f;
                newPos.x = 0;

                for (int j = 0; j < data[i].Count; j++)
                {
                    float value = data[i][j];
                    GameObject spawn = Instantiate(spawnPrefab, transform);

                    newPos.y = value;
                    spawn.transform.localPosition = newPos;
                    newPos.x += spawnPrefab.transform.localScale.x * 1.5f;

                    LineRenderer line = spawn.GetComponent<LineRenderer>();
                    lines.Add(line);
                    
                    Vector3 position = spawn.transform.position;
                    line.SetPosition(0, position);
                    line.SetPosition(1, position);
                    line.SetPosition(2, position);
                    line.SetPosition(3, position);

                    if (previousSpawn != null)
                    {
                        line.SetPosition(0, previousSpawn.transform.position);
                        line.SetPosition(1, spawn.transform.position);
                    }

                    previousSpawn = spawn;
                }
                
                if (previousLines != null)
                {
                    for (int j = 0; j < previousLines.Count && j < lines.Count; j++)
                    {
                        LineRenderer previousLine = previousLines[j];
                        
                        previousLine.SetPosition(2, previousLine.transform.position);
                        previousLine.SetPosition(3, lines[j].transform.position);
                    }
                }

                previousLines = lines;
            }
        }

        public override bool RequiresRedrawOnMove()
        {
            return true;
        }
    }
}
