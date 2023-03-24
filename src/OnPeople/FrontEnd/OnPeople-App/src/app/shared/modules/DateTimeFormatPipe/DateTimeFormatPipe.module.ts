import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DateTimeFormatPipe } from '../../models';


@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [DateTimeFormatPipe],
  exports: [DateTimeFormatPipe]
})
export class DateTimeFormatPipeModule { }
