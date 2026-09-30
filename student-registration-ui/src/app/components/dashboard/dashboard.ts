import { Component, inject, signal } from '@angular/core';
import { StudentService } from '../../services/student-service';
import { Student } from '../../model/student';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  imports: [DatePipe],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard {
  private router = inject(Router);
  students = signal<Student[]>([]);

  constructor(private studentService: StudentService) {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.getAllStudents().subscribe({
      next: (students: Student[]) => {
        this.students.set(students);
      }
    });
  }

  deleteStudent(student: Student) {
    if (!confirm(`Delete ${student.name}?`)) return;
    this.studentService.deleteStudent(student.studentID).subscribe(() => this.loadStudents());
  }
  
  navigateToEditStudent(student: Student) {
    const newId = crypto.randomUUID();
    
    this.router.navigate(['/students', student.studentID, 'edit']);
  }

  navigateToAddStudent() {
    this.router.navigate(['/students', 'new']);
  }
}
