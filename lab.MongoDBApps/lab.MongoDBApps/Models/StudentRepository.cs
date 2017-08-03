using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab.MongoDBApps.Models
{
    public class StudentRepository : IStudentRepository
    {

        #region Private Variable
        private readonly MongoDbContext _mongoDbContext;
        #endregion

        #region Constructor
        public StudentRepository()
        {
            _mongoDbContext = new MongoDbContext();
        }

        #endregion

        #region Method

        public Student Insert(Student entity)
        {
            _mongoDbContext.Student.Save(entity);
            return entity;
        }
        
        public Student Update(Student entity)
        {
            var model = Query<Student>.EQ(pd => pd.Id, entity.Id);
            var operation = Update<Student>.Replace(entity);
            _mongoDbContext.Student.Update(model, operation);
            return entity;
        }

        public Student Get(ObjectId id)
        {
            var model = Query<Student>.EQ(p => p.Id, id);
            return _mongoDbContext.Student.FindOne(model);
        }

        public IEnumerable<Student> GetAll()
        {
            return _mongoDbContext.Student.FindAll();
        }
        
        public void Delete(Student entity)
        {
            var model = Query<Student>.EQ(e => e.Id, entity.Id);
            var operation = _mongoDbContext.Student.Remove(model);
        }

        #endregion
    }

    public interface IStudentRepository
    {
        Student Insert(Student entity);
        Student Update(Student entity);
        void Delete(Student entity);
        Student Get(ObjectId id);
        IEnumerable<Student> GetAll();
    }
}