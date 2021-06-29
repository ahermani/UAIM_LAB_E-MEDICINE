INSERT INTO Speciality (Description, Number) VALUES ("Dentist", 1)
   INSERT INTO Speciality (Description, Number) VALUES ("Pediatrist", 2)
   INSERT INTO Speciality (Description, Number) VALUES ("Cardiologist", 3)
   INSERT INTO Speciality (Description, Number) VALUES ("Neurologist", 4)
   INSERT INTO Speciality (Description, Number) VALUES ("Urologist", 5)
   INSERT INTO Speciality (Description, Number) VALUES ("Laryngologist", 6)
   INSERT INTO Speciality (Description, Number) VALUES ("Dermatologist", 7)
   INSERT INTO Speciality (Description, Number) VALUES ("Psychiatrist", 8)


   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Jan", "Kowalski", "12345678911", "Male", 8200)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Janina", "Nowak", "12345678911", "Female", 8000)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Kamil", "Laszuk", "12665678911", "Male", 9890)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Albert", "Kral", "12665348911", "Male", 9200)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Wanda", "Chalicka", "12665347711", "Female", 9500)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Marian", "Bam", "12665311911", "Male", 7000)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Konrad", "Wimek", "22665311911", "Male", 7000)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Anna", "Jarmin", "12665341911", "Female", 8000)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Anna", "Astra", "12665561911", "Female", 8600)
   INSERT INTO Doctor (Name, Surname, Pesel, Gender, Wage) VALUES ("Jakub", "Wolkowski", "00665561911", "Male", 9600)


INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (3,2)
     INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (4,2)
	 INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (5,3)
     INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (6,3)

	 	 INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (7,4)
     INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (8,4)
	  	 INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (7,5)
	 	 INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (5,6)
     INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (4,6)

	   INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (1,1)
     INSERT INTO DoctorSpeciality (SpecialityId, DoctorId) VALUES (2,2)


   