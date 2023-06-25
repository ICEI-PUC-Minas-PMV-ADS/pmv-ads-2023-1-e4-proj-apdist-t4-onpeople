import { Component, Input, OnInit } from '@angular/core';
import { ProgressSpinnerMode } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss']
})
export class SpinnerComponent implements OnInit {

  public spinnerColor = 'rgba(51,51,51,0.8)';
  public spinnerMode: ProgressSpinnerMode = 'indeterminate';
  public spinnerDiameter = 100;

  constructor() { }

  ngOnInit() {
  }

}
