namespace ToDoList.Models
{
    public class TodoItem
    {
        /// <summary>
        /// Identifier for the Todo Item entry
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// The name of the item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// True if the item is completed, false otherwise.
        /// </summary>
        public bool IsComplete { get; set; }
    }
}
