using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace WSGSB
{
    class MySqlGsb
    {
        class MySqlGsb
        {
            //parametre de connexion
            private string cs = @"serve=localhost;userid=gsb_data;password=;database=gsbV2";
            //objet de connexion et propriétés
            private MySqlConnection conn = null;
            private MySqlDataReader rdr = null;
            //constructeur
            public MySqlGsb()
            {
                try
                {
                    this.conn = new MySqlConnection(this.cs);
                    this.conn.Open();
                }
                catch (MySqlException ex)
                {
                    gestionErr(ex);
                }
            }
            //destructeur
            ~MySqlGsb()
            {
                this.conn.Close();
            }
            /// <summary>
            /// Fonction qui renvoie le resultat d'une requete mySql de type SELECT
            /// sous forme de table type Base de donnée
            /// </summary>
            /// <param name="req">Requete SQL de type SELECT</param>
            /// <returns>Datatable Table de resultat. Renvoie NULL si echec de la requete</returns>
            public DataTable fetchAll(string req)
            {
                MySqlCommand cmd = new MySqlCommand(req, this.conn);
                rdr = cmd.ExecuteReader();
                //nb de colonnes prévues dans la table
                int cols = this.rdr.FieldCount;
                //creation d'une table de resultat
                System.Data.DataTable table = new DataTable("ParentTable");
                //declaration row/cols dans la table de resultat
                DataColumn column;
                DataRow row;
                string[] header = new string[cols];//tableau de header
                //ajout des noms de colonnes dans la table
                for (int j = 0; j < cols; j++)
                {
                    column = new DataColumn();
                    column.ColumnName = rdr.GetName(j);//nomme la colonne
                    header[j] = rdr.GetName(j);//ranger les noms dans un tableau
                    column.ReadOnly = true;
                    column.Unique = false;
                    table.Columns.Add(column);//ajout de la column
                }
                try
                {
                    while (rdr.Read())
                    {
                        row = table.NewRow();//instancier row
                        int i = 0;
                        foreach (string el in header)
                        {//remplir chaque ligne par nom de colonne
                            row[el] = rdr.GetString(i);
                            i++;
                        }
                        table.Rows.Add(row);//et on ajoute la ligne au tableau
                    }
                    rdr.Close();
                    return table;
                }
                catch (MySqlException ex)
                {
                    gestionErr(ex);
                    rdr.Close();
                    return null;
                }
            }
            /// <summary>
            /// Execute requete sans retour de type INSERT,DELETE,UPDATE
            /// </summary>
            /// <param name="req">Requete sql</param>
            public void exec(string req)
            {
                MySqlCommand cmd = new MySqlCommand(req, this.conn);
                cmd.Connection = conn;
                cmd.CommandText = req;
                try
                {
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    gestionErr(ex);
                }
            }
            /// <summary>
            /// Gestion des erreurs
            /// Envoie un message dans une console
            /// </summary>
            /// <param name="ex">MySqlException</param>
            private void gestionErr(MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
            /// <summary>
            /// Fonction qui affiche en console la table complete(debugage)
            /// </summary>
            /// <param name="table">Datatable</param>
            public void ShowTable(DataTable table)
            {
                foreach (DataColumn col in table.Columns)
                {
                    Console.Write("{0,-14}", col.ColumnName);
                }
                Console.WriteLine();
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn col in table.Columns)
                    {
                        if (col.DataType.Equals(typeof(DateTime)))
                            Console.Write("{0,-14:d}", row[col]);
                        else if (col.DataType.Equals(typeof(Decimal)))
                            Console.Write("{0,-14:C}", row[col]);
                        else
                            Console.Write("{0,-14}", row[col]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            /// <summary>
            /// Fonction qui retourne un element de la table de donnée en fonction
            /// de sa ligne et de sa colonne en paramètres
            /// </summary>
            /// <param name="table">Datatable: Table remplie de données de type String</param>
            /// <param name="row">int: Numéro de ligne choisie</param>
            /// <param name="cols">string: Nom de la colonne ("id","name" etc..)</param>
            /// <returns>Retourne un element de type object qui devra etre casté en string a l'appel de la fonction.
            /// exemple: string foo = (string)myConnect.showTableElems(myTable,0,"idVisiteur");</returns>
            public object showTableElems(DataTable table, int row, string cols)
            {
                DataColumn col = table.Columns[cols];
                DataRow ligne = table.Rows[row];
                return ligne[col];
            }
        }
    }
}
