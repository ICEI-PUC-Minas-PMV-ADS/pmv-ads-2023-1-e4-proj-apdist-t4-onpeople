import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';

import { TitlebarComponent } from 'src/app/components';

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
