using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Core.Entities;
using Infrastructure.DAL;

namespace XUnitTestProject
{
    public class UnitTest
    {
        private readonly DbContextOptions<MedPlatformContext> _options;

        public UnitTest()
        {
            _options = new DbContextOptionsBuilder<MedPlatformContext>()
                .UseInMemoryDatabase(databaseName: "testDatabase")
                .Options;

            

        }

        [Fact]
        public void Test1()
        {
            //arange
            SeedContext();
            //act

            using (var context=new MedPlatformContext(_options))
            {
                var uof = new UnitOfWork(context);

                var doctor3 = uof.DoctorRepository.GetByID(3);

                //asert
                Assert.Equal(3, doctor3.DoctorId);
                Assert.Equal("Doctor 3", doctor3.Name);
                Assert.Equal("Address 3", doctor3.Address);
            }

        }

        [Fact]
        public void Test2()
        {
            var medication = new Medication { MedicationId = 1, Name = "med 1", SideEffects = "effect 1", Dosage = "100mg" };

            using var context = new MedPlatformContext(_options);
            var uof = new UnitOfWork(context);

            uof.MedicationRepository.Insert(medication);

            var resultMed = uof.MedicationRepository.GetByID(1);

            Assert.NotNull(resultMed);
            Assert.Equal(medication.MedicationId, resultMed.MedicationId);
            Assert.Equal(medication.Name, resultMed.Name);
            Assert.Equal(medication.SideEffects, resultMed.SideEffects);
            Assert.Equal(medication.Dosage, resultMed.Dosage);
        }

        [Fact]
        public void Test3()
        {
            using var context = new MedPlatformContext(_options);
            var uof = new UnitOfWork(context);

            var doctor = uof.DoctorRepository.GetByID(5);

            Assert.Null(doctor);
        }

        [Fact]
        public void Test4()
        {
            using var context = new MedPlatformContext(_options);
            var uof = new UnitOfWork(context);

            uof.PatientRepository.Delete(2);
            uof.Save();

            var patient = uof.PatientRepository.GetByID(2);

            Assert.Null(patient);

        }

        
        private void SeedContext()
        {
            using var context = new MedPlatformContext(_options);
            context.Doctors.Add(new Doctor { DoctorId = 1, Name = "Doctor 1", Address = "Address 1", Gender = "male", Birthdate = DateTime.Today, UserId = 1 });
            context.Doctors.Add(new Doctor { DoctorId = 2, Name = "Doctor 2", Address = "Address 2", Gender = "female", Birthdate = DateTime.Today, UserId = 2 });
            context.Doctors.Add(new Doctor { DoctorId = 3, Name = "Doctor 3", Address = "Address 3", Gender = "male", Birthdate = DateTime.Today, UserId = 3 });
            context.Patients.Add(new Patient { PatientId = 2, Name = "Patient 2", Address = "Address 2", Gender = "female", Birthdate = DateTime.Today, UserId = 4 });

            context.SaveChanges();
        }
    }
}
