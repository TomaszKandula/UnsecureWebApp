namespace UnsecureWebApp.Model.Database
{

    public partial class Laptops
    {

        public int Id { get; set; }
        public string Brand { get; set; }
        public string SerialNo { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }

    }

}
