using Domain.Models;

namespace FileData;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<ToDo> Todos { get; set; }
}