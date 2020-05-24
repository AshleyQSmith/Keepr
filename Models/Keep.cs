namespace Keepr.Models
{
  public class Keep
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }

    // true = 1, false = 0
    public bool IsPrivate { get; set; }

    //views, shares, keeps auto set to 0 in SQL table
    public int Views { get; set; }
    public int Shares { get; set; }
    public int Keeps { get; set; }

  }
  public class VaultKeepViewModel : Keep
  {
    //   FYI pretty sure this is just labeled "id" in the table
    public int VaultKeepId { get; set; }

    // added by ashley while looking at table data, not sure if this is right!!
    public int VaultId { get; set; }
    public int KeepId { get; set; }

    // won't let me name this the same as above, but there's a spot for userid in the table...?
    // public string UserId { get; set; }

  }
}