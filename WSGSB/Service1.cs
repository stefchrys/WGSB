using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WSGSB
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }
        public void OnTimer(object sender, System.Timers.ElapsedEventArgs args)
        {
            MySqlGsb myConnect = new MySqlGsb();
            string annMois = DateGsb.getAnnMoisPrecedent();
            DataTable fiches = myConnect.fetchAll("SELECT idVisiteur,mois,idEtat FROM FicheFrais WHERE mois='" + annMois + "'");
            //Entre le et le 10 du mois recuperation fiche de frais N-1 et changer etat CR a CL
            if (DateGsb.entre(1, 10))
            {
                foreach (DataRow row in fiches.Rows)
                {
                    if ((string)row["idEtat"] == "CR")
                    {
                        myConnect.exec("update FicheFrais set idEtat = 'CL' where idVisiteur ='" + row["idVisiteur"] + "'and mois='" + row["mois"] + "'");
                    }
                }
            }
            //A partir du 20 eme jour du mois Maj VA à RB
            if (DateGsb.entre(20, 31))
            {
                foreach (DataRow row in fiches.Rows)
                {
                    if ((string)row["idEtat"] == "VA")
                    {
                        myConnect.exec("update FicheFrais set idEtat = 'RB' where idVisiteur ='" + row["idVisiteur"] + "'and mois='" + row["mois"] + "'");
                    }
                }
            }
            //pour le debuggage only
            //Console.WriteLine("Press enter to close...");
            //Console.ReadLine();
        }
        protected override void OnStart(string[] args)
        {
            this.OnTimer(null, null);//on declenche de suite l'evenement
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 60000 * 60 * 24;//puis tout les 24 heures
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.OnTimer);
            timer.Start();
          
        }
        protected override void OnStop()
        {

        }
    }
}
