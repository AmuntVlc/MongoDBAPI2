using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBAPI2.IU.Pages
{
    public class CtrlUsuarioInputSelect<TValue> : InputSelect<TValue>
    {
        protected override bool TryParseValueFromString(string value, out TValue result, out string validationErrorMessage)
        {
            if (typeof(TValue) == typeof(int))
            {
                if (int.TryParse(value, out var resultInt))
                {
                    result = (TValue)(Object)resultInt;
                    validationErrorMessage = null;
                    return true;
                }
                else
                {
                    result = default;
                    validationErrorMessage = $"El valor seleccionado {value} no es un número válido.";
                    return false;
                }

            }
            else
            {
                return base.TryParseValueFromString(value, out result, out validationErrorMessage);
            }
        }
    }
}
