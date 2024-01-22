using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
//Для экспорта данных в формате Excel таблиц к проекту подключен NuGet пакет EPPlus
//Также подключено пространство имён:
using OfficeOpenXml;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class ReportsForm : Form
    {
        private List<string> usedExtensionsheaders;
        /// <summary>
        /// Форма создания отчётов
        /// </summary>
        public ReportsForm()
        {
            InitializeComponent();
            usedExtensionsheaders = new List<string>()
                    {
                        "Узел", "АТС", "Номер", "Порт", "Категория", "Тип телефона", "Абонент", "Адрес", "Примечание"
                    };
        }

        /// <summary>
        /// Создаёт файл куда будет сохранена информация, собранная в отчёте
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
        private FileInfo CreateFile(string path, string fileName )
        {
            FileInfo newFile = new FileInfo(path + $"\\{fileName}");
            if (newFile.Exists)
            {
                newFile.Delete();  // ensures we create a new workbook
                newFile = new FileInfo(path + $"\\{fileName}");
            }
            return newFile;
        }
        #region Список всех занятых телефонов

        private void linkLabelReportAllUsedExtensionsExcel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                var outputDir = folderBrowserDialog1.SelectedPath;
                var newFile = CreateFile(outputDir, "report1.xlsx");
                using (var db = new ExtInfoEntities())
                {
                    var freeModelPhoneId = db.Phones.Where(p => p.Model == "FREE").Select(p => p.Id).FirstOrDefault();
                    var data = db.Subscribers.Where(s => s.PhoneId != freeModelPhoneId).Select(s => new
                    {
                        Узел = s.PBX.RailroadStations.Name,
                        АТС = s.PBX.PBXModels.Name,
                        Номер = s.Extension,
                        Порт = s.Port,
                        Категория = s.Categories.Name,
                        Тип_телефона = s.Phones.Model,
                        Абонент = s.Name,
                        Адрес = s.Locations.RailroadStations.Name + " " + s.Locations.Position,
                        Примечание = s.AddInfo
                    }).OrderBy(s => s.Номер).ToList();
                    using (var package = new ExcelPackage(newFile))
                    {
                        var worksheet = package.Workbook.Worksheets.Add("report1");
                        for (int i = 0; i < usedExtensionsheaders.Count; i++)
                        {
                            worksheet.Cells[1, i + 1].Value = usedExtensionsheaders[i];
                        }
                        for (int i = 0; i < data.Count; i++)
                        {
                            worksheet.Cells[i + 2, 1].Value = data[i].Узел;
                            worksheet.Cells[i + 2, 2].Value = data[i].АТС;
                            worksheet.Cells[i + 2, 3].Value = data[i].Номер;
                            worksheet.Cells[i + 2, 4].Value = data[i].Порт;
                            worksheet.Cells[i + 2, 5].Value = data[i].Категория;
                            worksheet.Cells[i + 2, 6].Value = data[i].Тип_телефона;
                            worksheet.Cells[i + 2, 7].Value = data[i].Абонент;
                            worksheet.Cells[i + 2, 8].Value = data[i].Адрес;
                            worksheet.Cells[i + 2, 9].Value = data[i].Примечание;
                        }
                        worksheet.Cells["A:I"].AutoFitColumns(0);
                        package.Save();
                        MessageBox.Show($"Отчёт успешно сохранён в {newFile.FullName}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabelReportAllUsedExtensionsHtm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                folderBrowserDialog1.ShowDialog();
                var outputDir = folderBrowserDialog1.SelectedPath;
                var newFile = CreateFile(outputDir, "report1.htm");
                using (var db = new ExtInfoEntities())
                {
                    var freeExtensionPhoneId = db.Phones.Where(p => p.Model == "FREE").Select(p => p.Id).FirstOrDefault();
                    var usedExtensions = db.Subscribers.Where(s => s.PhoneId != freeExtensionPhoneId).Select(s => new
                    {
                        Узел = s.PBX.RailroadStations.Name,
                        АТС = s.PBX.PBXModels.Name,
                        Номер = s.Extension,
                        Порт = s.Port,
                        Категория = s.Categories.Name,
                        Тип = s.Phones.Model,
                        Абонент = s.Name,
                        Адрес = s.Locations.RailroadStations.Name + " " + s.Locations.Position,
                        Примечание = s.AddInfo
                    }).OrderBy(s => s.Номер).ToList();
                    var htmTable = "<!Doctype html>";
                    // Определяем теги стилей
                    string htmStyle = @"<head>
                                            <style>
                                                table {
                                                    border-collapse: collapse;
                                                }
                                                tr:nth-child(odd) { 
                                                    background-color: #eee; 
                                                }
                                            </style>
                                        </head>";
                    // Добавляем открывающие теги HTML и таблицы
                    htmTable += $"<html>{htmStyle}<body><table border='1'>";

                    // Добавляем заголовки таблицы
                    htmTable += "<tr>";
                    for (int i = 0; i < usedExtensionsheaders.Count; i++)
                    {
                        htmTable += $"<th>{usedExtensionsheaders[i]}</th>";
                    }
                    htmTable += "</tr>";

                    foreach (var item in usedExtensions)
                    {
                        htmTable += "<tr>";
                        htmTable += "<td>" + item.Узел + "</td>";
                        htmTable += "<td>" + item.АТС + "</td>";
                        htmTable += "<td>" + item.Номер + "</td>";
                        htmTable += "<td>" + item.Порт + "</td>";
                        htmTable += "<td>" + item.Категория + "</td>";
                        htmTable += "<td>" + item.Тип + "</td>";
                        htmTable += "<td>" + item.Абонент + "</td>";
                        htmTable += "<td>" + item.Адрес + "</td>";
                        htmTable += "<td>" + item.Примечание + "</td>";
                        htmTable += "</tr>";
                    }
                    htmTable += "</table></body></html>";
                    File.WriteAllText(newFile.FullName, htmTable);
                    MessageBox.Show($"Отчёт успешно сохранён в {newFile.FullName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}