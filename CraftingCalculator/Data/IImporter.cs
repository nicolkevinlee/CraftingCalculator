namespace CraftingCalculator.Data;

public interface IImporter
{
    void ImportRecipesToDb(List<string[]> rawData);
}