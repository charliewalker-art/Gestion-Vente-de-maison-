using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace VenteMaison
{
    public abstract class Table
    {
        // Champs protégés
        protected MySqlConnection connection;
        protected string tableName;
        protected List<string> columns;
        protected string primaryKey;

        // Constructeur
        protected Table(MySqlConnection connection, string tableName, List<string> columns, string primaryKey)
        {
            this.connection = connection;
            this.tableName = tableName;
            this.columns = columns;
            this.primaryKey = primaryKey;
        }

        // Exemple de méthode commune
        public virtual List<Dictionary<string, object>> LireTout()
        {
            List<Dictionary<string, object>> resultat = new List<Dictionary<string, object>>();

            string sql = $"SELECT * FROM {tableName}";

            try
            {
                connection.Open();
                using (var cmd = new MySqlCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Dictionary<string, object> ligne = new Dictionary<string, object>();
                        foreach (var col in columns)
                        {
                            ligne[col] = reader[col];
                        }
                        resultat.Add(ligne);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la lecture : {ex.Message}");
            }
            finally
            {
                connection.Close();
            }

            return resultat;
        }
    }
}
