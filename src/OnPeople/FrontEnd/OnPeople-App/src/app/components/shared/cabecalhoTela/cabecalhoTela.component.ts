import { Component, Input, OnInit } from '@angular/core';
import { faBuilding, faBinoculars, faUsersViewfinder } from '@fortawesome/free-solid-svg-icons'
@Component({
  selector: 'app-cabecalhoTela',
  templateUrl: './cabecalhoTela.component.html',
  styleUrls: ['./cabecalhoTela.component.scss']
})
export class CabecalhoTelaComponent implements OnInit {

  public contaLogada = false;

  @Input() titulo: string | undefined;
  @Input() subTitulo: string | undefined;
  @Input() iconCabecalho = faBuilding
  @Input() iconVisao = faUsersViewfinder
  @Input() visao = 'Adminstrador'

  constructor() { }

  ngOnInit() {
  }

  public listar() {

  }
}
