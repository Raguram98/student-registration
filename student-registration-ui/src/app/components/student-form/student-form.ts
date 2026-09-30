import { Component, inject, OnInit } from '@angular/core';
import { formatDate } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StudentService } from '../../services/student-service';
import { Student } from '../../model/student';

@Component({
  selector: 'app-student-form',
  imports: [ReactiveFormsModule],
  templateUrl: './student-form.html',
})
export class StudentForm implements OnInit {
  private fb = inject(FormBuilder);
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private studentService = inject(StudentService);

  id: string | null = this.route.snapshot.paramMap.get('id');

  form = this.fb.nonNullable.group({
    name: ['', Validators.required],
    department: ['', Validators.required],
    emailID: ['', [Validators.required, Validators.email]],
    gender: ['', Validators.required],
    dateOfBirth: ['', Validators.required],
  });

  ngOnInit() {
    if (this.id) {
      this.studentService.getStudentById(this.id).subscribe(s => {
        this.form.patchValue({
          name: s.name,
          department: s.department,
          emailID: s.emailID,
          gender: s.gender,
          dateOfBirth: formatDate(s.dateOfBirth, 'yyyy-MM-dd', 'en'),
        });
      });
    }
  }

  save() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    const student = this.form.getRawValue() as unknown as Student; 

    const request = this.id
      ? this.studentService.updateStudent({ ...student, studentID: this.id })
      : this.studentService.addStudent(student);

    request.subscribe(() => this.router.navigate(['/']));
  }

  cancel() {
    this.router.navigate(['/']);
  }
}