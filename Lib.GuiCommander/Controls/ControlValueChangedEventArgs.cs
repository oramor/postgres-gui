using System.CodeDom;

namespace Lib.GuiCommander.Controls
{
    public class ControlValueChangedEventArgs : EventArgs
    {
        public ControlValueChangedEventArgs(object? newValue)
        {
            NewValue = newValue;
        }

        public object? NewValue { get; }

        ///// <summary>
        ///// Метод переопределен строго для сравнения со значениями,
        ///// которые могут быть извлечены из полей DataRow. Такие поля
        ///// для не установленных значений вместо null содержат DBNull.Value
        ///// </summary>
        //public override bool Equals(object? obj)
        //{

        //    if (obj == DBNull.Value && NewValue == null)
        //    {
        //        return true;
        //    }
        //    else if (NewValue != null && obj != null)
        //    {
        //        if (obj.GetType() != NewValue.GetType())
        //            return false;

        //        switch (obj)
        //        {
        //            case int v:
        //                return v == (int)NewValue;
        //            case string v:
        //                return v == (string)NewValue;
        //            case bool v:
        //                return v == (bool)NewValue;
        //        }
        //    }

        //    return false;
        //}

        //public override int GetHashCode() => NewValue != null 
        //    ? NewValue.GetHashCode()
        //    : DBNull.Value.GetHashCode();
    }
}
