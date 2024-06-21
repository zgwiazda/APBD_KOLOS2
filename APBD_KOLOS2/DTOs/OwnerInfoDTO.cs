namespace APBD_KOLOS2.DTOs
{
    public class OwnerInfoDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public List<ObjectDTO> Objects { get; set; }
    }
}