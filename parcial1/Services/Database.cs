using Microsoft.EntityFrameworkCore;
using parcial1.Models;

namespace parcial1.Services;

public class Database : IDatabase
{
  private readonly ParcialContext pc;
  public Database(ParcialContext pc)
  {
    this.pc = pc;
  }

  public Database() { }

  public List<PersonalInformation> getAllPersons()
  {
    return pc.PersonalInformations.ToList();
  }
  public void InsertPersonalInformation(PersonalInformation pi)
  {
    pc.PersonalInformations.Add(pi);
    pc.SaveChanges();
  }
  public void UpdatePersonalInformation(PersonalInformation newData)
  {
    PersonalInformation pi = (PersonalInformation)pc.PersonalInformations.FirstOrDefault(_pi => _pi.Id == newData.Id);
    if (pi != null)
    {
      pi.Name = newData.Name;
      pi.DateOfBirth = newData.DateOfBirth;
      pi.Email = newData.Email;
      pi.PhoneNumber = newData.PhoneNumber;
      pi.Address = newData.Address;
      pc.SaveChanges();
    }

  }
  public void DeletePersonalInformation(int id)
  {
    PersonalInformation pi = (PersonalInformation)pc.PersonalInformations.FirstOrDefault(_pi => _pi.Id == id);
    pc.PersonalInformations.Remove(pi);
    pc.SaveChanges();
  }


  public List<Appointment> getAllAppinmets()
  {
    return pc.Appointments.Include(a => a.PersonalInformationDoctor).ToList();
  }

  public void InsertAppointment(Appointment app)
  {
    pc.Appointments.Add(app);
    pc.SaveChanges();
  }
  public void UpdateAppointment(Appointment newData)
  {
    Appointment app = (Appointment)pc.Appointments.FirstOrDefault(_app => _app.Id == newData.Id);
    if (app != null)
    {
      app.PersonalInformationDoctorId = newData.PersonalInformationDoctorId;
      app.PersonalInformationPatientId = newData.PersonalInformationPatientId;
      app.AppointmentDate = newData.AppointmentDate;
      app.AppointmentTime = newData.AppointmentTime;
      pc.SaveChanges();
    }
  }
  public void DeleteAppointment(int id)
  {
    Appointment app = (Appointment)pc.Appointments.FirstOrDefault(ap => ap.Id == id);
    pc.Appointments.Remove(app);
    pc.SaveChanges();
  }

}