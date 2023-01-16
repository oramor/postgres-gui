﻿using System.Data;
using System.Xml;

namespace Lib.GuiCommander
{
    public partial class EntityBaseForm : Form
    {
        /// <summary>
        /// Имя сущностия прописывается на уровне кода конкретной формы (например,
        /// subject для SubjectForm) и передается в родительский конструктор
        /// при каждой инициализации
        /// </summary>
        protected string _entityName;
        protected int _entityId;
        protected EntityObject _entityObject;
        protected bool _isModified;

        #region Constructors

        protected EntityBaseForm()
        {
            InitializeComponent();
        }

        public EntityBaseForm(string entityName, int entityId)
        {
            InitializeComponent();
            _entityName = entityName;
            _entityId = entityId;
        }

        #endregion

        #region Members

        public int Version
        {
            get => _entityObject == null ? -1 : _entityObject.Version;
            set => _entityObject.Version = value;
        }

        public EntityObjectState State
        {
            get => _entityObject == null ? EntityObjectState.None : _entityObject.State;
            set => _entityObject.State = value;
        }

        protected virtual bool IsModified
        {
            get => _isModified;
            set {
                _isModified = value;
                SetTitle();
            }
        }

        #endregion

        #region Virtual methods

        protected virtual void SetTitle()
        {
            this.Text = $"Title for {_entityName}";
        }

        #endregion

        private string ToJson()
        {
            var obj = new ObjectForDbSave();

            foreach (var tablesValue in tables.Values)
            {
                if (tablesValue.JsonName == null) continue;

                var gv = tablesValue.Control as GridControl;
                if (gv?.DataSource is DataTable table)
                {
                    var objs = new List<ObjectProperties>();
                    foreach (DataRow row in table.Rows)
                    {
                        if (row.RowState == DataRowState.Deleted) continue;

                        var prps = new ObjectProperties();
                        foreach (DataColumn column in table.Columns)
                        {
                            // Фото и превью не сохраняем, но это можно явно пометить в метадате
                            if (column.ColumnName == "photo" || column.ColumnName == "preview") continue;
                            prps.Add(column.ColumnName.ToLower(), row[column.ColumnName]);
                        }
                        objs.Add(prps);
                    }
                    obj.Properties.Add(tablesValue.JsonName, objs);
                }
            }
            foreach (var e in columns.Values)
            {
                if (e.JsonName != null)
                {
                    var value = guiObject[e.Name];
                    if (value != null && value != DBNull.Value) obj.Properties.Add(e.JsonName, value);
                }
            }

            var json = JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore,
                    DateFormatString = "yyyy-MM-ddThh:mm:ss"
                });

            return json;
        }
    }
}