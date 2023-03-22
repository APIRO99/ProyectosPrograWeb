using parcial1.Models;

namespace parcial1.Services;

public interface IDatabase {
  public List<PersonalInformation> getAllPersons();
  public void InsertPersonalInformation(PersonalInformation pi);
  public void UpdatePersonalInformation(PersonalInformation pi);
  public void DeletePersonalInformation(int id); 


  public List<Appointment> getAllAppinmets();
  public void InsertAppointment(Appointment app);
  public void UpdateAppointment(Appointment app);
  public void DeleteAppointment(int id); 

}