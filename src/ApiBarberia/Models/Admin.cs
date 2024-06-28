namespace ApiBarberia;

public class Admin : User
{
    public Admin() : base()
    {
        UserType = UserType.Admin;
    }
}
