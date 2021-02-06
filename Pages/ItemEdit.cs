using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TodoClient.Models;
using TodoClient.Services;

namespace TodoClient.Pages
{
    public partial class ItemEdit
    {
        protected string Message = string.Empty;

        protected bool Saved;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ITodoDataService TodoDataService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public ItemData Item { get; set; } = new ItemData();

        protected async override Task OnInitializedAsync()
        {
            Saved = false;
            if (!string.IsNullOrEmpty(Id))
            {
                var itemId = Convert.ToInt32(Id);
                Item = await TodoDataService.GetItemDetail(itemId);
            }

        }

        protected async Task HandleValidRequest()
        {
            if (string.IsNullOrEmpty(Id))
            {
                var res = await TodoDataService.AddItem(Item);
                if (res != null)
                {
                    Saved = true;
                    Message = "Item has been added!";
                }
                else
                {
                    Message = "Something went wrong!";
                }
            }
            else
            {
                await TodoDataService.UpdateItem(Item);
                Saved = true;
                Message = "Item has been updated!";
            }
        }

        protected void HandleInvalidRequest(){
            Message="Failed to submit form!";
        }

        protected void goToOverView(){
            NavigationManager.NavigateTo(nameof(ItemOverView));

        }

        protected async void DeleteItem(){
            if(!String.IsNullOrEmpty(Id)){
                var itemId=Convert.ToInt32(Id);
                await TodoDataService.DeleteItem(itemId);
                NavigationManager.NavigateTo(nameof(ItemOverView));

            }

            Message="Something went wrong, unable to delete";
        }


    }
}