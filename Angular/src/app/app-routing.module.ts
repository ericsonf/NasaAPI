import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FotoDoDiaComponent } from './foto-do-dia/foto-do-dia.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: '' },
  { path: 'foto-do-dia', component: FotoDoDiaComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
