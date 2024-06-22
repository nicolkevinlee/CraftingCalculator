namespace CraftingCalculator.DataAccessor;

public interface IDataAccessor
{
    List<string[]> Read(string filePath);
}
