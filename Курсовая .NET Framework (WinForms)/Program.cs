using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    internal static class Program
    {
        static internal bool isAdmin = false;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        /// <summary>
        /// Заполняет comboBox списком всех ЖД станций из БД
        /// </summary>
        static async public void UpdateRailroadStationComboBox(ComboBox comboBox)
        {
            using (var db = new ExtInfoEntities())
            {
                var railroadStations = await db.RailroadStations.OrderBy(rs => rs.Name).ToListAsync();
                comboBox.Items.Clear();

                //В этом и подобных ему методах ниже в соответствующий comboBox добавляются объекты
                //класса, сгенерированные EntityFramework из таблицы БД. Для корректного отображения сущности
                //в comboBox в классе этой сущности переопредеён метод Totring().
                //Здесь, например, требуется переопределённый метод ToString() у класса RailroadStations.
                //Если в comboBox отображается что-то не то, проверить наличие переопределённого метода
                foreach (var station in railroadStations)
                {
                    comboBox.Items.Add(station);
                }
            }
        }
        /// <summary>
        /// Заполняет comboBox списком всех типов АТС из БД
        /// </summary>
        static async public void UpdatePBXComboBox(ComboBox comboBox)
        {
            using (var db = new ExtInfoEntities())
            {
                var pbxModels = await db.PBXModels.OrderBy(pm => pm.Name).ToListAsync();
                comboBox.Items.Clear();
                foreach (var pbx in pbxModels)
                {
                    comboBox.Items.Add(pbx);
                }
            }
        }
        /// <summary>
        /// Заполняет comboBox списком всех типов теефонов из БД
        /// </summary>
        static async public void UpdatePhonesComboBox(ComboBox comboBox)
        {
            using (var db = new ExtInfoEntities())
            {
                var phones = await db.Phones.OrderBy(p => p.Model).ToListAsync();
                comboBox.Items.Clear();
                foreach (var phone in phones)
                {
                    comboBox.Items.Add(phone);
                }
            }
        }
        /// <summary>
        /// Заполняет comboBox списком всех видов категорий выхода из БД
        /// </summary>
        static async public void UpdateCategoriesComboBox(ComboBox comboBox)
        {
            using (var db = new ExtInfoEntities())
            {
                var categories = await db.Categories.OrderBy(c => c.Name).ToListAsync();
                comboBox.Items.Clear();
                foreach (var cat in categories)
                {
                    comboBox.Items.Add(cat);
                }
            }
        }
        /// <summary>
        /// Заполняет comboBox списком всех типов телефонов из БД
        /// </summary>
        static async public void UpdatePhoneTypesComboBox(ComboBox comboBox)
        {
            using (var db = new ExtInfoEntities())
            {
                var phoneTypes = await db.PhoneTypes.OrderBy(pt => pt.Name).ToListAsync();
                comboBox.Items.Clear();
                foreach (var type in phoneTypes)
                {
                    comboBox.Items.Add(type);
                }
            }
        }
        /// <summary>
        /// Заполняет comboBox списком всех логинов из БД
        /// </summary>
        static async public void UpdateSecurityComboBox(ComboBox comboBox)
        {
            using (var db = new ExtInfoEntities())
            {
                var logins = await db.Security.OrderBy(s => s.Login).ToListAsync();
                comboBox.Items.Clear();
                foreach (var login in logins)
                {
                    comboBox.Items.Add(login);
                }
            }
        }
    }
}
