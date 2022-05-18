using System.Collections.Generic;

public interface IGraph
{
    public bool IsInitialized();
    
    public void InitializeGraph(List<List<float>> data);

    public void UpdateGraphValues(List<List<float>> data);

    public void DeleteGraph();
}
