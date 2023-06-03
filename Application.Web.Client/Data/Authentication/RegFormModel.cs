namespace Application.Web.Client.Data.Authentication;
public class RegFormModel
{
    public string Name { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string Role { get; set; }
    public DateTime Date { get; set; }
    public string FIO { get; set; }
    public string Phone { get; set; }
}