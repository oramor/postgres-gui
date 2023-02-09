using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using System.ComponentModel;
using System.Data;

namespace Gui.Desktop
{
    /// <summary>
    /// Реализация интерфейса INotifyPropertyChanged позволяет сделать любую
    /// DTO, которая наследуется от этого контекста, отслеживаемой. На событие
    /// PropertyChanged подписываются контролы.
    /// </summary>
    public class RecordContext : IDataRecordContext
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

        #region Events

        public event ContextPropertyChangedEventHandler? ContextPropertyChanged;
        private void OnContextPropertyChanged(string propName)
        {
            ContextPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public event ContextChangedByUserEventHandler? ContextChangedByUser;
        private void OnContextChangedByUser()
        {
            ContextChangedByUser?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод OnPropertyInvalidated сделан публичным, чтобы внешний код имел
        /// возможность матчить ответ ответ сервера на инвалидные поля,
        /// оповещая таким образом контролы на форме
        /// </summary>
        public event EventHandler<PropertyInvalidatedEventArgs>? PropertyInvalidated;
        public event EventHandler<EventArgs> ActionSucceed;

        public void OnPropertyInvalidated(PropertyInvalidatedEventArgs e)
        {
            PropertyInvalidated?.Invoke(this, e);
        }

        #endregion

        /// <summary>
        /// Конечно, можно переопределить Equals() в ControlValueChangedEventArgs
        /// и сравнивать его со значением в DataRow, но это потребует рефлексии,
        /// а возможно и приведения типов. Какой смысл, если на практике
        /// пользовательский ввод — это почти всегда новое значение.
        /// </summary>
        public void ControlValueChangedEventHandler(IBaseControl sender, ControlValueChangedEventArgs e)
        {
            var colName = sender.CamelName;

            if (colName == null)
                return;

            _row[colName] = e.NewValue;
            OnContextChangedByUser();
        }

        public void ShowForm()
        {
            throw new NotImplementedException();
        }

        public void Create()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
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
        public string DataDomainName { get => throw new NotImplementedException(); init => throw new NotImplementedException(); }

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
                    OnContextPropertyChanged(propName);
                }
            }
        }
    }
}
