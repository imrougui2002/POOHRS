using P4ImplementInterfaces;

IPerson student = new Student { Name = "Eric Solomon", Age = 20 };
IPerson teacher = new Teacher { Name = "Kayla Lewis", Age = 35 };

student.DisplayInfo();
teacher.DisplayInfo();