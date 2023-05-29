using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestPDF.Infrastructure;

namespace TestingPDF_Generation.Interfaces
{
    public interface IComponent
    {
        void Compose(IContainer container);
    }
}
