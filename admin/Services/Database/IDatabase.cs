
using admin.Models;

namespace admin.Services.Database;

public interface IDatabase {

  public List<Client> getClients();
  public bool createClient(Client client);
  public bool updateClient(Client client);
  public bool deleteClient(Client client);

  
  public List<Testimonial> getTestimonials();
  public bool createTestimonial(Testimonial testimonial);
  public bool updateTestimonial(Testimonial testimonial);
  public bool deleteTestimonial(Testimonial testimonial);

  
  public List<Service> getServices();
  public bool createService(Service service);
  public bool updateService(Service service);
  public bool deleteService(Service service);

}