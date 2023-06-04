import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-personalDocuments',
  templateUrl: './personalDocuments.component.html',
  styleUrls: ['./personalDocuments.component.scss']
})
export class PersonalDocumentsComponent implements OnInit {
  @Input() personalDocumentsId: string;

  constructor() { }

  ngOnInit() {
  }

}
