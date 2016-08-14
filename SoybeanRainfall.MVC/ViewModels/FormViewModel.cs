using SoybeanRainfall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoybeanRainfall.MVC.ViewModels
{
    public class FormViewModel
    {
        public IEnumerable<State> States { get; set; }
        public string EmptySelectionItem { get; set; }
        public State SelectedState { get; set; }
        public IEnumerable<County> Counties { get; set; }
        public County SelectedCounty { get; set; }
    }
}