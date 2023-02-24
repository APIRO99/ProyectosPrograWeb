
using admin.Models;

namespace admin.Services.Database;

public class ECHOMECHANICALMYSQL : IDatabase
{

  private readonly EcomechanicalContext dbContext;
  public ECHOMECHANICALMYSQL(EcomechanicalContext dbContext)
  {
    this.dbContext = dbContext;
  }

  // CLIENT =============================================
  // ====================================================
  public List<Client> getClients()
  {
    return dbContext.Clients.ToList();
  }

  public bool createClient(Client client)
  {
    throw new NotImplementedException();
  }

  public bool updateClient(Client client)
  {
    var result = dbContext.Clients.SingleOrDefault(b => b.ClientId == client.ClientId);
    if (result != null)
    {
      result.ClientName = client.ClientName;
      result.ClientEmail = client.ClientEmail;
      dbContext.SaveChanges();
      return true;
    }
    return false;
  }

  public bool deleteClient(Client client)
  {
    throw new NotImplementedException();
  }



  // SERVICE ============================================
  // ====================================================
  public List<Service> getServices()
  {
    return dbContext.Services.ToList();
  }

  public bool createService(Service service)
  {
    throw new NotImplementedException();
  }

  public bool updateService(Service service)
  {
    throw new NotImplementedException();
  }

  public bool deleteService(Service service)
  {
    throw new NotImplementedException();
  }



  // TESTIMONIALS =======================================
  // ====================================================
  public List<Testimonial> getTestimonials()
  {
    return dbContext.Testimonials.ToList();
  }

  public bool createTestimonial(Testimonial testimonial)
  {
    throw new NotImplementedException();
  }

  public bool updateTestimonial(Testimonial testimonial)
  {
    throw new NotImplementedException();
  }

  public bool deleteTestimonial(Testimonial testimonial)
  {
    throw new NotImplementedException();
  }
}