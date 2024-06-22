using CraftingCalculator.DTOs;
using CraftingCalculator.Models;

namespace CraftingCalculator.Data;

class RecipeImporter : IImporter
{
    private List<ItemDTO> _itemDTOs;
    private List<CraftTypeDTO> _craftTypeDTOs;
    private List<RecipeDTO> _recipeDTOs;
    private List<IngredientDTO> _ingredientDTOs;

    public void ImportRecipesToDb(List<string[]> rawData)
    {
        _itemDTOs = new List<ItemDTO>();
        _craftTypeDTOs = new List<CraftTypeDTO>();
        _recipeDTOs = new List<RecipeDTO>();
        _ingredientDTOs = new List<IngredientDTO>();

        ParseCsvData(rawData);

        using(var dbContext = new CraftingDbContext())
        {
            SaveItemsToDb(dbContext);
            SaveCraftTypesToDb(dbContext);
            SaveRecipesToDb(dbContext);
        }
    }

    private void ParseCsvData(List<string[]> rawData)
    {
        foreach (var row in rawData)
        {

            var typeName = row[2].Trim();
            var recipeItemName = row[4].Trim();
            var yield = row[5].Trim();

            CraftTypeDTO? craftTypeDTO = GetCraftTypeDTOWithName(_craftTypeDTOs, typeName);
            ItemDTO? recipeItemDTO = GetItemDTOWithName(_itemDTOs, recipeItemName);

            if (craftTypeDTO == null)
            {
                craftTypeDTO = new CraftTypeDTO
                {
                    Id = (uint)_craftTypeDTOs.Count,
                    Name = typeName
                };
                _craftTypeDTOs.Add(craftTypeDTO);
            }

            if (recipeItemDTO == null)
            {
                recipeItemDTO = new ItemDTO
                {
                    Id = (uint)_itemDTOs.Count,
                    Name = recipeItemName
                };
                _itemDTOs.Add(recipeItemDTO);
            }

            RecipeDTO recipeDTO = new RecipeDTO()
            {
                Id = (uint)_recipeDTOs.Count,
                CraftTypeDTO = craftTypeDTO,
                ItemDTO = recipeItemDTO,
                Yield = uint.Parse(yield)
            };

            _recipeDTOs.Add(recipeDTO);

            for (int i = 6; i < row.Length; i += 2)
            {
                var itemName = row[i].Trim();

                if (string.IsNullOrEmpty(itemName)) break;

                var count = row[i + 1].Trim();

                ItemDTO? ingredientItem = GetItemDTOWithName(_itemDTOs, itemName);

                if (ingredientItem == null)
                {
                    ingredientItem = new ItemDTO
                    {
                        Id = (uint)_itemDTOs.Count,
                        Name = itemName
                    };
                    _itemDTOs.Add(ingredientItem);
                }

                var ingredient = new IngredientDTO
                {
                    Id = (uint)_ingredientDTOs.Count,
                    RecipeDTO = recipeDTO,
                    ItemDTO = ingredientItem,
                    Count = uint.Parse(count)
                };

                _ingredientDTOs.Add(ingredient);
            }
        }
    }

    private void SaveItemsToDb(CraftingDbContext dbContext)
    {
        foreach(var item in _itemDTOs )
        {
            if(!dbContext.Items.Any(i => i.Name == item.Name))
            {
                dbContext.Items.Add(new Item { Name = item.Name});
            }
        }
        dbContext.SaveChanges();
    }

    private void SaveCraftTypesToDb(CraftingDbContext dbContext)
    {
        foreach (var type in _craftTypeDTOs)
        {
            if (!dbContext.CraftTypes.Any(t => t.Name ==  type.Name))
            {
                dbContext.CraftTypes.Add(new CraftType { Name = type.Name });
            }
        }
        dbContext.SaveChanges();
    }

    private void SaveRecipesToDb(CraftingDbContext dbContext)
    {
        var dbRecipes = new List<Recipe>();

        for(int i = 0; i < _recipeDTOs.Count; i++)
        {
            var rawRecipe = _recipeDTOs[i];
            var recipeItem = dbContext.Items.FirstOrDefault(i => i.Name == rawRecipe.ItemDTO.Name);
            var craftType = dbContext.CraftTypes.FirstOrDefault(t => t.Name == rawRecipe.CraftTypeDTO.Name);
            if (recipeItem != null && craftType != null) {
                var dbRecipe = dbContext.Recipes.FirstOrDefault(r => r.ItemId == recipeItem.Id && r.CraftTypeId == craftType.Id);
                if (dbRecipe == null)
                {
                    dbRecipe = new Recipe
                    {
                        ItemId = recipeItem.Id,
                        CraftTypeId = craftType.Id,
                        Yield = rawRecipe.Yield
                    };
                    dbContext.Recipes.Add(dbRecipe);
                }
                dbRecipes.Add(dbRecipe);
            }
        }
        dbContext.SaveChanges();

        for(int i = 0; i < _recipeDTOs.Count; i++)
        {
            var recipeDTO = _recipeDTOs[i];
            var recipe = dbRecipes[i];

            var ingredientDTOs = _ingredientDTOs.Where( i => i.RecipeDTO.Id == recipeDTO.Id).ToArray();

            foreach(var ingredientDTO in ingredientDTOs)
            {
                Item item = dbContext.Items.First( i => i.Name == ingredientDTO.ItemDTO.Name );

                var dbIngredient = dbContext.Ingredients.FirstOrDefault(i => i.ItemId == item.Id && i.RecipeId == recipe.Id);

                if(dbIngredient == null)
                {
                    dbIngredient = new Ingredient
                    {
                        ItemId = item.Id,
                        RecipeId = recipe.Id,
                        Count = ingredientDTO.Count
                    };

                    dbContext.Ingredients.Add(dbIngredient);
                }
            }
        }
        dbContext.SaveChanges();
    }

    private CraftTypeDTO? GetCraftTypeDTOWithName(List<CraftTypeDTO> craftTypes, string craftTypeName)
    {
        return craftTypes.FirstOrDefault(t => t.Name ==  craftTypeName);
    }

    private ItemDTO? GetItemDTOWithName(List<ItemDTO> items, string itemName)
    {
        return items.FirstOrDefault(t => t.Name == itemName);
    }

    private bool ContainsCraftTypeName(List<CraftType> types, string craftTypeName)
    {
        return !types.Any(t => t.Name == craftTypeName);
    }

    private bool ContainsItemName(List<Item> items, string itemName) {
        return !items.Any(i => i.Name == itemName);
    }

    private bool IsSameRecipe(Recipe a, Recipe b)
    {
        if (IsSameCraftType(a.CraftType, b.CraftType) && 
            IsSameItem(a.Item, b.Item)) return true;
        return false;
    }

    private bool IsSameCraftType(CraftType a, CraftType b)
    {
        if (a.Name == b.Name) return true;
        return false;
    }

    private bool IsSameItem(Item a, Item b)
    {
        if (a.Name == b.Name) return true;
        return false;
    }
}
