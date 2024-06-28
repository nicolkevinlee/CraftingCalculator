using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingCalculator.DTOs;

public class TotalShards
{
    private static readonly uint[] _fireIds = { 4, 1395, 1427 };
    private static readonly uint[] _earthIds = { 7, 1400, 1430 };
    private static readonly uint[] _iceIds = { 231, 1455, 1487 };
    private static readonly uint[] _windIds = { 357, 1515, 1538 };
    private static readonly uint[] _lightningIds = { 508, 1597, 1628 };
    private static readonly uint[] _waterIds = { 975, 1758, 1771 };

    public static readonly int SHARD_INDEX = 0;
    public static readonly int CRYSTAL_INDEX = 1;
    public static readonly int CLUSTER_INDEX = 2;

    private int _selectedIndex;

    public string? Name { set; get; }
    public ushort FireCount { set; get; }
    public ushort EarthCount { set; get; }
    public ushort IceCount { set; get; }
    public ushort WindCount { set; get;}
    public ushort LightningCount { set; get; }
    public ushort WaterCount { set; get; }

    public TotalShards(int nameIndex)
    {
        _selectedIndex = nameIndex;
        if (_selectedIndex == 0) Name = "Shards";
        else if (_selectedIndex == 1) Name = "Crystals";
        else if (_selectedIndex == 2) Name = "Clusters";
    }

    public void SetShardCount(TotalIngredient totalIngredient)
    {
        if (_fireIds[_selectedIndex] == totalIngredient.ItemDTO.Id) FireCount += totalIngredient.Count;
        if (_earthIds[_selectedIndex] == totalIngredient.ItemDTO.Id) EarthCount += totalIngredient.Count;
        if (_iceIds[_selectedIndex] == totalIngredient.ItemDTO.Id) IceCount += totalIngredient.Count;
        if (_windIds[_selectedIndex] == totalIngredient.ItemDTO.Id) WindCount += totalIngredient.Count;
        if (_lightningIds[_selectedIndex] == totalIngredient.ItemDTO.Id) LightningCount += totalIngredient.Count;
        if (_waterIds[_selectedIndex] == totalIngredient.ItemDTO.Id) WaterCount += totalIngredient.Count;
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
