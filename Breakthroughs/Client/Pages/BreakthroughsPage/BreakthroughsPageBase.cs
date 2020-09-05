using Breakthroughs.Client.Services;
using Breakthroughs.Shared.Dtos;
using Breakthroughs.Shared.Utility;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breakthroughs.Client.Pages.BreakthroughsPage
{
    public class BreakthroughsPageBase : ComponentBase
    {
        [Inject]
        private NavigationManager Navigation { get; set; }
        [Inject]
        private IJSRuntime JS { get; set; }
        [Inject]
        private INinjaService NinjaService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public List<NinjaReadDto> NinjaList { get; set; }
        public List<NinjaReadDto> FilteredList { get; set; }
        public NinjaReadDto NinjaModel { get; set; }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                FilterNinjas();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadNinjaList();
            SelectDefaultNinja();
        }

        protected override void OnParametersSet()
        {
            if (Id != null)
            {
                var selected = FilteredList.FirstOrDefault(i => i.Id.ToLower() == Id.ToLower());

                if (selected != null)
                {
                    selected.IsSelected = true;
                    NinjaModel = selected;
                }
            }
        }

        protected async Task LoadNinjaList()
        {
            NinjaList = await NinjaService.GetNinjaList();

            FilteredList = NinjaList;
        }

        protected void SelectNinja(string name)
        {
            var previous = FilteredList.FirstOrDefault(i => i.IsSelected == true);
            DeselectPrevious();

            var selected = FilteredList.FirstOrDefault(i => i.Name == name);
            selected.IsSelected = true;

            JS.InvokeVoidAsync("nSelected", selected.Name, previous.Name);

            Navigation.NavigateTo($"ninjas/{selected.Id}");
        }

        protected void SelectDefaultNinja()
        {
            NinjaModel = FilteredList.FirstOrDefault();
            NinjaModel.IsSelected = true;

            JS.InvokeVoidAsync("nSelected", NinjaModel.Name);
        }

        protected void DeselectPrevious()
        {
            var previous = FilteredList.FirstOrDefault(i => i.IsSelected == true);

            if (previous != null)
            {
                previous.IsSelected = false;
            }
        }

        protected void FilterNinjas()
        {
            var selected = FilteredList.FirstOrDefault(i => i.IsSelected == true);

            if (selected != null)
                selected.IsSelected = false;

            FilteredList = NinjaList
                      .Where(i => i.Name.ToLower()
                      .Contains(SearchTerm.ToLower()))
                      .ToList();

            selected = FilteredList.FirstOrDefault(n => n == NinjaModel);

            if (selected != null)
                selected.IsSelected = true;

            StateHasChanged();
        }
    }
}
