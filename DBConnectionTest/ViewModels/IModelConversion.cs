using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectionTest.ViewModels
{
    public interface IModelConversion
    {
        object ReturnEntityModel(object obj);
        object ReturnModel(object obj);
    }
}
