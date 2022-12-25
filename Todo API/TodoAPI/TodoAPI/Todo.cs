namespace TodoAPI
{
    /// <summary>
    /// Todo model class
    /// </summary>
    public class Todo
    {
        /// <summary>
        /// Todo id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category id that the Todo contains
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Todo name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// todo content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// This field contains Todo created date
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// This field contains Todo updated date
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// Todo status. if comlete is true else is false.
        /// </summary>
        public bool Status { get; set; }

    }
}
