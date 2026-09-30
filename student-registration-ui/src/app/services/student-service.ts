import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Student } from '../model/student';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentService {


  private baseUrl = environment.apiUrl + '/student';
  constructor(private http: HttpClient) { }

  getAllStudents(){
    return this.http.get<Student[]>(this.baseUrl);
  }

  // getAllStudents(): Observable<Student[]> {
  //   return this.http.get<Student[]>(this.baseUrl).pipe(
  //     map(list => list.map(x => ({
  //       studentId: x.studentId,
  //       name: x.name,
  //       department: x.department,
  //       emailId: x.emailId,
  //       gender: x.gender,
  //       DateOfBirth: new Date(x.DateOfBirth),
  //     })))
  //   );
  // }

  getStudentById(id: string) {
    return this.http.get<Student>(`${this.baseUrl}/${id}`);
  }

  addStudent(student: Student) {
    return this.http.post<Student>(this.baseUrl, student);
  }

  updateStudent(student: Student) {
    return this.http.put<Student>(`${this.baseUrl}/${student.studentID}`, student);
  }

  deleteStudent(id: string) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
