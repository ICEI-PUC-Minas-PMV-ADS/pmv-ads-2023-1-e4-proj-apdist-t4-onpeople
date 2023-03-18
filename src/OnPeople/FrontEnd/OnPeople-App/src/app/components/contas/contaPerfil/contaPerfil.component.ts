import { Component, OnInit } from '@angular/core';

import { faIdCard, faKey } from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-contaPerfil',
  templateUrl: './contaPerfil.component.html',
  styleUrls: ['./contaPerfil.component.scss']
})
export class ContaPerfilComponent implements OnInit {

  public iconTab1 = faIdCard;
  public iconTab2 = faKey;


  constructor() { }

  ngOnInit() {
  }

}

