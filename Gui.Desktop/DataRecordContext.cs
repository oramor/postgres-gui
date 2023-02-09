using Gui.Desktop.Forms;
using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using Lib.Providers.JsonProvider;
using System.ComponentModel;
using System.Data;

namespace Gui.Desktop
{
    public enum RecordActionPermitEnum { Insert, Update, Delete };

    /// <summary>
    /// Это один из вариантов реализации интефейса <see cref="IDataRecordContext"/>.
    /// Здесь приложение не работает с метаданными, а информацю о колонках получает
    /// из Dto
    /// </summary>
    public class DataRecordContext : IDataRecordContext
    {
        /// <summary>
        /// В других реализациях контекста эта информация может браться из метаданных
        /// </summary>
        const string _schemaName = "api_admin";
        DataRow _row;

        #region Constructors

        /// <param name="dataDomainName">Должен быть указан в PascalCase</param>
        public DataRecordContext(string dataDomainName, int? recordId)
        {
            DataDomainName = dataDomainName;

            var dt = new DataTable("dto");
            _row = dt.NewRow();

            /// Если идентификатор был передан, грузим из базы (можно вынести в
            /// асинхронный метод, помечая, что контекст в работе), иначе быстро
            /// собираем из готовой Dto
            if (recordId.HasValue)
            {
                var row = ApiProvider.GetDataRecordRow(Token, (int)recordId);
                _row = row;
            }
            else
            {
                var dtoPathName = "Gui.Desktop.Dto." + dataDomainName + "Dto";
                var dtoType = Type.GetType(dtoPathName, false, true);

                if (dtoType == null)
                {
                    throw new Exception($"Not found Dto with name {dtoPathName}");
                }
                else
                {
                    foreach (var prop in dtoType.GetProperties())
                    {
                        var camelName = prop.Name.LowFirstChar();
                        dt.Columns.Add(camelName);

                        /// Если требуется добавлять дефолтные значения, то придется
                        /// создать индекс объекта из _dtoType, а затем передать
                        /// этот инстанс в метод _dtoType.GetValue(dto)
                        _row[camelName] = DBNull.Value;
                    }
                }
            }
        }

        #endregion

        public string DataDomainName { get; init; }

        public string Token => DataDomainName.ToSnakeCase();

        JsonParameter MakeJsonParameter()
        {
            var jp = new JsonParameter();

            foreach (DataColumn col in _row.Table.Columns)
            {
                var camelName = col.ColumnName.LowFirstChar();
                jp.Add(camelName, _row[camelName]);
            }

            return jp;
        }

        protected virtual bool CheckPermit(RecordActionPermitEnum permit)
        {
            return true;
        }

        public void ShowForm(string postfix = "")
        {
            var formName = "Gui.Desktop.Forms." + DataDomainName + postfix + "Form";
            var formType = Type.GetType(formName);

            if (formType == null)
            {
                throw new ArgumentException($"Not found form type with name {formName}. Did you forgot path?");
            }

            if (Activator.CreateInstance(formType, this) is not DataRecordForm form)
            {
                throw new Exception($"Form {formName} is not an instance of DataRecordForm");
            }

            form.ShowDialog();
        }

        #region Actions

        public void Create()
        {
            if (!CheckPermit(RecordActionPermitEnum.Insert))
            {
                throw new Exception("Forbidden!");
            }

            var json = MakeJsonParameter();
            var id = ApiProvider.Create(Token, json);
            App.Logger.GuiReport($"Created {DataDomainName} with id {id}");
            OnActionSucceed();
            _row["id"] = id;
        }

        public void Update()
        {
            if (!CheckPermit(RecordActionPermitEnum.Update))
            {
                throw new Exception("Forbidden!");
            }

            if (Id > 0)
            {
                var json = MakeJsonParameter();
                int ver = ApiProvider.Update(Token, json);
                App.Logger.GuiReport($"Updated {DataDomainName} with id {Id} (version {ver})");
                OnActionSucceed();
            }
        }

        public void Delete()
        {
            if (!CheckPermit(RecordActionPermitEnum.Delete))
            {
                throw new Exception("Forbidden!");
            }

            if (Id > 0 && (MessageBox.Show("Delete this object from Database? You will not undo this action!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))
            {
                ApiProvider.Delete(Token, (int)Id);
                App.Logger.GuiReport($"{DataDomainName} with id {Id} REMOVED");
                OnActionSucceed();
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
        /// Оповещает форму об изменении статуса записи, что приводит
        /// к обновлению бидндинга форм и снятию статуса модификации
        /// </summary>
        public event EventHandler<EventArgs>? ActionSucceed;
        private void OnActionSucceed()
        {
            ActionSucceed?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод OnPropertyInvalidated сделан публичным, чтобы внешний код имел
        /// возможность матчить ответ ответ сервера на инвалидные поля,
        /// оповещая таким образом контролы на форме
        /// </summary>
        public event EventHandler<PropertyInvalidatedEventArgs>? PropertyInvalidated;
        public void OnPropertyInvalidated(PropertyInvalidatedEventArgs e)
        {
            PropertyInvalidated?.Invoke(this, e);
        }

        #endregion

        #region Handlers

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

        #endregion

        #region Data Fields

        public int? Id
        {
            get => _row["id"] == DBNull.Value ? null : Convert.ToInt32(_row["id"]);
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
                    OnContextPropertyChanged(propName);
                }
            }
        }

        #endregion
    }
}
