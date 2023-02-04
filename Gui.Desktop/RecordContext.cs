using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using System.Data;

namespace Gui.Desktop
{
    /// <summary>
    /// Реализация интерфейса INotifyPropertyChanged позволяет сделать любую
    /// DTO, которая наследуется от этого контекста, отслеживаемой. На событие
    /// PropertyChanged подписываются контролы.
    /// </summary>
    public class RecordContext : IObservableContext
    {
        readonly DataRow _row;

        #region Constructors

        public RecordContext(DataRow row)
        {
            _row = row;
        }

        /// <summary>
        /// Этот вариант конструктора используется при необходимости
        /// создать контекст через Dto (например, если в системе
        /// не предусмотрена работа с метаданными). При этом в Dto могут
        /// быть предусмотрены значения по умолчанию, которые попадут
        /// в DataRow.
        /// </summary>
        public RecordContext(object dto)
        {
            var dt = new DataTable("dto");
            _row = dt.NewRow();

            foreach (var prop in dto.GetType().GetProperties())
            {
                var camelName = prop.Name.LowFirstChar();
                dt.Columns.Add(camelName);

                var propValue = prop.GetValue(dto);

                _row[camelName] = propValue == null ? DBNull.Value : propValue;
                //_row.SetField(camelName, propValue);
            }
        }

        #endregion

        public event ContextPropertyChangedEventHandler? ContextPropertyChanged;
        public event ContextChangedByUserEventHandler? ContextChangedByUser;

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        /// <summary>
        /// Это событие публично и служит для передачи контролам
        /// конкретного значения
        /// </summary>
        //public void OnPropertyChanged(string propertyName, object? newPropertyValue)
        //{
        //    if (newPropertyValue == null)
        //        return;

        //    if (this[propertyName] == newPropertyValue)
        //        return;

        //    this[propertyName] = newPropertyValue;

        //    PropertyChanged?.Invoke(newPropertyValue, new PropertyChangedEventArgs(propertyName));
        //}

        private void OnContextChangedByUser()
        {
            ContextChangedByUser?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Здесь полученное от пользовательского ввода значение распаковывается
        /// и связывается с текущим значением в индексном свойстве. Если значения
        /// не эквивалентны, отправляется извещение, что контекст изменен
        /// со стороны пользовательского ввода
        /// </summary>
        public void ControlValueChangedEventHandler(IBaseControl sender, ControlValueChangedEventArgs e)
        {
            OnContextChangedByUser();
        }

        public int Id
        {
            get => _row["id"] == DBNull.Value ? 0 : Convert.ToInt32(_row["id"]);
            set => _row["id"] = value;
        }

        public DataRecordState State
        {
            get {
                return _row["state"] == DBNull.Value
                    ? DataRecordState.None
                    : (DataRecordState)Convert.ToInt32(_row["state"]);
            }
            set => _row["state"] = (int)value;
        }

        public int Version
        {
            get => _row["ver"] == DBNull.Value ? 0 : Convert.ToInt32(_row["ver"]);
            set => _row["ver"] = value;
        }

        /// <summary>
        /// Если свойство не будет найдено по ключу, вернется null.
        /// Не следует путать с кейсом, когда отсутствовало дефолтное значение
        /// при загрузке Dto и свойство есть в справочнике, но получило
        /// значение DBNull.Value
        /// </summary>
        public object? this[string propName]
        {
            get {
                if (_row.Table.Columns.Contains(propName))
                {
                    return _row[propName];
                }

                return null;
            }
            set {
                if (_row.Table.Columns.Contains(propName))
                {
                    _row[propName] = value;
                }
            }
        }
    }
}
