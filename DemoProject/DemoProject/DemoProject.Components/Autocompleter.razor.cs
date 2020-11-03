using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DemoProject.Components
{
    public partial class Autocompleter<TItem>
    {
        public string Query { get; set; }

        [Parameter]
        public IEnumerable<AutocompleterItem> Data { get; set; }

        public List<AutocompleterItem> Suggestions { get; set; }

        [Parameter]
        public RenderFragment<AutocompleterItem> ItemTemplate { get; set; }

        [Parameter]
        public EventCallback OnSelectCallback { get; set; }

        public void Autocomplete(KeyboardEventArgs e)
        {
            if (new string[] { "ArrowDown", "ArrowUp" }.Contains(e.Key))
            {
                return;
            }

            if (Query == null || Data == null)
            {
                Suggestions = null;
                return;
            }

            Suggestions = new List<AutocompleterItem>();

            foreach (var item in Data)
            {
                if (item.Text.ToLower().Contains(Query.ToLower()))
                {
                    Suggestions.Add(item);
                }
            }
        }

        public void HandleKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "ArrowDown")
            {
                Next();
            }
            else if(e.Key == "Enter")
            {
                Select();
            }
        }

        public void Next()
        {
            for (int i = 0; i < Suggestions.Count; i++)
            {
                if (Suggestions[i].IsHighlighted)
                {
                    Suggestions[i].IsHighlighted = false;
                    Suggestions[(i + 1) % Suggestions.Count].IsHighlighted = true;
                    return;
                }
            }

            Suggestions[0].IsHighlighted = true;
        }

        public void Select()
        {
            var item = Suggestions.Single(x => x.IsHighlighted).Item;
            OnSelectCallback.InvokeAsync(new AutocompleterEventArgs<TItem>()
            {
                Item = item
            });
        }

        public class AutocompleterItem
        {
            public string Text { get; set; }

            public TItem Item { get; set; }

            public bool IsHighlighted { get; set; }
        }
    }

    public class AutocompleterEventArgs<T> : EventArgs
    {
        public T Item { get; set; }
    }
}