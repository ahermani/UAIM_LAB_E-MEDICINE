echo on
chcp 65001

echo PatientAppMicroservice
echo GetAllDoctors
curl -X GET "http://localhost:5005/doctors" -H  "accept: text/plain"
echo.
timeout 1
echo GetDoctorById
curl -X GET "http://localhost:5005/doctors/a263446a-1eed-490c-af70-de5391370e67" -H  "accept: text/plain"
echo.
timeout 1
echo GetPatientById
curl -X GET "http://localhost:5005/patients/65dff599-f82c-45c2-8496-d64c74bfaba1" -H  "accept: text/plain"
echo.
timeout 1
echo UpdatePatient
curl -X PUT "http://localhost:5005/patients/65dff599-f82c-45c2-8496-d64c74bfaba1" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"name\":\"Janina\",\"surname\":\"Nowak\",\"birthday\":\"1978-04-02T10:00:00\",\"gender\":1,\"phoneNumber\":\"123456999\",\"email\":\"nowak.janina@gmail.pl\",\"pesel\":\"00000000001\",\"registrationDate\":\"1978-04-02T10:00:00\",\"bloodType\":3,\"isActive\":false}"
echo.
timeout 1
echo GetAllTreatments
curl -X GET "http://localhost:5005/treatments" -H  "accept: text/plain"
echo.
timeout 1
echo GetTreatmentById
curl -X GET "http://localhost:5005/treatments/88295061-d4a7-416f-85b1-c1be1a0c60a0" -H  "accept: text/plain"
echo.
timeout 1
echo GetAppointmentById
curl -X GET "http://localhost:5005/appointments/f601915c-ee5c-44df-853b-2fc7a2fea0a3" -H  "accept: text/plain"
echo.
timeout 1
echo Update Appointment
curl -X PUT "http://localhost:5005/appointments/f601915c-ee5c-44df-853b-2fc7a2fea0a3" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"creatorId\":\"a263446a-1eed-490c-af70-de5391370e67\",\"state\":1,\"creationDate\":\"2021-04-17T16:51:48.9029259Z\",\"appointmentDate\":\"2021-06-10T11:30:00Z\",\"patientId\":\"65dff599-f82c-45c2-8496-d64c74bfaba1\",\"doctorId\":\"a263446a-1eed-490c-af70-de5391370e67\",\"treatmentIds\":[\"4fb87af9-fd55-43c2-b5d1-870eb135777d\"],\"note\":\"Eyesight check\"}"
echo.
timeout 1
echo PostAppointment
curl -X POST "http://localhost:5005/appointments" -H  "accept: text/plain" -H  "Content-Type: application/json" -d "{\"creatorId\":\"a263446a-1eed-490c-af70-de5391370e67\",\"state\":1,\"creationDate\":\"2021-04-17T16:51:48.9029259Z\",\"appointmentDate\":\"2021-06-10T11:30:00Z\",\"patientId\":\"65dff599-f82c-45c2-8496-d64c74bfaba1\",\"doctorId\":\"a263446a-1eed-490c-af70-de5391370e67\",\"treatmentIds\":[\"4fb87af9-fd55-43c2-b5d1-870eb135777d\"],\"note\":\"Stomach aches reported by patient\"}"
echo.
timeout 1
echo GetDoctorsAppointments
curl -X GET "http://localhost:5005/doctors/a263446a-1eed-490c-af70-de5391370e67/appointments" -H  "accept: text/plain"
echo.
timeout 1
echo GetDoctorsAppointmentsFrom
curl -X GET "http://localhost:5005/doctors/a263446a-1eed-490c-af70-de5391370e67/appointments?from=2021-05-21%%2000%%3A00%%3A00" -H  "accept: text/plain"
echo.
timeout 1
echo GetDoctorsAppointmentsTo
curl -X GET "http://localhost:5005/doctors/a263446a-1eed-490c-af70-de5391370e67/appointments?to=2021-05-21%%2000%%3A00%%3A00" -H  "accept: text/plain"
echo.
timeout 1
echo GetPatientsAppointments
curl -X GET "http://localhost:5005/patients/56b45256-ac34-4d2c-bcf2-aa17781a618b/appointments" -H  "accept: text/plain"
echo.
timeout 1
echo GetPatientsAppointmentsFromTo
curl -X GET "http://localhost:5005/patients/56b45256-ac34-4d2c-bcf2-aa17781a618b/appointments?from=2021-05-09%%2000%%3A00%%3A00&to=2021-05-22%%2023%%3A59%%3A59" -H  "accept: text/plain"
echo.
timeout 1
echo GetPatientsAppointmentsFrom
curl -X GET "http://localhost:5005/patients/56b45256-ac34-4d2c-bcf2-aa17781a618b/appointments?from=2021-05-09%%2000%%3A00%%3A00" -H  "accept: text/plain"
pause