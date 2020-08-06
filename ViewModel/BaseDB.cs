using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public abstract class BaseDB
    {
        protected OleDbConnection conn; /* OleDb == Access */
        protected OleDbCommand command;
        protected OleDbDataReader reader; //works only with Full Connected, like java's ResultSet: read-only,forward-only(sequential data access)
                                          //C# takes only one row at a time, all other rows are kept inside MySQL server's memory
        
        private List<ChangeEntity> changes;

        private static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Ronen\source\repos\ExampleProject\ViewModel\MyDatabase.accdb;Persist Security Info=True";

        public BaseDB() 
        {
            conn = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = conn;
            changes = new List<ChangeEntity>();
        }

        protected abstract BaseEntity newEntity();
        protected virtual BaseEntity FillEntity(BaseEntity entity)
        {
            entity.Id = reader.GetInt32(reader.GetOrdinal("ID"));   // Int32.Parse(reader["ID"].ToString());
            System.Diagnostics.Debug.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            return entity;
        }
        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                conn.Open();
                reader = command.ExecuteReader();

                while(reader.Read())
                {
                    BaseEntity entity = newEntity();
                    FillEntity(entity);
                    list.Add(entity);
                }
                
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\n" + e.StackTrace + "\nSQL:" + command.CommandText);
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return list;
        }

        /* add to list of changes to be executed later */
        public void insert(BaseEntity entity)
        {
            System.Diagnostics.Debug.WriteLine("BaseDB insert");
            changes.Add(new ChangeEntity(entity, this.doInsert));
        }

        public void update(BaseEntity entity)
        {
            changes.Add(new ChangeEntity(entity, this.doUpdate));
        }

        public void delete(BaseEntity entity)
        {
            changes.Add(new ChangeEntity(entity, this.doDelete));
        }

        /* actual insert, returns number of inserted rows */
        protected virtual int doInsert(BaseEntity entity) { return 0;  }

        protected virtual int doUpdate(BaseEntity entity) { return 0; }

        protected virtual int doDelete(BaseEntity entity) { return 0; } 


        public int saveChanges()
        {
            System.Diagnostics.Debug.WriteLine("BaseDB saveChanges");
            conn.Open();

            int changeCount = 0;

            try
            {
                while(changes.Any()) /* while list not empty */
                {
                    System.Diagnostics.Debug.WriteLine("BaseDB saveChanges loop");
                    ChangeEntity change = changes[0];
                    changeCount += change.ExecuteChange(change.Entity);
                    changes.RemoveAt(0);
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

            return changeCount;
        }
    }

}
