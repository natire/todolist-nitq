using Clase2022.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Clase2022.Services;
    public class TasksService
    {
        private readonly IMongoCollection<Tasks> _tasksCollection;

        public TasksService(IOptions<DataBaseSettings> tasksDataBaseSettings)
        {
            MongoClient mongoClient = new MongoClient(tasksDataBaseSettings.Value.ConnectionString);

            var mongoDataBase = mongoClient.GetDatabase(tasksDataBaseSettings.Value.DatabaseName);

            _tasksCollection = mongoDataBase.GetCollection<Tasks>(tasksDataBaseSettings.Value.CollectionName);
        }

        public async Task<List<Tasks>> GetAsync() => await
                _tasksCollection.Find(_ => true).ToListAsync();

        public async Task<Tasks?> GetAsync(string id) =>
           await _tasksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Tasks newtask) => await
        _tasksCollection.InsertOneAsync(newtask);

        public async Task UpdateAsync(string id, Tasks updateTasks) =>
            await _tasksCollection.ReplaceOneAsync(x => x.Id == id, updateTasks);

        public async Task RemoveAsync(string id) =>
            await _tasksCollection.DeleteOneAsync(x => x.Id == id);
    }

