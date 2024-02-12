using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVP.Model
{
    public class ChooseLabaService : IChooseLabaService
    {
        public bool StartLab(int LabPart)
        {
            return (LabPart < 3) && (LabPart > -1);                
        }
    }
}
