import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TitlebarComponent } from '../../components';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  imports: [
    CommonModule,
    MatIconModule,
  ],
  declarations: [
    TitlebarComponent,
  ],
  exports: [
    TitlebarComponent
  ]
})
export class TitlebarModule { }
