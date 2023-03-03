using ImageGenerator.Interfaces;
using ImageGenerator.Model;

namespace ImageGenerator.Services
{
    public class ScanLineActiveEdges : IRegionFillAlgorithm
    {
        public List<Size> GetPixelsInsideRegions(List<Region> regions, Size size)
        {
            List<Size> result = new();

            Position scale = Position.GetScaleStep(size.X, size.Y);
            

            foreach (Region region in regions)
            {
                List<Edge> GlobalEdgeTable = region.GetNonHorizontalEdges().OrderBy(edge => edge.Ymin).ThenBy(edge => edge.Xvalue).ToList();
                List<Edge> ActiveEdgeTable = new();

                int currentEdge = 0;

                for (double y = region.BoundingBox.Min.Y; y <= region.BoundingBox.Max.Y; y += scale.Y)
                {
                    while (currentEdge < GlobalEdgeTable.Count && GlobalEdgeTable[currentEdge].Ymin <= y)
                    {
                        ActiveEdgeTable.Add(GlobalEdgeTable[currentEdge]);
                        currentEdge++;
                    }

                    ActiveEdgeTable.RemoveAll(edge => edge.Ymax <= y);
                    ActiveEdgeTable.Sort((e1, e2) => e1.Xvalue.CompareTo(e2.Xvalue));

                    int mappedY = size.Y + 1 - (int)Math.Ceiling(y * (size.Y - 1) + 1);
                    for (int i = 0; i < ActiveEdgeTable.Count - 1; i += 2)
                    {
                        int x1 = (int)Math.Ceiling(ActiveEdgeTable[i].Xvalue * (size.X - 1) + 1);
                        int x2 = (int)Math.Floor(ActiveEdgeTable[i + 1].Xvalue * (size.X - 1) + 1);
                        if (x1 < x2)
                        {
                            for (int x = x1; x <= x2; x++)
                            {
                                result.Add(new Size(x, mappedY));
                            }
                        }
                    }

                    foreach (Edge edge in ActiveEdgeTable)
                    {
                        edge.Xvalue += edge.Slope * scale.Y;
                    }
                }
            }

            return result;
        }
    }
}
