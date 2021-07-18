using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
//using Microsoft.EntityFrameworkCore.
using System.Data.SqlClient;
using PracticeWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApi
{
    public partial class DataContext : DbContext
    {
        //var context;
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public virtual DbSet<CareerRegistration> Careers { get; set; }

        public virtual DbSet<CareerRegistration> RetrieveCandidateRecords { get; set; }

        public virtual DbSet<CareerRegistration> DeleteCandidateRecord { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Query<CareerRegistration>();
        //}

        public List<CareerRegistration> GetCareerRegistrations()
        {
            // Initialization.  
            List<CareerRegistration> lst = new List<CareerRegistration>();

            try
            {
                // Settings.  
                //SqlParameter usernameParam = new SqlParameter("@product_ID", productId.ToString() ?? (object)DBNull.Value);

                // Processing.  
                string sqlQuery = "EXEC [dbo].[GetCandidateDetails] ";

                //lst = await this.Query<CareerRegistration>().FromSql(sqlQuery).ToListAsync();
                lst = this.Careers.FromSqlRaw(sqlQuery).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Info.  
            return lst;
        }

        //public string DeleteRecord(int Id)
        //{
        //    int RowsAffected;
        //    string RecordDeleted = "YES";
        //    try
        //    { 
        //        string sqlQuery = "EXEC [dbo].[DeleteCandidateRecord] @Id";
        //        var param = new SqlParameter("@Id", Id);
        //        //var res = DbContext.Set().FromSql(sqlQuery, Id);
        //        //this.Careers.Remove
        //        RowsAffected = this.Database.ExecuteSqlRaw(sqlQuery, param);

        //        //RowsAffected = DbContext.
        //        //RecordDeleted = this.DeleteCandidateRecord.FromSqlRaw(sqlQuery, param).ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        RecordDeleted = "NO";
        //        throw ex;
        //    }
        //    return RecordDeleted;
        //}

        //public string DeleteRec(CareerRegistration CandidateToBeDeleted)
        //{
        //    string Result;

        //    return Result;
        //}
    }

    
}
