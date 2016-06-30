﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using FestManager_Core.Forms;
using System.Collections.Specialized;
using System.Configuration;

namespace FestManager_Abrechnung
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FestManager_Core.Properties.Settings.Default["connectionString"] = Properties.Settings.Default.connectionString;

            // Overwrite default settings:
            var appSettings = new StringCollection();
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                appSettings.Add(currentProperty.Name);
            }
            if (appSettings.Contains("organisation"))
            {
                FestManager_Core.Properties.Settings.Default["organisation"] = Properties.Settings.Default["organisation"];
            }

            var kellnerabrechnungNode = new TreeViewNode("Kellnerabrechnung", 10, 11);
            var offeneAbrechnungenNode = new TreeViewNode("Offene Abrechnungen", 10, 11);
            var manuellesStornierenNode = new TreeViewNode("Manuelles Stornieren", 8, 9);

            var festManagerNode = new TreeViewNode("Festmanager", 12, 13);

            festManagerNode.children.Add(kellnerabrechnungNode);
            festManagerNode.children.Add(offeneAbrechnungenNode);
            festManagerNode.children.Add(manuellesStornierenNode);

            var personalNode = new TreeViewNode("Personal", 2, 3);
            var artikelNode = new TreeViewNode("Artikel", 4, 5);
            var ausgabestellenNode = new TreeViewNode("Ausgabestellen", 14, 15);

            var einstellungenNode = new TreeViewNode("Einstellungen", 6, 7);

            einstellungenNode.children.Add(personalNode);
            einstellungenNode.children.Add(artikelNode);
            einstellungenNode.children.Add(ausgabestellenNode);

            var infoNode = new TreeViewNode("Info", 0, 1);

            var nodes = new Collection<TreeViewNode>
            {
                festManagerNode,
                einstellungenNode,
                infoNode
            };

            Application.Run(new FormMain("Abrechnung", nodes));
        }
    }
}
