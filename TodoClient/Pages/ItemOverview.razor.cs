using Microsoft.AspNetCore.Components;
using TodoClient.Models;

namespace TodoClient.Pages;

public partial class ItemOverview : ComponentBase
{
    public IEnumerable<ItemData> Items { get; set; }

    private void InitializeItems()
    {
        ItemData item1 = new()
        {
            Description = "Go get bread",
            IsDone = false,
            Id = 1,
            Title = "food shopping"
        };

        ItemData item2 = new()
        {
            Description = "Read books",
            IsDone = false,
            Id = 2,
            Title = "study"
        };

        Items = new List<ItemData>()
        {
            item1,
            item2
        };
    }

    protected override Task OnInitializedAsync()
    {
        InitializeItems();
        return base.OnInitializedAsync();
    }
}
