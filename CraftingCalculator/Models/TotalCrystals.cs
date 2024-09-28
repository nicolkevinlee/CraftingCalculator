using CraftingCalculator.Data;
using CraftingCalculator.Enums;

namespace CraftingCalculator.Models;

public class TotalCrystals
{
    private Crystal _crystalType;
    private Dictionary<Element, Item> _items;

    public string? Name { set; get; }
    public ushort FireCount { set; get; }
    public ushort EarthCount { set; get; }
    public ushort IceCount { set; get; }
    public ushort WindCount { set; get; }
    public ushort LightningCount { set; get; }
    public ushort WaterCount { set; get; }

    public TotalCrystals(Crystal type)
    {
        _crystalType = type;
        Name = _crystalType.ToString();
        var dbController = new DatabaseController();
        _items = dbController.GetAllCrystals()[_crystalType];
    }

    public void SetShardCount(TotalIngredient totalIngredient)
    {
        switch (GetIngredientCyrstalElement(totalIngredient))
        {
            case Element.Fire: FireCount += totalIngredient.Count; break;
            case Element.Earth: EarthCount += totalIngredient.Count; break;
            case Element.Ice: IceCount += totalIngredient.Count; break;
            case Element.Water: WaterCount += totalIngredient.Count; break;
            case Element.Wind: WindCount += totalIngredient.Count; break;
            case Element.Lightning: LightningCount += totalIngredient.Count; break;
        }
    }

    private Element GetIngredientCyrstalElement(TotalIngredient totalIngredient)
    {
        var crystalElement = Element.None;

        foreach (var kvp in _items)
        {
            if (kvp.Value.Id == totalIngredient.Item.Id)
            {
                crystalElement = kvp.Key;
                break;
            }
        }

        return crystalElement;
    }

    public void Clear()
    {
        FireCount = 0;
        EarthCount = 0;
        IceCount = 0;
        WindCount = 0;
        LightningCount = 0;
        WaterCount = 0;
    }


}
