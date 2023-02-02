using Lib.GuiCommander;
using System.ComponentModel;
using System.Data;

namespace Gui.Desktop
{
    /// <summary>
    /// Реализация интерфейса INotifyPropertyChanged позволяет сделать любую
    /// DTO, которая наследуется от этого контекста, отслеживаемой. На событие
    /// PropertyChanged подписываются контролы.
    /// </summary>
    public class RecordContext : IDataContext
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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Это событие публично и служит для передачи контролам
        /// конкретного значения
        /// </summary>
        public void OnPropertyChanged(string propertyName, object? propertyValue)
        {
            if (propertyValue == null)
                return;

            PropertyChanged?.Invoke(propertyValue, new PropertyChangedEventArgs(propertyName));
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
