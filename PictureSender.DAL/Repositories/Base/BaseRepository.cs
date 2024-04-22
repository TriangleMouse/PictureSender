namespace PictureSender.DAL.Repositories.Base
{
    /// <summary>
    /// The basic interface for repositories containing common data access methods.
    /// </summary>
    public abstract class RepositoryBase
    {
        /// <summary>
        /// Executes the task if an error occurs rolls back the transaction
        /// </summary>
        /// <param name="execute">
        /// The task
        /// </param>
        protected async Task ExecuteAsync(Func<Task> execute)
        {
            try
            {
                await execute();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}