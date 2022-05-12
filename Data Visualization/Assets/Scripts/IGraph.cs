using System.Collections.Generic;

public interface IGraph
{
    public void InitializeGraph(IList<IList<float>> data);

    public void UpdateGraphValues(IList<IList<float>> data);

    public void DeleteGraph();
}
