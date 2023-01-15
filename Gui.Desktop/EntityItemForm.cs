﻿using Lib.GuiCommander;
using Lib.Providers;

namespace Gui.Desktop
{
    /// <summary>
    /// Общий класс для форм, отображающих экземпляр сущности — справочник
    /// или документ
    /// </summary>
    public partial class EntityItemForm : Form
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

        protected EntityItemForm()
        {
            InitializeComponent();
        }

        public EntityItemForm(string entityName, int entityId)
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

        protected static T CallApiCommand<T>(ApiCommand cmd)
        {
            var db = App.DbProvider;
            var result = db.Execute<T>(cmd);
            return result;
        }
    }
}
