import { NgModule } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SpinnerComponent } from 'src/app/components';

@NgModule({
  imports: [
    MatCardModule,
    MatProgressSpinnerModule,
  ],
  declarations: [
    SpinnerComponent
  ],
  exports: [
    SpinnerComponent
  ]
})
export class SpinnerModule { }
