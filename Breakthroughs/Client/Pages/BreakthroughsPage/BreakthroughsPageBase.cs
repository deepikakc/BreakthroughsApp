using Breakthroughs.Client.Services;
using Breakthroughs.Shared.Dtos;
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
        private IJSRuntime JS { get; set; }
        [Inject]
        private INinjaService NinjaService { get; set; }

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
            NinjaList = await NinjaService.GetNinjaList();

            FilteredList = NinjaList;

            SelectNinja("firstSelection");
        }

        protected void SelectNinja(string name)
        {
            if (name != "firstSelection")
            {
                var previous = FilteredList.FirstOrDefault(i => i.IsSelected == true);

                if (previous != null)
                {
                    previous.IsSelected = false;
                }

                var selected = FilteredList.FirstOrDefault(i => i.Name == name);
                selected.IsSelected = true;

                JS.InvokeVoidAsync("nSelected", selected.Name, previous.Name);

                NinjaModel = selected;
            }
            else
            {
                var model = FilteredList.FirstOrDefault();
                model.IsSelected = true;

                NinjaModel = model;
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
