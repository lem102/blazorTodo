using Microsoft.AspNetCore.Components;
using TodoClient.Models;

namespace TodoClient.Pages;

public partial class ItemDetail : ComponentBase
{
    [Parameter]
    public string Id { get; set; }

    public ItemData Item { get; set; } = new();

    private void InitializeItem()
    {
        Item = new()
        {
            Description = "Go get bread",
            IsDone = false,
            Id = 1,
            Title = "food shopping"
        };
    }

    protected override Task OnInitializedAsync()
    {
        InitializeItem();
        return base.OnInitializedAsync();
    }
}
