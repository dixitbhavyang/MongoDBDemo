using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDBDemo.Models;
using MongoDBDemo.Settings;

namespace MongoDBDemo.Services
{
    public class StudentService
    {
        private readonly IMongoCollection<Student> _students;

        public StudentService(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _students = database.GetCollection<Student>("students");
        }

        // GET ALL
        public async Task<List<Student>> GetAllAsync() =>
            await _students.Find(_ => true).ToListAsync();

        // GET BY ID
        public async Task<Student?> GetByIdAsync(string id) =>
            await _students.Find(s => s.Id == id).FirstOrDefaultAsync();

        // CREATE
        public async Task CreateAsync(Student student) =>
            await _students.InsertOneAsync(student);

        // UPDATE
        public async Task UpdateAsync(string id, Student student) =>
            await _students.ReplaceOneAsync(s => s.Id == id, student);

        // DELETE
        public async Task DeleteAsync(string id) =>
            await _students.DeleteOneAsync(s => s.Id == id);
    }
}