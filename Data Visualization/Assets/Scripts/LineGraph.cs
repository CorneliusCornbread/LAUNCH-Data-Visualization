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

            List<LineRenderer> previousLines = new List<LineRenderer>(data.Count);

            for (int i = 0; i < data.Count; i++)
            {
                List<LineRenderer> lines = new List<LineRenderer>(data.Count);

                GameObject previousSpawn = null;

                for (int j = 0; j < data[i].Count; j++)
                {
                    float value = data[i][j];
                    GameObject spawn = Instantiate(spawnPrefab, transform);

                    newPos.y = value;
                    spawn.transform.localPosition = newPos;
                    newPos.x += spawnPrefab.transform.localScale.x * 1.5f;

                    LineRenderer line = spawn.GetComponentInChildren<LineRenderer>();
                    lines.Add(line);

                    if (previousSpawn != null)
                    {
                        line.SetPosition(0, previousSpawn.transform.position);
                        line.SetPosition(1, spawn.transform.position);
                    }

                    previousSpawn = spawn;
                }

                if (previousLines != null)
                {
                    foreach (LineRenderer previousLine in previousLines)
                    {
                        foreach (LineRenderer line in lines)
                        {
                            previousLine.SetPosition(2, previousLine.transform.position);
                            previousLine.SetPosition(3, line.transform.position);
                        }
                    }
                }
            }
        }
    }
}
