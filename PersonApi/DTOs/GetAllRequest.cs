namespace PersonApi.DTOs
{
    public class GetAllRequest
    {
        /// <summary>
        /// Фильтр по имени (частичное совпадение)
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фильтр по фамилии (частичное совпадение)
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Фильтр по городу (частичное совпадение)
        /// </summary>
        public string City { get; set; }
    }
}