using pr2.Enums;
using pr2.Services;
using pr2.Systems.Args;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static pr2.Services.DisplayService;

namespace pr2.Systems
{
    public class Display
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Name { get; set; }

        public event EventHandler<DisplayEventArgs> DisplayChanged;

        public Display(string name, DisplayService displayService)
        {
            Name = name;
            displayService.DisplayUpdated += ShowInformation;
        }

        public void ShowInformation(object? sender, DisplayEventArgs e)
        {
            DisplayChanged?.Invoke(this, e);
        }
    }
}
