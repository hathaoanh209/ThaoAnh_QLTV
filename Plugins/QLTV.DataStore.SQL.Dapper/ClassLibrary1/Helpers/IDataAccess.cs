
namespace QLTV.DataStore.SQL.Dapper.Helpers
{
    public interface IDataAccess
    {
        void ExecuteCommand<U>(string sql, U parameters);
        List<T> Query<T, U>(string sql, U parameters);
     
        T QueryFirst<T, U>(string sql, U parameters);
        T QuerySingle<T, U>(string sql, U parameters);
      
        Task<IEnumerable<T>> QueryAsync<T, U>(string sql, U parameters);

    }
}