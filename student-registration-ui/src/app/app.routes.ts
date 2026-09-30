import { Routes } from '@angular/router';
import { StudentForm } from './components/student-form/student-form';
import { Dashboard } from './components/dashboard/dashboard';

export const routes: Routes = [
  { path: '', component: Dashboard },
  { path: 'students/new', component: StudentForm },
  { path: 'students/:id/edit', component: StudentForm },
  { path: '**', redirectTo: '' },
];
