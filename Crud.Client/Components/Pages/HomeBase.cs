using Microsoft.AspNetCore.Components;
using Crud.Client.Services.Contracts;

namespace Crud.Client.Components.Pages
{
    public class HomeBase : ComponentBase
    {
        [Inject] public IItemService itemService { get; set; }


        private string? responseData;

        protected override async Task OnInitializedAsync()
        {
            responseData = await Getdata();
        }


        public async Task<string> Getdata()
        {
            try
            {
                var response = await itemService.GetConn();
                if (response != null)
                {
                    return response;
                }
                return "No data available"; // Ensure all paths return a value
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

    }
}
