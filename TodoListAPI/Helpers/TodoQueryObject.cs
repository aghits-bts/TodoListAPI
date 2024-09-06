namespace TodoListAPI.Helpers
{
    public class TodoQueryObject
    {
        public bool? IsCompleted { get; set; }
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
