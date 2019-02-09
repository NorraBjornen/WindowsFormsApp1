using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1 {
    class DataBase {
        private static readonly String connectionString = "server=localhost;user=root;database=disp;password=deepundo99;";

        public String GetCorrect(String wrong) {
            try { 
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                String sql = "SELECT Correct FROM streets WHERE Wrong='" + wrong + "'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) {
                    String correct = reader.GetString("Correct");
                    if(correct == "-") {
                        correct = wrong;
                    }
                    reader.Close();
                    conn.Close();
                    return correct;
                } else {
                    sql = "INSERT INTO streets (`Wrong`) VALUES ('" + wrong + "')";
                    Query(sql);
                    reader.Close();
                    conn.Close();
                    return wrong;
                }
                
            } catch (Exception e) {
                //MessageBox.Show(e.Message);
            }
            return wrong;
        }

        public List<AutoCompleteStringCollection> GetStreets() {
            AutoCompleteStringCollection collectionStreet = new AutoCompleteStringCollection();
            AutoCompleteStringCollection collectionTo = new AutoCompleteStringCollection();
            try {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                String sql = "SELECT DISTINCT Correct FROM streets WHERE Correct!='-'";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    collectionStreet.Add(reader.GetString("Correct"));
                    collectionTo.Add(reader.GetString("Correct") + " ");
                }
                reader.Close();
                conn.Close();
            } catch (Exception e) {
                //MessageBox.Show(e.Message);
            }
            List<AutoCompleteStringCollection> list = new List<AutoCompleteStringCollection> {
                collectionStreet,
                collectionTo
            };
            return list;
        }

        private void Query(String sql) {
            try {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                conn.Close();
            } catch (Exception e) {
                //MessageBox.Show(e.Message);
            }
        }
    }
}
