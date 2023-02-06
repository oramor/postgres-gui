using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.GuiCommander.Controls
{
    /// <summary>
    /// Этот интерфейс должны реализовывать контексты всех форм, которые
    /// хотят отправлять своим контролам оповещения об ошибках. Контролы
    /// подписываются на события инвалидации.
    /// </summary>
    public interface IInvalidPropertyNotify
    {
        event EventHandler<PropertyInvalidatedEventArgs> PropertyInvalidated;

        /// <summary>
        /// Метод публичен, чтобы код-обработчик ответа сервера,
        /// который может быть реализован в другом классе (например,
        /// в инфраструктуре API) мог инициировать оповещение
        /// компонентов на формах
        /// </summary>
        void OnPropertyInvalidated(PropertyInvalidatedEventArgs e);
    }
}
