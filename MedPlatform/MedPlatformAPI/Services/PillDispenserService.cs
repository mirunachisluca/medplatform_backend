using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MedPlatformAPI.Services
{
    public class PillDispenserService : PillDispenser.PillDispenserBase
    {
        private readonly ILogger<PillDispenserService> _logger;
        private readonly IMedicationPlanService _medicationPlanService;
        private readonly IMedicationStatusService _medicationStatusService;

        public PillDispenserService(ILogger<PillDispenserService> logger, IMedicationPlanService medicationPlanService,
                                    IMedicationStatusService medicationStatusService)
        {
            _logger = logger;
            _medicationPlanService = medicationPlanService;
            _medicationStatusService = medicationStatusService;
        }

        public override Task<MedicationPlanReply> GetMedicationPlan(MedicationPlanRequest request, ServerCallContext context)
        {

            _logger.LogInformation($"Get today's medications for patient with ID " + request.PatientId);

            var medicationPlans = _medicationPlanService.GetMedicationPlanForPatient(request.PatientId);

            var today = DateTime.Today;

            var reply = new MedicationPlanReply();

            foreach (MedicationPlanModel medPlan in medicationPlans)
            {
                if (DateTime.Compare(medPlan.StartDate, today) <= 0 && DateTime.Compare(medPlan.EndDate, today) >= 0)
                {
                    foreach (MedicationPlanDetailsModel planDetails in medPlan.MedicationList)
                    {
                        string[] intakeIntervals = planDetails.IntakeInterval.Split(", ");
                        foreach (string interval in intakeIntervals)
                        {
                            string[] intervalHours = interval.Split("-");

                            var details = new PlanDetails { MedicationId = planDetails.Medication.MedicationId, Name = planDetails.Medication.Name, IntakeIntervalStart = intervalHours[0], IntakeIntervalEnd = intervalHours[1] };
                            reply.Medication.Add(details);
                        }
                    }
                }
            }

            return Task.FromResult(reply);
        }

        public override Task<MedicationTakenReply> MedicationTaken(MedicationTakenRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Medication with ID " + request.MedicationId + " taken at " + DateTime.Now);

            var status = new MedicationStatus { MedicationId = request.MedicationId, Date = request.DateTime, PatientId = request.PatientId, Status = "Taken" };

            _medicationStatusService.AddMedicationStatus(status);

            return Task.FromResult(new MedicationTakenReply { Message = "Medication marked as taken" });
        }

        public override Task<MedicationMissedReply> MedicationMissed(MedicationMissedRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Medication with ID " + request.MedicationId + " missed on " + DateTime.Today);

            var status = new MedicationStatus { MedicationId = request.MedicationId, Date = request.DateTime, PatientId = request.PatientId, Status = "Missed" };

            _medicationStatusService.AddMedicationStatus(status);

            return Task.FromResult(new MedicationMissedReply { Message = "Medication marked as missed" });
        }

    }
}
