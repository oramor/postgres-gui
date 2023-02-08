﻿using Gui.Desktop.Forms;
using Lib.GuiCommander;
using Lib.GuiCommander.Controls;
using Lib.Providers;
using Lib.Providers.JsonProvider;
using System.ComponentModel;
using System.Data;

namespace Gui.Desktop
{
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

            /// Если идентификатор был передан, грузим из базы (можно
            /// асинхронно, помечая, что контекст в работе), иначе быстро
            /// собираем из готовой Dto
            if (recordId.HasValue)
            {
                LoadRowFromDb();
            }
            else
            {
                var dtoClassName = dataDomainName + "Dto";
                var dtoType = Type.GetType(dtoClassName);

                if (dtoType == null)
                {
                    throw new Exception($"Not found Dto with name {dtoClassName}");
                }
                else
                {
                    foreach (var prop in dtoType.GetProperties())
                    {
                        var camelName = prop.Name.LowFirstChar();
                        dt.Columns.Add(camelName);

                        var propValue = prop.GetValue(dtoType);

                        _row[camelName] = propValue ?? DBNull.Value;
                    }
                }
            }
        }

        #endregion

        void LoadRowFromDb()
        {
            var funcName = "fn_get_" + Token + "_item_r";

            var cmd = new ApiCommand("api_admin", funcName);
            cmd.AddParam(new ApiParameter("p_id", Id));
            _row = App.CallApiCommand<DataRow>(cmd);
        }

        public string DataDomainName { get; init; }

        public string Token => DataDomainName.ToLower(); //TODO!!!!!!!!!!!!!!!!


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

        #region Actions

        public void CreateAction()
        {
            if (!CheckPermit(RecordActionPermitEnum.Insert))
            {
                throw new Exception("Forbidden!");
            }

            var jp = MakeJsonParameter();

            var procName = "pr_" + Token + "_create_n";

            var cmd = new ApiCommand("api_admin", procName);
            cmd.AddParam(new ApiParameter("p_id", ApiParameterDataType.Integer));
            cmd.AddParam(new ApiParameter(jp));
            var id = App.CallApiCommand<int>(cmd);

            App.Logger.GuiReport($"Created {DataDomainName} with id {id}");

            OnActionSucceed();
            State = DataRecordState.Saved; // Commited???????????????????
            Id = id;
            Version = 1;
        }

        public void UpdateAction()
        {
            if (!CheckPermit(RecordActionPermitEnum.Update))
            {
                throw new Exception("Forbidden!");
            }

            if (Id > 0)
            {
                var jp = MakeJsonParameter();

                var procName = "pr_" + Token + "_update_";

                var cmd = new ApiCommand("api_admin", procName);
                cmd.AddParam(new ApiParameter("p_ver", ApiParameterDataType.Integer));
                cmd.AddParam(new ApiParameter(jp));
                var ver = App.CallApiCommand<int>(cmd);

                App.Logger.GuiReport($"Updated {DataDomainName} with id {Id} (version {ver})");

                OnActionSucceed();
                Version = ver;
            }
        }

        public void DeleteAction()
        {
            if (!CheckPermit(RecordActionPermitEnum.Delete))
            {
                throw new Exception("Forbidden!");
            }

            if (Id > 0 && (MessageBox.Show("Delete this object from Database? You will not undo this action!", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK))
            {
                var procName = "pr_" + Token + "_remove_";

                var cmd = new ApiCommand("api_admin", procName);
                cmd.AddParam(new ApiParameter("p_id", Id));
                App.CallApiCommandVoid(cmd);

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
            ActionSucceed?.Invoke(State, EventArgs.Empty);
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

        public void ShowForm()
        {
            var formName = DataDomainName + "Form";
            var formType = Type.GetType(formName);

            if (formType == null)
            {
                throw new ArgumentException($"Not found form type with name {formName}");
            }

            if (Activator.CreateInstance(formType) is not BaseObjectForm form)
            {
                throw new Exception($"Form {formName} is not an instance of BaseObjectForm");
            }

            form.ShowDialog();
        }

        #endregion

        #region Data Fields

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
                    OnContextPropertyChanged(propName);
                }
            }
        }

        #endregion
    }
}
