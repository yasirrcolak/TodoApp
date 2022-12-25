namespace TodoAPI
{
    /// <summary>
    /// Cattegory model class
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Category id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This field contains Category created date
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// This field contains Category updated date
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
