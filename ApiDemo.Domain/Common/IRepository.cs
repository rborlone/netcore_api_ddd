namespace ApiDemo.Domain.Common
{
    /// <summary>
    /// Interfaz para especificar el tipo de repositorio del dominio.
    /// </summary>
    /// <typeparam name="T">Recibe la clase que tiene que implementar IAggregateRoot.</typeparam>
    public interface IRepository<T> where T : IAggregateRoot
    {
    }
}
