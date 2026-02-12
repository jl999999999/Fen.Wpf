using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Fen.Wpf.Entity
{
    class VacationSpots : ObservableCollection<string>
    {
        public VacationSpots()
        {

            Add("Spain");
            Add("France");
            Add("Peru");
            Add("Mexico");
            Add("Italy");
        }
    }
}
