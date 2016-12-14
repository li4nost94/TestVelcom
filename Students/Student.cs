
namespace Students
{
    public class Student : StudentsApplication
    {
        internal Student()
        {
            Id = _freeId;
            _freeId++;
        }

        public int Id { get; }
      
        public string Imei { get; set; }
        public string PhoneNumber { get; set; }

        private static int _freeId = 
            StudentRecord.Count > 0 ? StudentRecord.Count + 1 : 1;
    }

}
