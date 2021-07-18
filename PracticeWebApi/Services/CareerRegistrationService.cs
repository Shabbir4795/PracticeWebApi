using PracticeWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace PracticeWebApi.Services
{
    public class CareerRegistrationService
    {
        private DataContext _dataConnections;

        public CareerRegistrationService(DataContext dataContext)
        {
            _dataConnections = dataContext;
        }

        public List<CareerRegistration> GetCandidateDetails()
        {
            List<CareerRegistration> ListOfCandidates = new List<CareerRegistration>();
            //string StoredProcedure = "GetCandidateDetails";
            //ListOfCandidates = _dataConnections.C
            ListOfCandidates = _dataConnections.GetCareerRegistrations().ToList();
            return ListOfCandidates;
        }

        public CareerRegistration GetSingleCandidateDetails(int Id)
        {
            List<CareerRegistration> ListOfCandidates = new List<CareerRegistration>();
            var param = new SqlParameter("@Id", Id);
            ListOfCandidates = _dataConnections.Careers.FromSqlRaw("select * from CareerRegistration (nolock) where Id = @Id", param).ToList();
            return ListOfCandidates.First();
        }

        //public string DeleteCandidateRecord (int Id)
        //{
        //    string RecordDeleted;

        //    //var Record = _dataConnections.Database.ExecuteSqlRaw

        //    RecordDeleted = _dataConnections.DeleteRecord(Id).ToString();
        //    RecordDeleted = RecordDeleted.Equals("YES") ? "RECORD DELETED" : RecordDeleted;
        //    return RecordDeleted;
        //}

        public string DeleteSingleRec(int Id)
        {
            string Result = "Success";
            //int a;
            CareerRegistration CandidateRecord = new CareerRegistration();
            var param = new SqlParameter("@Id", Id);
            CandidateRecord = GetSingleCandidateDetails(Id);
            _dataConnections.Careers.Remove(CandidateRecord);
            _dataConnections.SaveChanges();
            return Result;
        }

        public string UpdateCandidateRecord(int Id)
        {
            string Result = "Success";
            CareerRegistration CandidateRecord = new CareerRegistration();
            CandidateRecord = GetSingleCandidateDetails(Id);
            CandidateRecord.Name = "Noone";
            _dataConnections.SaveChanges();
            return Result;
        }

        public string AddCandidate()
        {
            string Result = "Success";
            CareerRegistration CandidateRecord = new CareerRegistration{
                Name = "Anyone",
                Address = "Somewhere",
                ContactNumber = "9874563210",
                CurrentCTC = "6LPA",
                ExpectedCTC = "8LPA",
                PreferredLocation = "Home",
                NoticePeriod = 90,
                AadharNumber = "987456321023",
                LastModifiedBy = "Me",
                LastModifiedDate = DateTime.Now
            };
            _dataConnections.Careers.Add(CandidateRecord);
            _dataConnections.SaveChanges();

            return Result;
        }
    }
}
